//----------------------------------------------------------------------------
//
//  $Id: VisitorManagement.js 15739 2011-08-11 15:56:29Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework
//
// Content -------------------------------------------------------------------
//
//  DYMO Label Framework JavaScript Library Samples: Preview and Print label
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------


(function()
{
    // stores loaded label info
    var _label;

    // list of available layouts
    var _layouts = [
        {url:"Layouts/Layout0.label", i:0}, 
        {url:"Layouts/Layout1.label", i:1}, 
        {url:"Layouts/Layout2.label", i:2}, 
        {url:"Layouts/Layout3.label", i:3}];

    // loads all layouts in the background
    function loadLayouts()
    {
        function loadLayout(layout)
        {
            $.get(layout.url, function(labelXml) {layout.label = dymo.label.framework.openLabelXml(labelXml);}, "text");
        }

        // skip the first layout, because it will be loaded as a default one explicitly
        for (var i = 1; i < _layouts.length; i++)
            loadLayout(_layouts[i])
    };
    loadLayouts();

    // list of available photo files
    var _photos = [
        {url:"Photos/photo0.png", dataUrl:"Photos/photo0.png.base64", data:""}, 
        {url:"Photos/photo2.jpg", dataUrl:"Photos/photo2.png.base64", data:""}];

    // loads photos data to set on label
    function loadPhotos()
    {
        function loadPhoto(photo)
        {
            $.get(photo.dataUrl, function(data) {photo.data = data;}, "text");
        }

        for (var i = 0; i < _photos.length; i++)
            loadPhoto(_photos[i]);
    };
    loadPhotos();

    // current data on the label. For simplicity we support one Text object and one Image object
    var _labelData = { text: "Name and other information" };

    // applies data to the label
    function applyDataToLabel(label, labelData)
    {
        var names = label.getObjectNames();

        for (var name in labelData)
            if (itemIndexOf(names, name) >= 0)
            label.setObjectText(name, labelData[name]);
    }

    // updates control states depend on available objects on the label
    function updateControls()
    {
        var selectPhotoButton = document.getElementById('selectPhotoButton');
        var textArea = document.getElementById('labelTextTextArea');

        var names = _label.getObjectNames();

        selectPhotoButton.disabled = itemIndexOf(names, 'photo') == -1;
        textArea.disabled = itemIndexOf(names, 'text') == -1;
    }

    // returns an index of an item in an array. Returns -1 if not found
    function itemIndexOf(array, item)
    {
        for (var i = 0; i < array.length; i++)
            if (array[i] == item) return i;

        return -1;
    }

    // loads the defualt layout at onload()
    function setupDefaultLayout()
    {
        $.get(_layouts[0].url, function(labelXml)
        {
            _layouts[0].label = dymo.label.framework.openLabelXml(labelXml);
            _label = _layouts[0].label;
        
            applyDataToLabel(_label, _labelData);
            updatePreview();
            updateControls();
        }, "text");
    }

    // updates label preview image
    // Generates label preview and updates corresponend <img> element
    // Note: this does not work in IE 6 & 7 because they don't support data urls
    // if you want previews in IE 6 & 7 you have to do it on the server side
    function updatePreview()
    {
        if (!_label)
            return;

        var printersSelect = document.getElementById('printersSelect');

        //var pngData = _label.render();
        dymo.label.framework.renderLabelAsync(
            _label, 
            function(rlr)
            {
                var labelImage = document.getElementById('labelImage');
               labelImage.src = "data:image/png;base64," + rlr.imageData;
            },
            '',
            printersSelect.value);
    }

    // called when clicked on a photo
    function photoClick(e)
    {
        try
        {
        var overlay = document.getElementById('dialog-overlay');
        var wrapper = document.getElementById('dialog-wrapper');

        var targ;
        var ee = e;
        if (!ee)
            ee = window.event;

        if (ee.target)
        {
            targ = ee.target;
        }
        else if (ee.srcElement)
        {
            targ = ee.srcElement;
        }
        if (targ.nodeType == 3) // defeat Safari bug
        {
            targ = targ.parentNode;
        }

        // save selected photo
        //var url = targ.src;
        //if (url.indexOf('file://localhost') == 0)
        //    url = url.replace('file://localhost', 'file://');
        //_labelData.photo = dymo.label.framework.loadImageAsPngBase64(url);
        _labelData.photo = _photos[targ.imageIndex].data;

        // update label
        applyDataToLabel(_label, _labelData);
        updatePreview();

        // close dialog
        wrapper.style.display = "none";
        overlay.style.display = "none";
        }
        catch(e)
        {
            alert(e || e.message);
        }
    }

    // set "dialog" caption 
    function dialogSetCaption(caption)
    {
        header = document.getElementById('dialog-header');

        // remove old caption
        while (header.firstChild)
            header.removeChild(header.firstChild);

        // set new caption
        header.appendChild(document.createTextNode(caption));
    }

    // event handler for selectPhotoButton.onclick event
    function selectPhotoButtonClick()
    {
        try
        {
        var overlay = document.getElementById('dialog-overlay');
        var wrapper = document.getElementById('dialog-wrapper');
        var content = document.getElementById('dialog-content');


        // remove old content
        while (content.firstChild)
            content.removeChild(content.firstChild);

        // add photos
        for (var i = 0; i < _photos.length; i++)
        {
            var a = document.createElement('a');
            //a.setAttribute("class", "photo");
            a.className = "photo";
            a.href = "javascript:void(0)";
            var img = document.createElement('img');
            //img.setAttribute("class", "photo");
            //img.className = "photo";
            img.src = _photos[i].url;
            img.imageIndex = i; // remember index to be able to access image data as base64

            // this is to set the height to 100px. Just setting height is css does not work in IE
            //var height = 150;
            //img.width = img.width / img.height * height;
            //img.height = height;

            img.onclick = photoClick;
            //img.class = "photo";

            a.appendChild(img);
            content.appendChild(a);
        }

        // show dialog
        dialogSetCaption("Select Photo");
        overlay.style.display = "block";
        wrapper.style.display = "block";
        }
        catch(e)
        {
            alert(e || e.message);
        }
    }

    // called when clicked on a layout
    function layoutClick(e)
    {
        var overlay = document.getElementById('dialog-overlay');
        var wrapper = document.getElementById('dialog-wrapper');

        var targ;
        var ee = e;
        if (!ee)
            ee = window.event;

        if (ee.target)
        {
            targ = ee.target;
        }
        else if (ee.srcElement)
        {
            targ = ee.srcElement;
        }
        if (targ.nodeType == 3) // defeat Safari bug
        {
            targ = targ.parentNode;
        }

        // update label
        _label = targ.labelLayout;
        updatePreview();
        updateControls();

        // close dialog
        wrapper.style.display = "none";
        overlay.style.display = "none";
    }

    // event handler for selectPhotoButton.onclick event
    function changeLayoutButtonClick()
    {
        var overlay = document.getElementById('dialog-overlay');
        var wrapper = document.getElementById('dialog-wrapper');
        var content = document.getElementById('dialog-content');

        // remove old content
        while (content.firstChild)
            content.removeChild(content.firstChild);

        var printersSelect = document.getElementById('printersSelect');

        // add layouts
        var layouts = _layouts;

        var loadLayoutImage = function(layout, img)
        {
            dymo.label.framework.renderLabelAsync(
                layout,
                function(rlr)
                {
                    img.src = "data:image/png;base64," + rlr.imageData;
                    img.onclick = layoutClick;

                    // remember the layout as well to update _label when clicked on it
                    img.labelLayout = layout;
                },
                '',
                printersSelect.value);
            
        }

        for (var i = 0; i < layouts.length; i++)
        {
            // set layout data
            var layout = layouts[i].label;
            if (layout) // might be not loaded yet
            {
                applyDataToLabel(layout, _labelData);

                var a = document.createElement('a');
                //a.setAttribute("class", "photo");
                a.className = "layout";
                a.href = "javascript:void(0)";
                var img = document.createElement('img');
                //img.src = "data:image/png;base64," + layout.render();
                //dymo.label.framework.renderLabelAsync(
                //    layout,
                //    function(rlr)
                //    {
                //        img.src = "data:image/png;base64," + rlr.imageData;
                //        img.onclick = layoutClick;

                //        // remember the layout as well to update _label when clicked on it
                //        img.labelLayout = layout;
                //    },
                //    '',
                //    printersSelect.value);
                loadLayoutImage(layout, img);



                a.appendChild(img);
                content.appendChild(a);
            }
        }

        // add a dummy div to clear layout's float:left style
        var d = document.createElement('div');
        d.style.clear = "both";
        content.appendChild(d);

        // show dialog
        dialogSetCaption("Select Layout");
        overlay.style.display = "block";
        wrapper.style.display = "block";
    }


    // called when the document completly loaded
    function onload()
    {
        try
        {
        //var labelFile = document.getElementById('labelFile');
        var labelTextTextArea = document.getElementById('labelTextTextArea');
        var printersSelect = document.getElementById('printersSelect');
        var printButton = document.getElementById('printButton');
        var selectPhotoButton = document.getElementById('selectPhotoButton');
        var changeLayoutButton = document.getElementById('changeLayoutButton');


        var addNetworkPrinterButton = document.getElementById('addNetworkPrinterButton');
        var networkPrinterUriInput = document.getElementById('networkPrinterUriInput');

        // initialize controls
        //printButton.disabled = true;
        //addressTextArea.disabled = true;
        if (_labelData.text)
            labelTextTextArea.value = _labelData.text;

        // loads all supported printers into a combo box 
        function loadPrinters()
        {
            // clear first
            while (printersSelect.firstChild) 
                printersSelect.removeChild(printersSelect.firstChild);

            var printers = dymo.label.framework.getPrinters();
            //if (printers.length == 0)
            //{
            //    alert("No DYMO printers are installed. Install DYMO printers.");
            //    return;
            //}

            for (var i = 0; i < printers.length; i++)
            {
                if (printers[i].printerType != "LabelWriterPrinter") continue;

                var printerName = printers[i].name;

                var option = document.createElement('option');
                option.value = printerName;
                option.appendChild(document.createTextNode(printerName));
                printersSelect.appendChild(option);
            }
        };

        // updates address on the label when user types in textarea field
        labelTextTextArea.onkeyup = function()
        {
            if (!_label)
            {
                alert('Load label before entering text');
                return;
            }

            // set labelData
            _labelData.text = labelTextTextArea.value;
            applyDataToLabel(_label, _labelData);
            updatePreview();
        }

        // prints the label
        printButton.onclick = function()
        {
            if (!_label)
            {
                alert("Load label before printing");
                return;
            }

            //alert(printersSelect.value);
            _label.print(printersSelect.value);
        }

        addNetworkPrinterButton.onclick = function()
        {
            dymo.label.framework.addPrinterUri(networkPrinterUriInput.value, '',
                function()
                {
                    loadPrinters();
                },
                function(printerUri)
                {
                    alert('Unable to connect to "' + printerUri + '"');
                });
        }

        selectPhotoButton.onclick = selectPhotoButtonClick;
        changeLayoutButton.onclick = changeLayoutButtonClick;

        // onload() initialization
        setupDefaultLayout();
        loadPrinters();
        //updatePreview();
        //updateControls();
        }
        catch(e)
        {
            alert(e || e.message);
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