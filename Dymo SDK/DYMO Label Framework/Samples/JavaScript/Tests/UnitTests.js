//----------------------------------------------------------------------------
//
//  $Id: UnitTests.js 15986 2011-09-06 16:24:02Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework
//
// Content -------------------------------------------------------------------
//
//  DYMO Label Framework JavaScript Library functional tests
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------

var _tests = {}
_tests["versionTest"] = versionTest;
_tests["labelGetAddressObjectCountTest"] = labelGetAddressObjectCountTest;
_tests["labelGetAddressBacodePosition"] = labelGetAddressBacodePosition;
_tests["labelSetAddressBacodePosition"] = labelSetAddressBacodePosition;
_tests["labelSetInvalidAddressBacodePosition"] = labelSetInvalidAddressBacodePosition;
_tests["labelGetObjectNamesTest"] = labelGetObjectNamesTest;
_tests["labelGetObjectTextTest"] = labelGetObjectTextTest;
_tests["labelSetObjectTextTest"] = labelSetObjectTextTest;
_tests["labelSetAddressText"] = labelSetAddressText;
_tests["createLabelWriterPrintParamsXmlTest"] = createLabelWriterPrintParamsXmlTest;
_tests["createTapePrintParamsXmlTest"] = createTapePrintParamsXmlTest;
_tests["createLabelRenderParamsXmlTest"] = createLabelRenderParamsXmlTest;
_tests["openNotExistedLabelTest"] = openNotExistedLabelTest;
_tests["setTextSpecialChars"] = setTextSpecialChars;
_tests["openLabelUrl"] = openLabelUrl;
_tests["loadImageUrl"] = loadImageUrl;
_tests["loadNonExistedImage"] = loadNonExistedImage;
_tests["loadExistingButInvalidImage"] = loadExistingButInvalidImage;
_tests["openNonExistedLabelFile"] = openNonExistedLabelFile;
_tests["openNonExistedLabelUrl"] = openNonExistedLabelUrl;
_tests["openExistingButInvalidLabel"] = openExistingButInvalidLabel;
_tests["setObjectText_AddressNoLineFonts"] = setObjectText_AddressNoLineFonts;
_tests["setObjectText_AddressNoLineFontsPreserveStyle"] = setObjectText_AddressNoLineFontsPreserveStyle;
_tests["setObjectText_AddressNoLineFontsPreserveStyle2"] = setObjectText_AddressNoLineFontsPreserveStyle2;
_tests["setObjectText_AddressNoLineFontsPreserveStyle3"] = setObjectText_AddressNoLineFontsPreserveStyle3;
_tests["setObjectText_LongLabelXml"] = setObjectText_LongLabelXml;
_tests["setObjectText_Tag"] = setObjectText_Tag;


/// replaces the last component of the url with fileName
function _replaceFileName(url, fileName)
{
    var i = url.lastIndexOf('/');
    return url.substr(0, i + 1) + fileName;
}


//_tests["failedTest"] = failedTest;


// utility test functions

function outputLine(text, style)
{
    var elem = document.createElement("div");
    elem.appendChild(document.createTextNode(text));
    
    if (style)
        //elem.style = style;
        elem.setAttribute("style", style);
        
    //    elem.style.backgroundColor = "red";

    document.getElementById("testsContainer").appendChild(elem);
}

function outputOK(text)
{
    outputLine(text, "background-color:#00ff00;");
}


function outputError(text)
{
    outputLine(text, "background-color:#ff0000;");
}

// unit tests support




function runTests()
{
    for (testName in _tests)
        runTest(_tests[testName], testName);
}

function assertEqual(expected, actual, message)
{
    if (expected == actual)
        return;
        
    if (message)
        throw message;
        
    throw "expected '" + expected.toString() + "' but was '" + actual.toString() + "'";    
}

function runTest(testFunction, testName)
{
    try
    {
        testFunction();
        
        //output OK result
        outputOK(testName + ": OK");
    }
    catch (e)
    {
        outputError(testName + ": ERROR: " + (e.description || e.message || e));
        
        // this is for IE 6&7
//        if (e.message)
//            outputError(testName + ": ERROR: " + e.message);
//        if (e.description)
//            outputError(testName + ": ERROR: " + e.description);
    }
}



var gTestAddressLabelXml = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" />\
        </DrawCommands>\
        <ObjectInfo>\
            <AddressObject>\
                <Name>Address</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                <StyledText>\
                    <Element>\
                        <String>Vladimir Buzuev\n4660 Heyer Ave\nCastro Valley CA 94546-1036</String>\
                        <Attributes>\
                            <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                            <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                        </Attributes>\
                    </Element>\
                </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>AboveAddress</BarcodePosition>\
                <LineFonts>\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                </LineFonts>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
    </DieCutLabel>';

var gTwoAddressesLabelXml = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" />\
        </DrawCommands>\
        <ObjectInfo>\
            <AddressObject>\
                <Name>Address</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                <StyledText>\
                    <Element>\
                        <String>Vladimir Buzuev\n4660 Heyer Ave\nCastro Valley CA 94546-1036</String>\
                        <Attributes>\
                            <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                            <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                        </Attributes>\
                    </Element>\
                </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>AboveAddress</BarcodePosition>\
                <LineFonts>\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                </LineFonts>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
<ObjectInfo>\
            <AddressObject>\
                <Name>Address2</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                <StyledText>\
                    <Element>\
                        <String>Vladimir Buzuev\n828 San Pablo Ave\nAlabny CA 94706</String>\
                        <Attributes>\
                            <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                            <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                        </Attributes>\
                    </Element>\
                </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>BelowAddress</BarcodePosition>\
                <LineFonts>\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                    <Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                </LineFonts>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
    </DieCutLabel>';


    var gTestAddressLabelXmlNoLineFonts = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" />\
        </DrawCommands>\
        <ObjectInfo>\
            <AddressObject>\
                <Name>Address</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                <StyledText>\
                    <Element>\
                        <String>Vladimir Buzuev\n4660 Heyer Ave\nCastro Valley CA 94546-1036</String>\
                        <Attributes>\
                            <Font Family="Arial" Size="42" Bold="False" Italic="False" Underline="False" Strikeout="False" />\
                            <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                        </Attributes>\
                    </Element>\
                </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>AboveAddress</BarcodePosition>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
    </DieCutLabel>';

    var gTestAddressLabelXmlNoLineFonts2 = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" />\
        </DrawCommands>\
        <ObjectInfo>\
            <AddressObject>\
                <Name>Address</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                  <StyledText>\
                    <Element>\
                      <String>line1</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="14" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>\n</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="18" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>line2</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="8" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>\n</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="18" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>line3</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="36" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>\nline4</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="18" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                  </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>AboveAddress</BarcodePosition>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
    </DieCutLabel>';

    var gTestAddressLabelXmlNoLineFonts3 = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" />\
        </DrawCommands>\
        <ObjectInfo>\
            <AddressObject>\
                <Name>Address</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0" />\
                <BackColor Alpha="0" Red="255" Green="255" Blue="255" />\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>True</IsVariable>\
                <HorizontalAlignment>Left</HorizontalAlignment>\
                <VerticalAlignment>Middle</VerticalAlignment>\
                <TextFitMode>ShrinkToFit</TextFitMode>\
                <UseFullFontHeight>True</UseFullFontHeight>\
                <Verticalized>False</Verticalized>\
                  <StyledText>\
                    <Element>\
                      <String>line1</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="14" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>\n\n</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="18" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>line3\n</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="8" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>line4</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="36" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                    <Element>\
                      <String>\nline5</String>\
                      <Attributes>\
                        <Font Family="Menlo" Size="18" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                        <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                      </Attributes>\
                    </Element>\
                  </StyledText>\
                <ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly>\
                <BarcodePosition>AboveAddress</BarcodePosition>\
            </AddressObject>\
            <Bounds X="332" Y="150" Width="4455" Height="1260" />\
        </ObjectInfo>\
    </DieCutLabel>';



function versionTest()
{
    assertEqual(true, dymo.label.framework.VERSION != "");
}  

function labelGetAddressObjectCountTest()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    assertEqual(1, label.getAddressObjectCount());
    
    label = dymo.label.framework.openLabelXml(gTwoAddressesLabelXml);
    assertEqual(2, label.getAddressObjectCount());
    
}  

function labelGetAddressBacodePosition()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
    
    label = dymo.label.framework.openLabelXml(gTwoAddressesLabelXml);
    assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
    assertEqual(dymo.label.framework.AddressBarcodePosition.BelowAddress, label.getAddressBarcodePosition(1));

}

function labelSetAddressBacodePosition()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
    
    label.setAddressBarcodePosition(0, dymo.label.framework.AddressBarcodePosition.BelowAddress);
    assertEqual(dymo.label.framework.AddressBarcodePosition.BelowAddress, label.getAddressBarcodePosition(0));
    
    label.setAddressBarcodePosition(0, dymo.label.framework.AddressBarcodePosition.Suppress);
    assertEqual(dymo.label.framework.AddressBarcodePosition.Suppress, label.getAddressBarcodePosition(0));
    
    label.setAddressBarcodePosition(0, dymo.label.framework.AddressBarcodePosition.AboveAddress);
    assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
}

function labelSetAddressText()
{
    var label = dymo.label.framework.openLabelXml(gTwoAddressesLabelXml);
    assertEqual("Vladimir Buzuev\n828 San Pablo Ave\nAlabny CA 94706", label.getAddressText(1));
    var newAddress = "DYMO\n828 San Pablo Ave\nAlabny CA 94706";
    label.setAddressText(1, newAddress);
    assertEqual(newAddress, label.getAddressText(1));
}


function labelSetInvalidAddressBacodePosition()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
    
    try
    {
        label.setAddressBarcodePosition(0, "InvalidValue");
    }
    catch(e)
    {
        // value remains the same
        assertEqual(dymo.label.framework.AddressBarcodePosition.AboveAddress, label.getAddressBarcodePosition(0));
        return;
   }

    throw "should not be here";
}

function labelGetObjectNamesTest()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    var objectNames = label.getObjectNames();
    
    assertEqual(1, objectNames.length);
    assertEqual("Address", objectNames[0]);
    
    label = dymo.label.framework.openLabelXml(gTwoAddressesLabelXml);
    objectNames = label.getObjectNames();
    assertEqual(2, objectNames.length);
    assertEqual("Address", objectNames[0]);
    assertEqual("Address2", objectNames[1]);
}  

function labelGetObjectTextTest()
{
    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "AllObjects.label"));
    var objectNames = label.getObjectNames();

    assertEqual(8, objectNames.length);

    assertEqual("Click here to enter text", label.getObjectText("TEXT"));
    assertEqual("", label.getObjectText("SHAPE"));
    assertEqual("Vladimir Buzuev\n828 San Pablo Ave Ste 101\nAlbany, CA 94706-1006", label.getObjectText("ADDRESS"));
    assertEqual("Double-click to enter text", label.getObjectText("CURVED-TEXT"));
    assertEqual("12345", label.getObjectText("BARCODE"));
    assertEqual(true, label.getObjectText("GRAPHIC") != "");
    assertEqual("", label.getObjectText("DATE-TIME"));
    assertEqual("", label.getObjectText("COUNTER"));
}

function labelSetObjectTextTest()
{
    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "AllObjects.label"));

    label.setObjectText("BARCODE", "42");
    assertEqual("42", label.getObjectText("BARCODE"));

    label.setObjectText("CURVED-TEXT", "43");
    assertEqual("43", label.getObjectText("CURVED-TEXT"));

    var pngData = dymo.label.framework.loadImageAsPngBase64(_replaceFileName(document.location.href, "error.png"));
    label.setObjectText("GRAPHIC", pngData);
    assertEqual(pngData, label.getObjectText("GRAPHIC"));

    label.setObjectText("TEXT", "44");
    assertEqual("44", label.getObjectText("TEXT"));
    //alert(label.getLabelXml());

    label.setObjectText("ADDRESS", "1\r\n2\r\n3\r\n4");
    assertEqual("1\n2\n3\n4", label.getObjectText("ADDRESS"));
    //alert(label.getLabelXml());

    //    assertEqual("", label.getObjectText("SHAPE"));
    //    assertEqual("Vladimir Buzuev\n828 San Pablo Ave Ste 101\nAlbany, CA 94706-1006", label.getObjectText("ADDRESS"));
    //    assertEqual("Double-click to enter text", label.getObjectText("CURVED-TEXT"));
    //    assertEqual("12345", label.getObjectText("BARCODE"));
    //    assertEqual(true, label.getObjectText("GRAPHIC") != "");
    //    assertEqual("", label.getObjectText("DATE-TIME"));
    //    assertEqual("", label.getObjectText("COUNTER"));
    //}
}

function createLabelWriterPrintParamsXmlTest()
{
    var params =
    {
        copies: 42,
        jobTitle: "My Job Title",
        flowDirection: dymo.label.framework.FlowDirection.RightToLeft,
        printQuality: dymo.label.framework.LabelWriterPrintQuality.Text,
        twinTurboRoll: dymo.label.framework.TwinTurboRoll.Right,
        
        dummy: 123 // should be ignored
    };

    var paramsXml = dymo.label.framework.createLabelWriterPrintParamsXml(params);

    var doc = Xml.parse(paramsXml);
    assertEqual(42, Xml.getElementText(Xml.getNode(doc, "/LabelWriterPrintParams/Copies")));
    assertEqual("My Job Title", Xml.getElementText(Xml.getNode(doc, "/LabelWriterPrintParams/JobTitle")));
    assertEqual("RightToLeft", Xml.getElementText(Xml.getNode(doc, "/LabelWriterPrintParams/FlowDirection")));
    assertEqual("Text", Xml.getElementText(Xml.getNode(doc, "/LabelWriterPrintParams/PrintQuality")));
    assertEqual("Right", Xml.getElementText(Xml.getNode(doc, "/LabelWriterPrintParams/TwinTurboRoll")));

    // no other elements
    assertEqual(5, Xml.getNodes(doc, "/LabelWriterPrintParams/*").length);
}

function createTapePrintParamsXmlTest()
{
    var params =
    {
        copies: 42,
        jobTitle: "My Job Title",
        flowDirection: dymo.label.framework.FlowDirection.RightToLeft,
        alignment: dymo.label.framework.TapeAlignment.Right,
        cutMode: dymo.label.framework.TapeCutMode.ChainMarks,

        dummy: 123 // should be ignored
    };

    var paramsXml = dymo.label.framework.createTapePrintParamsXml(params);

    var doc = Xml.parse(paramsXml);
    assertEqual(42, Xml.getElementText(Xml.getNode(doc, "/TapePrintParams/Copies")));
    assertEqual("My Job Title", Xml.getElementText(Xml.getNode(doc, "/TapePrintParams/JobTitle")));
    assertEqual("RightToLeft", Xml.getElementText(Xml.getNode(doc, "/TapePrintParams/FlowDirection")));
    assertEqual("Right", Xml.getElementText(Xml.getNode(doc, "/TapePrintParams/Alignment")));
    assertEqual("ChainMarks", Xml.getElementText(Xml.getNode(doc, "/TapePrintParams/CutMode")));

    // no other elements
    assertEqual(5, Xml.getNodes(doc, "/TapePrintParams/*").length);
}

function createLabelRenderParamsXmlTest()
{
    var params =
    {
        labelColor: { a: 42, r: 43, g: 44, b: 45 },
        shadowColor: { r: 143, g: 144, b: 145 },
        shadowDepth: 42.42,
        flowDirection: dymo.label.framework.FlowDirection.LeftToRight,
        pngUseDisplayResolution: true,

        dummy: 123 // should be ignored
    };

    var paramsXml = dymo.label.framework.createLabelRenderParamsXml(params);

    var doc = Xml.parse(paramsXml);
    //alert(paramsXml);
    var labelColor = Xml.getNode(doc, "/LabelRenderParams/LabelColor");
    assertEqual(42, labelColor.getAttribute("Alpha"));
    assertEqual(43, labelColor.getAttribute("Red"));
    assertEqual(44, labelColor.getAttribute("Green"));
    assertEqual(45, labelColor.getAttribute("Blue"));

    var shadowColor = Xml.getNode(doc, "/LabelRenderParams/ShadowColor");
    assertEqual(255, shadowColor.getAttribute("Alpha"));
    assertEqual(143, shadowColor.getAttribute("Red"));
    assertEqual(144, shadowColor.getAttribute("Green"));
    assertEqual(145, shadowColor.getAttribute("Blue"));

    assertEqual("42.42", Xml.getElementText(Xml.getNode(doc, "/LabelRenderParams/ShadowDepth")));
    assertEqual("LeftToRight", Xml.getElementText(Xml.getNode(doc, "/LabelRenderParams/FlowDirection")));
    assertEqual("True", Xml.getElementText(Xml.getNode(doc, "/LabelRenderParams/PngUseDisplayResolution")));

    // no other elements
    assertEqual(5, Xml.getNodes(doc, "/LabelRenderParams/*").length);
}

function openNotExistedLabelTest()
{
    try
    {
        dymo.label.framework.openLabelFile("NotExistedLabel.label");
    }
    catch(e)
    {
        return;
    }

    throw "should not be here";

}

// when using setTextMarkup
// special xml chars should be escaped properly
function setTextSpecialChars()
{
    var b = new dymo.label.framework.LabelSetBuilder();
    var r = b.addRecord();
    var text = "&&&<>;";
    r.setText("obj", text);

    var doc = Xml.parse(b); 
    assertEqual(text, Xml.getElementText(Xml.getNode(doc, "/LabelSet/LabelRecord/ObjectData")));

}

function openLabelUrl()
{
    var l = dymo.label.framework.openLabelFile("http://labelwriter.com/software/dls/sdk/samples/js/VisitorManagement/Layouts/Layout0.label");
    assertEqual(true, l.getLabelXml().length > 0);
}


function loadImageUrl()
{
    var im = dymo.label.framework.loadImageAsPngBase64("http://labelwriter.com/software/dls/sdk/samples/js/VisitorManagement/Photos/photo2.jpg");
    assertEqual(true, im.length > 0);
}

function loadNonExistedImage()
{
    // either exception should be thrown or the result should be null
    var im;
    try
    {
        im = dymo.label.framework.loadImageAsPngBase64("some-invalid-file-name.jpg");
        assertEqual(true, !!im);
    }
    catch(e)
    {
        assertEqual(true, im == undefined);
    }

}

function loadExistingButInvalidImage()
{
    // either exception should be thrown or the result should be null
    var im;
    try
    {
        im = dymo.label.framework.loadImageAsPngBase64(_replaceFileName(document.location.href, "AllObjects.label"));
        assertEqual(true, !!im);
    }
    catch(e)
    {
        assertEqual(true, im == undefined);
    }

}

function openNonExistedLabelFile()
{
    // either exception should be thrown or the result should be null
    var label;
    try
    {
        label = dymo.label.framework.openLabelFile("some-invalid-file-name.label");
        assertEqual(true, !!label);
    }
    catch(e)
    {
        assertEqual(true, label == undefined);
    }
}

function openNonExistedLabelUrl()
{
    // either exception should be thrown or the result should be null
    var label;
    try
    {
        label = dymo.label.framework.openLabelFile("http://127.0.0.1/some-invalid-file-name.label");
        assertEqual(true, !!label);
    }
    catch(e)
    {
        assertEqual(true, label == undefined);
    }
}

function openExistingButInvalidLabel()
{
    // either exception should be thrown or the result should be null
    var label;
    try
    {
        label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "error.png"));
        assertEqual(true, !!label);
    }
    catch(e)
    {
        assertEqual(true, label == undefined);
    }
}


function setObjectText_AddressNoLineFonts()
{
    var address = "Address Text";
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXmlNoLineFonts);
    label.setObjectText("Address", address);

    
    assertEqual(address, label.getObjectText("Address"));
}

function setObjectText_AddressNoLineFontsPreserveStyle()
{
    var address = "Address Text\n2\n3\n4";
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXmlNoLineFonts);
    label.setObjectText("Address", address);

    
    assertEqual(address, label.getObjectText("Address"));

    // extract font info for the Address object
    var doc = Xml.parse(label.getLabelXml());
    var elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element/Attributes/Font');
    assertEqual("42", elem.attributes['Size'].value);
    
    // there should be four elements, ine per each line
    var elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[4]/Attributes/Font');
    assertEqual("42", elem.attributes['Size'].value);
}

function setObjectText_AddressNoLineFontsPreserveStyle2()
{
    var address = "1\n2\n3\n4\n5";
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXmlNoLineFonts2);
    label.setObjectText("Address", address);

    
    assertEqual(address, label.getObjectText("Address"));

    // extract font info for the Address object
    var doc = Xml.parse(label.getLabelXml());
    var elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element/Attributes/Font');
    assertEqual("14", elem.attributes['Size'].value);
    
    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[2]/Attributes/Font');
    assertEqual("8", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[3]/Attributes/Font');
    assertEqual("36", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[4]/Attributes/Font');
    assertEqual("18", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[5]/Attributes/Font');
    assertEqual("18", elem.attributes['Size'].value);
    
    //outputLine(label.getLabelXml());

}

function setObjectText_AddressNoLineFontsPreserveStyle3()
{
    var address = "1\n2\n3\n4\n5\n6";
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXmlNoLineFonts3);
    label.setObjectText("Address", address);

    
    assertEqual(address, label.getObjectText("Address"));

    // extract font info for the Address object
    var doc = Xml.parse(label.getLabelXml());
    var elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element/Attributes/Font');
    assertEqual("14", elem.attributes['Size'].value);
    
    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[2]/Attributes/Font');
    assertEqual("18", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[3]/Attributes/Font');
    assertEqual("8", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[4]/Attributes/Font');
    assertEqual("36", elem.attributes['Size'].value);

    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[5]/Attributes/Font');
    assertEqual("18", elem.attributes['Size'].value);
    
    elem = Xml.getNode(doc, '/DieCutLabel/ObjectInfo/AddressObject/StyledText/Element[5]/Attributes/Font');
    assertEqual("18", elem.attributes['Size'].value);

    outputLine(label.getLabelXml());

}


function setObjectText_LongLabelXml()
{
    var template = '<?xml version="1.0" encoding="utf-8"?><DieCutLabel Version="8.0" Units="twips"><PaperOrientation>Landscape</PaperOrientation><Id>Address</Id><PaperName>30252 Address</PaperName><DrawCommands><RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270" /></DrawCommands><ObjectInfo><AddressObject><Name>Address</Name><ForeColor Alpha="255" Red="0" Green="0" Blue="0" /><BackColor Alpha="0" Red="255" Green="255" Blue="255" /><LinkedObjectName></LinkedObjectName><Rotation>Rotation0</Rotation><IsMirrored>False</IsMirrored><IsVariable>True</IsVariable><HorizontalAlignment>Left</HorizontalAlignment><VerticalAlignment>Middle</VerticalAlignment><TextFitMode>ShrinkToFit</TextFitMode><UseFullFontHeight>True</UseFullFontHeight><Verticalized>False</Verticalized><StyledText><Element><String></String><Attributes><Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" /><ForeColor Alpha="255" Red="0" Green="0" Blue="0" /></Attributes></Element></StyledText><ShowBarcodeFor9DigitZipOnly>False</ShowBarcodeFor9DigitZipOnly><BarcodePosition>AboveAddress</BarcodePosition><LineFonts><Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" /><Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" /><Font Family="Arial" Size="12" Bold="False" Italic="False" Underline="False" Strikeout="False" /></LineFonts></AddressObject><Bounds X="332" Y="150" Width="4455" Height="1260" /></ObjectInfo></DieCutLabel>';
    var label = dymo.label.framework.openLabelXml(template);
    label.setObjectText('Address', '123');
    assertEqual('123', label.getObjectText('Address'));
}


function setObjectText_Tag()
{
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    label.setObjectText('Address', '<tag>123</tag>');
    assertEqual('<tag>123</tag>', label.getObjectText('Address'));
}



// register onload event
if (window.addEventListener)
    window.addEventListener("load", runTests, false);
else if (window.attachEvent)
    window.attachEvent("onload", runTests);
else
    window.onload = runTests;

