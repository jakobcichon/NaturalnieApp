//----------------------------------------------------------------------------
//
//  $Id: FunctionalTests.js 15948 2011-09-01 23:07:55Z vbuzuev $ 
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

// utility test functions

/// replaces the last component of the url with fileName
function _replaceFileName(url, fileName)
{
    var i = url.lastIndexOf('/');
    return url.substr(0, i + 1) + fileName;
}


function outputLine(text)
{
    var elem = document.createElement("div");
    elem.appendChild(document.createTextNode(text));

    document.getElementById("testsContainer").appendChild(elem);
}

// unit tests support

var _tests = {}

_tests["getPrintersTest"] = getPrintersTest;
_tests["getPrinterByName"] = getPrinterByName;
_tests["printLabelTest_450Turbo"] = printLabelTest_450Turbo;
_tests["printLabelTest_DuoLabel"] = printLabelTest_DuoLabel;
_tests["renderLabelTest"] = renderLabelTest;
_tests["openLabelXmlTest"] = openLabelXmlTest;
_tests["labelRenderTest"] = labelRenderTest;
_tests["labelRenderWithPrinterResolutionTest"] = labelRenderWithPrinterResolutionTest;
_tests["labelSetObjectTextTest"] = labelSetObjectTextTest;

_tests["printLabelWriterLabelWithParamsTest_450Turbo"] = printLabelWriterLabelWithParamsTest_450Turbo;
_tests["printLabelWriterLabelWithParamsTest_DuoLabel"] = printLabelWriterLabelWithParamsTest_DuoLabel;

_tests["printWithLabelSetTest_450Turbo"] = printWithLabelSetTest_450Turbo;
_tests["printWithLabelSetTest_DuoLabel"] = printWithLabelSetTest_DuoLabel;

_tests["printBarcodeLabelWithLabelSetTest_450Turbo"] = printBarcodeLabelWithLabelSetTest_450Turbo;
_tests["printBarcodeLabelWithLabelSetTest_DuoLabel"] = printBarcodeLabelWithLabelSetTest_DuoLabel;

_tests["printFlagLabelTest_DuoTape128"] = printFlagLabelTest_DuoTape128;
_tests["printFlagLabelTest_DuoTape"] = printFlagLabelTest_DuoTape;

_tests["printFlagLabelTest2_DuoTape128"] = printFlagLabelTest2_DuoTape128;
_tests["printFlagLabelTest2_DuoTape"] = printFlagLabelTest2_DuoTape;


_tests["printLabelTest_450"] = printLabelTest_450;


//_tests["failedTest"] = failedTest;


function runTests()
{
    for (testName in _tests)
        runTest(_tests[testName], testName);
    //getPrintersTest();
}

function runTest(testFunction, testName)
{
    try
    {
        testFunction();
    }
    catch (e)
    {
        outputLine(testName + " failed: " + e);
        // this is for IE 6&7
//        if (e.message)
        //    outputLine(testName + ": ERROR: " + e.message);
//        if (e.description)
        //    outputLine(testName + ": ERROR: " + e.description);
    }
}

//////////////////////////////////////////////////
// functional tests
//////////////////////////////////////////////////

function getPrintersTest()
{
    //outputLine("getPrintersTest()");

    var printers = dymo.label.framework.getPrinters();

    // Create the <table> element
    var table = document.createElement("table");

    
    // Create the header row of <th> elements in a <tr> in a <thead>
    var thead = document.createElement("thead");
    var header = document.createElement("tr");

    var createTableHeader = function(name)
    {
        var cell = document.createElement("th");
        cell.appendChild(document.createTextNode(name));
        header.appendChild(cell);
    };
    createTableHeader("Type");
    createTableHeader("Name");
    createTableHeader("ModelName");
    createTableHeader("IsLocal");
    createTableHeader("IsConnected");
    createTableHeader("IsTwinTurbo");
    createTableHeader("IsAutoCutSupported");

    // Put the header into the table
    thead.appendChild(header);
    table.appendChild(thead);

    // The remaining rows of the table go in a <tbody>
    var tbody = document.createElement("tbody");
    table.appendChild(tbody);

    // Loop through all printers. Each one contains a row of the table
    var createPrinterRow = function(printer, row, propertyName)
    {
        var cell = document.createElement("td");

        // Put the text data into the HTML cell
        if (typeof printer[propertyName] != "undefined")
            cell.appendChild(document.createTextNode(printer[propertyName]));
        else
            cell.appendChild(document.createTextNode("n/a"));

        // Add the cell to the row
        row.appendChild(cell);
    };

    for (var r = 0; r < printers.length; r++)
    {
        // This is the XML element that holds the data for the row
        var printer = printers[r];
        // Create an HTML element to display the data in the row
        var row = document.createElement("tr");

        createPrinterRow(printer, row, "printerType");
        createPrinterRow(printer, row, "name");
        createPrinterRow(printer, row, "modelName");
        createPrinterRow(printer, row, "isLocal");
        createPrinterRow(printer, row, "isConnected");
        createPrinterRow(printer, row, "isTwinTurbo");
        createPrinterRow(printer, row, "isAutoCutSupported");

        // And add the row to the tbody of the table
        tbody.appendChild(row);
    }

    // Set an HTML attribute on the table element by setting a property.
    // Note that in XML we must use setAttribute() instead.
    //table.frame = "border";

    document.getElementById("testsContainer").appendChild(table);
}

function getPrinterByName()
{
    var printers = dymo.label.framework.getPrinters();

    for (var i = 0; i < printers.length; i++)
    {
        var printer = printers[i];
        var printerByName = printers[printer.name];
        if (!printerByName)
            throw new Error("Printer '" + printer.name + "' is not found");
    }
}

function failedTest()
{
    throw new Error("error message");
}

var gTestBarcodeLabelXml = '<?xml version="1.0" encoding="utf-8"?>\
    <DieCutLabel Version="8.0" Units="twips">\
        <PaperOrientation>Landscape</PaperOrientation>\
        <Id>Address</Id>\
        <PaperName>30252 Address</PaperName>\
        <DrawCommands>\
            <RoundRectangle X="0" Y="0" Width="1581" Height="5040" Rx="270" Ry="270"/>\
        </DrawCommands>\
        <ObjectInfo>\
            <BarcodeObject>\
                <Name>BARCODE</Name>\
                <ForeColor Alpha="255" Red="0" Green="0" Blue="0"/>\
                <BackColor Alpha="255" Red="255" Green="255" Blue="255"/>\
                <LinkedObjectName></LinkedObjectName>\
                <Rotation>Rotation0</Rotation>\
                <IsMirrored>False</IsMirrored>\
                <IsVariable>False</IsVariable>\
                <Text>00000000</Text>\
                <Type>Code2of5</Type>\
                <Size>Medium</Size>\
                <TextPosition>Bottom</TextPosition>\
                <TextFont Family="Arial" Size="10" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                <CheckSumFont Family="Lucida Grande" Size="10" Bold="False" Italic="False" Underline="False" Strikeout="False"/>\
                <TextEmbedding>None</TextEmbedding>\
                <ECLevel>0</ECLevel>\
                <HorizontalAlignment>Center</HorizontalAlignment>\
                <QuietZonesPadding Left="0" Right="0" Top="0" Bottom="0"/>\
            </BarcodeObject>\
            <Bounds X="3340.8" Y="403.2" Width="1598.4" Height="1051.2"/>\
         </ObjectInfo>\
    </DieCutLabel>';

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

var gTestAddressLabelNoLineFontsXml = '<?xml version="1.0" encoding="utf-8"?>\
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
                            <Font Family="Arial" Size="24" Bold="False" Italic="True" Underline="False" Strikeout="False" />\
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

function printLabelTestForPrinterName(printerName)
{
    outputLine("printLabelTest");

    var printers = dymo.label.framework.getPrinters();
    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    outputLine("printLabel(): print address label on '" + printerName + "'");
    dymo.label.framework.printLabel(printerName, "", gTestAddressLabelXml, "");
}

function printLabelTestForPrinterNameNoLineFonts(printerName, text)
{
    outputLine("printLabelTestForPrinterNameNoLineFonts");

    var printers = dymo.label.framework.getPrinters();
    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    outputLine("printLabelTestForPrinterNameNoLineFonts(): print address label on '" + printerName + "'");
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelNoLineFontsXml);
    //var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    
    label.setAddressText(0, text);
    outputLine(label.getLabelXml());
    label.print(printerName);
}


function printLabelTest_450()
{
    printLabelTestForPrinterNameNoLineFonts("DYMO LabelWriter 450", "1\n2\n3\n4");
}

function printLabelTest_450Turbo()
{
    printLabelTestForPrinterName("DYMO LabelWriter 450 Turbo");
}

function printLabelTest_DuoLabel()
{
    printLabelTestForPrinterName("LabelWriter DUO Label");
}


function printLabelWriterLabelWithParamsTestForPrinterName(printerName)
{
    outputLine("printLabelWriterLabelWithParamsTest");

    var printers = dymo.label.framework.getPrinters();

    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    outputLine("printLabel(): print address label on '" + printerName + "' in Barcode&Graphics quality");

    var printParams =
    {
        jobTitle: "Label Test"
    };
    
//    var printParams = {}; 
    printParams.printQuality = dymo.label.framework.LabelWriterPrintQuality.BarcodeAndGraphics;
    dymo.label.framework.printLabel(printerName, dymo.label.framework.createLabelWriterPrintParamsXml(printParams), gTestAddressLabelXml, "");
}

function printLabelWriterLabelWithParamsTest_450Turbo()
{
    printLabelWriterLabelWithParamsTestForPrinterName("DYMO LabelWriter 450 Turbo");
}

function printLabelWriterLabelWithParamsTest_DuoLabel()
{
    printLabelWriterLabelWithParamsTestForPrinterName("LabelWriter DUO Label");
}


function printWithLabelSetTestForPrinterName(printerName)
{
    outputLine("printWithLabelSetTest");

    var printers = dymo.label.framework.getPrinters();
    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    outputLine("selected printer: " + printerName);

    outputLine("printLabel(): print address label on '" + printerName + "' with label set");

    var labelSet = new dymo.label.framework.LabelSetBuilder();
    var record = labelSet.addRecord();
    record.setText("Address", "Address 1");
    record = labelSet.addRecord();
    record.setText("Address", 42); // int should work as well
    
    dymo.label.framework.printLabel(printerName, "", gTestAddressLabelXml, labelSet);
}

function printWithLabelSetTest_450Turbo()
{
    printWithLabelSetTestForPrinterName("DYMO LabelWriter 450 Turbo");
}

function printWithLabelSetTest_DuoLabel()
{
    printWithLabelSetTestForPrinterName("LabelWriter DUO Label");
}

function printBarcodeLabelWithLabelSetTestForPrinterName(printerName)
{
    outputLine("printBarcodeLabelWithLabelSet");

    var printers = dymo.label.framework.getPrinters();
    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    outputLine("selected printer: " + printerName);

    outputLine("printLabel(): print address label on '" + printerName + "' with label set");

    var labelSet = new dymo.label.framework.LabelSetBuilder();
    var record = labelSet.addRecord();
    record.setText("BARCODE", "10000002");
    
    dymo.label.framework.printLabel(printerName, "", gTestBarcodeLabelXml, labelSet);
}

function printBarcodeLabelWithLabelSetTest_450Turbo()
{
    printBarcodeLabelWithLabelSetTestForPrinterName("DYMO LabelWriter 450 Turbo");
}

function printBarcodeLabelWithLabelSetTest_DuoLabel()
{
    printBarcodeLabelWithLabelSetTestForPrinterName("LabelWriter DUO Label");
}

function printFlagLabelTestForPrinterName(printerName)
{
    outputLine("printFlagLabelTest(): print tape label on '" + printerName + "' Labels should be printed without cutting");

    var printers = dymo.label.framework.getPrinters();

    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");

    var labelSet = new dymo.label.framework.LabelSetBuilder();
    var record = labelSet.addRecord();
    record.setTextMarkup("LeftText", "<font family='Arial' size='14'><i>Measurement 1:<br/></i></font><b><font size='10'>passed</font></b>");
    record = labelSet.addRecord();
    record.setTextMarkup("LeftText", "<font family='Arial' size='14'><i>Measurement 2:<br/></i></font><b><u><font size='10'>failed</font></u></b>");
    record.setText("LeftImage", dymo.label.framework.loadImageAsPngBase64(_replaceFileName(document.location.href, "error.png")));

    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "Flag.label"));
    //alert(labelSet);
    var printParamsXml = dymo.label.framework.createTapePrintParamsXml(
    {
        jobTitle: "Flag Label Test",
        cutMode: dymo.label.framework.TapeCutMode.ChainMarks
    });
    label.print(printerName, printParamsXml, labelSet);
}

function printFlagLabelTest_DuoTape128()
{
    printFlagLabelTestForPrinterName("DYMO LabelWriter DUO Tape 128");
}

function printFlagLabelTest_DuoTape()
{
    printFlagLabelTestForPrinterName("LabelWriter DUO Tape");
}


function printFlagLabelTest2ForPrinterName(printerName)
{
    outputLine("printFlagLabelTest2(): print tape label on '" + printerName + "' Labels should be printed cutted. Also it changed the tape width to 12mm by direct manipulation of label's xml" );

    var printers = dymo.label.framework.getPrinters();

    if (!printers[printerName])
        throw new Error("Printer '" + printerName + "' is not found");
    
    var labelSet = new dymo.label.framework.LabelSetBuilder();
    var record = labelSet.addRecord();
    record.setText("LeftText", "Measurement 3:\npassed");
    record = labelSet.addRecord();
    record.setText("LeftText", "Measurement 4:\npassed");

    var labelXml = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "Flag.label")).getLabelXml();
    var labelDoc = Xml.parse(labelXml);

    // change tape width to 12mm
    Xml.setElementText(Xml.getNode(labelDoc, "/ContinuousLabel/PaperName"), "12mm");

    labelXml = Xml.serialize(labelDoc);

    var printParamsXml = dymo.label.framework.createTapePrintParamsXml(
    {
        jobTitle: "Flag Label Test",
        cutMode: dymo.label.framework.TapeCutMode.AutoCut
    });

    dymo.label.framework.printLabel(printerName, printParamsXml, labelXml, labelSet);
}

function printFlagLabelTest2_DuoTape128()
{
    printFlagLabelTest2ForPrinterName("DYMO LabelWriter DUO Tape 128");
}

function printFlagLabelTest2_DuoTape()
{
    printFlagLabelTest2ForPrinterName("LabelWriter DUO Tape");
}

function renderLabelTest()
{
    outputLine("renderLabelTest()");
    var image = document.createElement('img');
    var pngData = dymo.label.framework.renderLabel(gTestAddressLabelXml, "", "DYMO LabelWriter 450 Turbo");
    image.src = "data:image/png;base64," + pngData;

    var container = document.getElementById("testsContainer");
    container.appendChild(document.createTextNode('actual:'));
    document.getElementById("testsContainer").appendChild(image);
    container.appendChild(document.createTextNode('expected:'));
    var img = document.createElement('img');
    img.src = "FunctionalTestFiles/renderLabelTest.png";
    container.appendChild(img);
}


function openLabelXmlTest()
{
    outputLine("openLabelXmlTest()");
    var image = document.createElement('img');
    var label = dymo.label.framework.openLabelXml(gTestAddressLabelXml);
    //label.setObjectText("Address", "Hello, World!\n42");
    var pngData = dymo.label.framework.renderLabel(label);
    image.src = "data:image/png;base64," + pngData;

    var container = document.getElementById("testsContainer");
    container.appendChild(document.createTextNode('actual:'));
    document.getElementById("testsContainer").appendChild(image);
    container.appendChild(document.createTextNode('expected:'));
    var img = document.createElement('img');
    img.src = "FunctionalTestFiles/openLabelXmlTest.png";
    container.appendChild(img);
}

function labelRenderTest()
{
    outputLine("labelRenderTest()");
    var image = document.createElement('img');
    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "Address2Up.label"));
    label.setAddressText(0, "42");
    label.setAddressText(1, "42 42");
    var pngData = label.render();
    image.src = "data:image/png;base64," + pngData;

    var container = document.getElementById("testsContainer");
    container.appendChild(document.createTextNode('actual:'));
    document.getElementById("testsContainer").appendChild(image);
    container.appendChild(document.createTextNode('expected:'));
    var img = document.createElement('img');
    img.src = "FunctionalTestFiles/labelRenderTest.png";
    container.appendChild(img);
}

function labelRenderWithPrinterResolutionTest()
{
    outputLine("labelRenderWithPrinterResolutionTest()");
    var image = document.createElement('img');
    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "AllObjectsDiffFonts.label"));
    label.setObjectText("TEXT", "123עִבְרִית");
    var pngData = label.render(dymo.label.framework.createLabelRenderParamsXml({ pngUseDisplayResolution: false, flowDirection: "RightToLeft" }));
    image.src = "data:image/png;base64," + pngData;

    var container = document.getElementById("testsContainer");
    container.appendChild(document.createTextNode('actual:'));
    document.getElementById("testsContainer").appendChild(image);
    container.appendChild(document.createTextNode('expected:'));
    var img = document.createElement('img');
    img.src = "FunctionalTestFiles/labelRenderWithPrinterResolutionTest.png";
    container.appendChild(img);
}

function labelSetObjectTextTest()
{
    outputLine("labelSetObjectTextTest(): setObjectText() for all object types");
    var label = dymo.label.framework.openLabelFile(_replaceFileName(document.location.href, "AllObjectsDiffFonts.label"));

    label.setObjectText("BARCODE", "42");
    label.setObjectText("CURVED-TEXT", "434343434343");

    label.setObjectText("TEXT", "44");
    label.setObjectText("ADDRESS", "1\r\n2\r\n3");

    var pngData = dymo.label.framework.loadImageAsPngBase64(_replaceFileName(document.location.href, "error.png"));
    label.setObjectText("GRAPHIC", pngData);

    label.setObjectText("DATE-TIME", "45 ");
    label.setObjectText("COUNTER", "46 ");

    label.setObjectText("SHAPE", "47"); // does nothing

    var image = document.createElement('img');
    var pngData = dymo.label.framework.renderLabel(label);
    image.src = "data:image/png;base64," + pngData;

    var container = document.getElementById("testsContainer");
    container.appendChild(document.createTextNode('actual:'));
    document.getElementById("testsContainer").appendChild(image);
    container.appendChild(document.createTextNode('expected:'));
    var img = document.createElement('img');
    img.src = "FunctionalTestFiles/labelSetObjectTextTest.png";
    container.appendChild(img);
        
//    var div = document.createElement('div');
//    var t = document.createTextNode(label);
//    div.appendChild(t);
//    document.getElementById("testsContainer").appendChild(div);
}



// register onload event
if (window.addEventListener)
    window.addEventListener("load", runTests, false);
else if (window.attachEvent)
    window.attachEvent("onload", runTests);
else
    window.onload = runTests;
