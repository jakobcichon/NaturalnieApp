DLS SDK Samples Read Me
Revision: 3
Date: 12/01/2011


****************************************************************** 
1. Overview
*************

The samples demonstrate how to use both the High Level and Low Level 
COM interfaces documented in the DLS SDK Manual. These samples can 
run as is without rebuilding on client systems with DLS 7 or DYMO Label v.8 
installed. This demonstrates the "binary compatible" implementation 
of the DLS SDK COM Library.

32 Bit Library
Because the DLS SDK COM Library is a 32-bit library, the samples 
are compiled to target x86 platforms and will run as Wow6432 applications 
under 64-bit operating systems.

Note: Use the 32-bit version of Internet Explorer (IE) to run the IE 
samples on 64-bit operating systems with both 32-bit and 64-bit versions 
of IE installed. The ActiveX controls used in the sample scripts are 32-bit 
only, so the controls will not load in the 64-bit version of IE.

****************************************************************** 
2. Sample Files in the SDK
***************************

Below is a short description of all files installed by the SDK:

2.1. "High Level COM"
The "High Level COM" folder contains sample code that uses the high-
level COM interface of the SDK. 

The sample applications show how to open a label file, set data on label 
objects that are on the label file, and print the label. This is by far 
the most common application for the DYMO SDK.

2.1.a "dotNET Samples"
.Net sample projects are created by referencing the DLS SDK COM Library.
You can run the sample applications (i.e.the .exe with either DLS 7 or DYMO Label v.8.2+ installed). 
However, to compile and build the sample projects, you will need to have DYMO Label v.8.2+ installed.

Samples are provided in ASP.NET, VB.NET and C#. Samples illustrate roll 
selection in the LabelWriter Twin Turbo printer. 

2.1.b "MS Access"
The sample provided prints labels from a customer database.

2.1.c "Visual C++ (Command Line)"
This sample illustrates printing a label from a Command Line.

2.1.d "Visual C++ (Smart Paste)"
To illustrate the Smart Paste functionality (a patented DYMO technology), 
we have provided a sample written in C++ that allows you to Smart Paste 
data from the Clipboard or a comma delimited file. 

2.1.e "Visual C++ (Twin Turbo Printing)"
This sample illustrates roll selection in the LabelWriter Twin Turbo printer. 

2.2. "Low Level COM"
The "Low Level COM" folder contains sample code that uses the low-level 
COM interface in the SDK. The interface provides complete access to the 
same data and objects used to implement the DLS application, but the 
learning curve is steeper compared to using the High Level COM interface. 
If your application just needs to print a label quickly, consider using 
the High Level COM interface first.

If you do decide to use the Low Level COM interface, the new implementation 
allows you to mix High Level COM and Low Level COM interfaces within the 
same program code. For example, if you open a label file using the High Level 
COM interface, you can assume the same file is opened in the Low Level COM 
interface and therefore use the functionalities in the Low Level COM 
interface to modify the label opened using the High Level COM interface.

2.2.b "Visual C++ sample"
The sample shows how to open a label file, create and modify label objects on the 
label, and render the label on the screen.

2.3. "Paper Size"
The "Paper Size" folder contains VB sample code that shows you how to
select a paper size in a printer driver when printing using Windows
API.






