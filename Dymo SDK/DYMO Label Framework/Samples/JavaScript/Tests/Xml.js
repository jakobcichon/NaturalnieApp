//----------------------------------------------------------------------------
//
//  $Id: Xml.js 10764 2010-01-13 19:46:24Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework
//
// Content -------------------------------------------------------------------
//
//  DYMO Label Framework JavaScript Library xml utils for tesing purposes
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------

///////////////////////////////////////////////////////////////////
// Xml utils
///////////////////////////////////////////////////////////////////

// Xml utils
// most functions are slitly modified samples from 
// "JavaScript: The Definitive Guide, Fifth Edition" book by David Flanagan
var Xml = {};

// Parse the XML document contained in the string argument and return
// a Document object that represents it.
Xml.parse = function(text)
{
    if (typeof DOMParser != "undefined")
    {
        // Mozilla, Firefox, and related browsers
        return (new DOMParser()).parseFromString(text, "application/xml");
    }
    else if (typeof ActiveXObject != "undefined")
    {
        // Internet Explorer.
        var doc = new ActiveXObject("MSXML2.DOMDocument");  // Create an empty document
        doc.loadXML(text);            // Parse text into it
        return doc;                   // Return it
    }
    else
    {
        // As a last resort, try loading the document from a data: URL
        // This is supposed to work in Safari.  Thanks to Manos Batsis and
        // his Sarissa library (sarissa.sourceforge.net) for this technique.
        var url = "data:text/xml;charset=utf-8," + encodeURIComponent(text);
        var request = new XMLHttpRequest();
        request.open("GET", url, false);
        request.send(null);
        return request.responseXML;
    }
};

Xml.serialize = function(node)
{
    if (typeof XMLSerializer != "undefined")
        return (new XMLSerializer()).serializeToString(node);
    else if (node.xml)
        return node.xml;
    else
        throw new Error("XML.serialize is not supported or can't serialize " + node);
};

// appends a new element to DOM tree as child of parent and set it content to text
// parent - parent Element
// tagName - the element's tagName
// text - the element's content
// returns - new added element
Xml.appendElement = function(parentElement, tagName, text)
{
    var result = parentElement.ownerDocument.createElement(tagName);
    result.appendChild(parentElement.ownerDocument.createTextNode(text));
    parentElement.appendChild(result);
    
    return result;
}

// returns text content of the element, e.g. for tag <Name>address123</Name>, 'address123' will be returned
Xml.getElementText = function(elem)
{
    if (!elem)
        return "";

    var result = "";
    for (var i = 0; i < elem.childNodes.length; i++)
        if (elem.childNodes[i].nodeType == 3) //TEXT_NODE
        result = result + elem.childNodes[i].data;

    return result;
}

// set text content of the elem. Note: all other children of the element will be deleted
// element - element to set text
// text - text string to set
Xml.setElementText = function(element, text)
{
    // first, remove all children...
    Xml.removeAllChildren(element);

    // ...then add text
    element.appendChild(element.ownerDocument.createTextNode(text));
}

// removes all children nodes of the specified node
Xml.removeAllChildren = function(node)
{
    while (node.firstChild)
        node.removeChild(node.firstChild);
}

/**
* XML.XPathExpression is a class that encapsulates an XPath query and its
* associated namespace prefix-to-URL mapping.  Once an XML.XPathExpression
* object has been created, it can be evaluated one or more times (in one
* or more contexts) using the getNode() or getNodes() methods.
*
* The first argument to this constructor is the text of the XPath expression.
* 
* If the expression includes any XML namespaces, the second argument must
* be a JavaScript object that maps namespace prefixes to the URLs that define
* those namespaces.  The properties of this object are the prefixes, and
* the values of those properties are the URLs.
*/
Xml.XPathExpression = function(context, xpathText, namespaces)
{
    this.xpathText = xpathText;    // Save the text of the expression
    this.namespaces = namespaces;  // And the namespace mapping

    // We need the Document object to call createExpression
    var doc = context.ownerDocument;
    // If the context doesn't have ownerDocument, it is the Document
    if (doc == null)
        doc = context;

    if (doc.createExpression)
    {
        // If we're in a W3C-compliant browser, use the W3C API to compile the text of the XPath query
        this.xpathExpr = doc.createExpression(xpathText,
        // This function is passed a 
        // namespace prefix and returns the URL.
                                      function(prefix)
                                      {
                                          return namespaces[prefix];
                                      });
    }
    else
    {
        // Otherwise, we assume for now that we're in IE and convert the
        // namespaces object into the textual form that IE requires.
        this.namespaceString = "";
        if (namespaces != null)
        {
            for (var prefix in namespaces)
            {
                // Add a space if there is already something there
                if (this.namespaceString) this.namespaceString += ' ';
                // And add the namespace
                this.namespaceString += 'xmlns:' + prefix + '="' +
                    namespaces[prefix] + '"';
            }
        }
    }
};

/**
* This is the getNodes() method of XML.XPathExpression.  It evaluates the
* XPath expression in the specified context.  The context argument should
* be a Document or Element object.  The return value is an array 
* or array-like object containing the nodes that match the expression.
*/
Xml.XPathExpression.prototype.getNodes = function(context)
{
    if (this.xpathExpr)
    {
        // If we are in a W3C-compliant browser, we compiled the
        // expression in the constructor.  We now evaluate that compiled
        // expression in the specified context
        var result =
            this.xpathExpr.evaluate(context,
        // This is the result type we want
                                    XPathResult.ORDERED_NODE_SNAPSHOT_TYPE,
                                    null);

        // Copy the results we get into an array.
        var a = new Array(result.snapshotLength);
        for (var i = 0; i < result.snapshotLength; i++)
        {
            a[i] = result.snapshotItem(i);
        }
        return a;
    }
    else
    {
        // If we are not in a W3C-compliant browser, attempt to evaluate
        // the expression using the IE API.
        try
        {
            // We need the Document object to specify namespaces
            var doc = context.ownerDocument;
            // If the context doesn't have ownerDocument, it is the Document
            if (doc == null) doc = context;

            // This is IE-specific magic to specify prefix-to-URL mapping
            //doc.setProperty("SelectionLanguage", "XPath");
            //doc.setProperty("SelectionNamespaces", this.namespaceString);
            // vb: setProperty() fails on IE8
            try { doc.setProperty("SelectionLanguage", "XPath"); } catch (e) { }
            try { doc.setProperty("SelectionNamespaces", this.namespaceString); } catch (e) { }


            // In IE, the context must be an Element not a Document, 
            // so if context is a document, use documentElement instead
            if (context == doc) context = doc.documentElement;
            // Now use the IE method selectNodes() to evaluate the expression
            var result = context.selectNodes(this.xpathText);
            
            // in IE8 the result is INodeSelection, not nodes themselves
            // 
            var a = new Array(result.length);
            for (var i = 0; i < result.length; i++)
            {
                a[i] = result[i];
            }
            return a;

        }
        catch (e)
        {
            // If the IE API doesn't work, we just give up
            throw "XPath not supported by this browser.: " + e;
        }
    }
}


/**
* This is the getNode() method of XML.XPathExpression.  It evaluates the
* XPath expression in the specified context and returns a single matching
* node (or null if no node matches).  If more than one node matches,
* this method returns the first one in the document.
* The implementation differs from getNodes() only in the return type.
*/
Xml.XPathExpression.prototype.getNode = function(context)
{
    if (this.xpathExpr)
    {
        var result = this.xpathExpr.evaluate(
            context,
        // We just want the first match
            XPathResult.FIRST_ORDERED_NODE_TYPE,
            null);
        return result.singleNodeValue;
    }
    else
    {
        try
        {
            var doc = context.ownerDocument;
            if (doc == null) doc = context;

            try { doc.setProperty("SelectionLanguage", "XPath"); } catch (e) { }
            try { doc.setProperty("SelectionNamespaces", this.namespaceString); } catch (e) { }

            if (context == doc) context = doc.documentElement;
            // In IE call selectSingleNode instead of selectNodes
            return context.selectSingleNode(this.xpathText);
        }
        catch (e)
        {
            throw "XPath not supported by this browser.: " + e;
        }
    }
};

// A utility to create an XML.XPathExpression and call getNodes() on it
Xml.getNodes = function(context, xpathExpr, namespaces)
{
    namespaces = namespaces || null;
    return (new Xml.XPathExpression(context, xpathExpr, namespaces)).getNodes(context);
};

// A utility to create an XML.XPathExpression and call getNode() on it
Xml.getNode = function(context, xpathExpr, namespaces)
{
    namespaces = namespaces || null;
    return (new Xml.XPathExpression(context, xpathExpr, namespaces)).getNode(context);
};
