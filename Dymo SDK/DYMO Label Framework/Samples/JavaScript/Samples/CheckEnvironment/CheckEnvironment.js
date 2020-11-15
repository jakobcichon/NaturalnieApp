//----------------------------------------------------------------------------
//
//  $Id: CheckEnvironment.js 11614 2010-04-28 13:45:03Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework
//
// Content -------------------------------------------------------------------
//
//  DYMO Label Framework JavaScript Library Samples: Check Environment
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------


(function()
{
    // called when the document completly loaded
    function onload()
    {
        var checkButton = document.getElementById('checkButton');
        var outputDiv = document.getElementById('output');

        function clearOutput()
        {
            while (outputDiv.children.length > 0)
                outputDiv.removeChild(outputDiv.firstChild);
        }

        function outputLine(text)
        {
            var elem = document.createElement("div");
            elem.appendChild(document.createTextNode(text));

            outputDiv.appendChild(elem);
        }


        // prints the label
        checkButton.onclick = function()
        {
            try
            {
                //clearOutput();
                var result = dymo.label.framework.checkEnvironment();
                outputLine(" ");
                outputLine("isBrowserSupported: " + result.isBrowserSupported);
                outputLine("isFrameworkInstalled: " + result.isFrameworkInstalled);
                outputLine("errorDetails: " + result.errorDetails);
            }
            catch(e)
            {
                alert(e.message || e);
            }
        }
    };

    // register onload event
    if (window.addEventListener)
        window.addEventListener("load", onload, false);
    else if (window.attachEvent)
        window.attachEvent("onload", onload);
    else
        window.onload = onload;

} ());