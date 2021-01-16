using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;
using static NaturalnieApp.Program;

namespace ElzabDriver
{
    public class ElzabCommHeaderObject
    {
        public ElzabCommElementObject HeaderLine1 { get; set; }
        public ElzabCommElementObject HeaderLine2 { get; set; }
        public ElzabCommElementObject HeaderLine3 { get; set; }

        public ElzabCommHeaderObject()
        {
            this.HeaderLine1 = new ElzabCommElementObject();
            this.HeaderLine2 = new ElzabCommElementObject();
            this.HeaderLine3 = new ElzabCommElementObject();
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public enum FileType
    {
        InputFile, OutputFile, ConfigFile, ReportFile
    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabFileObject : ElzabCommandFileHandling
    {
        private string AttributesSeparator { get; set; }
        private string HeaderMark { get; set; }
        private string HeaderSeparator { get; set; }
        private string CommentMark { get; set; }
        private string ElementMark { get; set; }
        private string AdditionMarkForConfigFile { get; set; }
        private string Path { get; }
        private string BackupPath { get; }
        private string CommandName { get; }
        private FileType TypeOfFile { get; }
        public ElzabCommHeaderObject Header { get; set; }
        private ElzabCommElementObject Element { get; set; }
        private List<string> RawData { get; set; }
        private string AttributeNameAsID { get; set; }
        private int NrOfCharsInElementAttribute { get; set; }
        private string FileNameWithExtension { get; set; }

        //Class constructor
        public ElzabFileObject()
        {

        }

        public ElzabFileObject(string path, string commandName, FileType typeOfFile, int cashRegisterID,
            string headerPatternLine1 = "< cash_register_number > < cash_register_comm_data > < comm_timeout > <execution_date >" +
            "< execution_time > < command_name > < version_number> < input_file_name > <output_file_name>", 
            string headerPatternLine2 = " < error_number > < error_text > ", string headerPatternLine3 = " <cash_register_id > ",
            string elementAttributesPattern = " < empty_element>", string attributeNameAsID = "", int nrOfCharsInElementAttribute = 34)
        {

            //Initialize object variables
            this.Path = System.IO.Path.Combine(path, commandName);
            this.BackupPath = System.IO.Path.Combine(this.Path, "Backup");
            this.CommandName = commandName;
            this.TypeOfFile = typeOfFile;
            this.FileNameWithExtension = FileNameDependingOfType(this.CommandName, this.TypeOfFile);
            base.SetEncoding();

            //Create instance of Raw data object
            this.RawData = new List<string>();
            
            //Call method used to set marks and separators
            SetMarksAndSeparators();

            //Create instance of header object and initialize it
            if (this.TypeOfFile != FileType.ConfigFile)
            {
                this.Header = new ElzabCommHeaderObject();
                this.Header.HeaderLine1.AddAttributesFromList(ParsePattern(headerPatternLine1));
                this.Header.HeaderLine2.AddAttributesFromList(ParsePattern(headerPatternLine2));
                this.Header.HeaderLine3.AddAttributesFromList(ParsePattern(headerPatternLine3));
                if (typeOfFile == FileType.InputFile)
                {
                    //Initialize basic header information
                    this.Header.HeaderLine1.AddElement();
                    this.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
                    this.Header.HeaderLine2.AddElement();
                    this.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
                    this.Header.HeaderLine3.AddElement();
                    this.Header.HeaderLine3.ChangeAttributeValue(0, "", "");
                }
            }

            //Create instance of element object and initialize it
            this.Element = new ElzabCommElementObject();
            if (elementAttributesPattern == "") elementAttributesPattern = "< empty_element >";
            this.Element.AddAttributesFromList(ParsePattern(elementAttributesPattern));

            //attributeNameAsID specify with attribute must be consider as ID number of element
            //If attributeNameAsID was not secified, it will take attribute name from index 0
            if (attributeNameAsID == "")
            {
                this.AttributeNameAsID = this.Element.GetAttributNameOfIndex(0);
            }
            else
            {
                this.AttributeNameAsID = attributeNameAsID;
            }

            //nrOfCharsInElementAttribute specify number of char of each element attribute
            //If given element attribute value is shorter then, nrOfCharsInElementAttribute it will be fill with 0x20 (space)
            this.NrOfCharsInElementAttribute = nrOfCharsInElementAttribute;

        }

        //Method used to set basic information about file
        public void SetMarksAndSeparators(char attributeSeparator = '\t', char headerMark = '#',
                                        char headerSeparator = '\t', char commentMark = ';',
                                        char elementMark = '$', char additionmarkforConfigFile = '\t')
        {
            //Set values to variables
            this.AttributesSeparator = attributeSeparator.ToString();
            this.HeaderMark = headerMark.ToString();
            this.HeaderSeparator = headerSeparator.ToString();
            this.CommentMark = commentMark.ToString();
            this.ElementMark = elementMark.ToString();
            this.AdditionMarkForConfigFile = additionmarkforConfigFile.ToString();
        }

        //Method used only for config file
        public string GenerateConnectionData(int comPortNumber, int baudRate)
        {
            //Local variable
            string retVal = "";

            bool checkBaudRate = CheckBaudRateValue(baudRate);

            if (comPortNumber > - 1 && checkBaudRate)
            {
                string connectionData = "COM" + comPortNumber + ":" + baudRate + ":" + "MUX0:1";
                retVal = connectionData;
            }
            else
            {
                MessageBox.Show("Baud rate lub numer portu COM ma niewłaściwą wartość! " + baudRate + " " + comPortNumber);
            }

            return retVal;

        }

        private bool CheckBaudRateValue(int baudRate)
        {
            //Return value
            bool retVal = false;

            //List of allowed baudrates
            int[] baudRatesList = { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 230400, 460800 };
            foreach (int element in baudRatesList)
            {
                if (element == baudRate)
                {
                    retVal = true;
                    break;
                }
            }

            return retVal;
        }

        public void GenerateObjectFromRawData()
        {
            //Define local variable
            int i = 0;

            //Read raw data from file
            this.RawData = ReadDataFromFile(this.Path, this.CommandName, this.TypeOfFile);

            //Parse data
            //Define header pattern
            Regex regPatternHeader = new Regex(@"^" + this.HeaderMark + ".*$");

            //Define elements pattern
            Regex regPatternElements = new Regex(@"^" + this.ElementMark + ".*$");

            foreach (string element in this.RawData)
            {


                //Parse header
                //Check if current element match to the pattern
                if (regPatternHeader.IsMatch(element))
                {
                    //Local variable
                    string clearedElement;
                    //Remove mark sign
                    clearedElement = element.Replace(this.HeaderMark, "");

                    //Switch to find proper header Line
                    switch (i)
                    {
                        case 0:
                            this.Header.HeaderLine1.AddElement();
                            this.Header.HeaderLine1.StringListToAttributesValue(0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                        case 1:
                            this.Header.HeaderLine2.AddElement();
                            this.Header.HeaderLine2.StringListToAttributesValue(0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                        case 2:
                            this.Header.HeaderLine3.AddElement();
                            this.Header.HeaderLine3.StringListToAttributesValue(0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                    }

                    i++;
                }

                //Parse elements
                if (regPatternElements.IsMatch(element))
                {
                    //Local variable
                    string clearedElement;

                    //Remove mark sign
                    clearedElement = element.Replace(this.ElementMark.Replace("\\",""), "");

                    //Read every element and add it to an object
                    this.Element.AddElement();
                    this.Element.StringListToAttributesValue(this.Element.GetLastElementID(), ParseStringToList(clearedElement, this.AttributesSeparator));
                }
            }
        }

        //Method used to prepare data from object, save it to file and run command
        public bool RunCommand()
        {
            //Local variables
            bool retVal = false;

            try
            {
                //Check if command file exist
                string execFullFilePath = System.IO.Path.Combine(this.Path, this.CommandName + ".exe");
                bool commandExist = File.Exists(execFullFilePath);

                //If not exist try to copy one from command default path
                if (!commandExist)
                {
                    string defaultPathWithCommandName = System.IO.Path.Combine(GlobalVariables.ElzabCommandPath, "Commands", this.CommandName + ".exe");
                    File.Copy(defaultPathWithCommandName, execFullFilePath);
                }

                //Check again
                commandExist = File.Exists(execFullFilePath);

                //Check if dll exist in command directory
                string dllFullFilePath = System.IO.Path.Combine(this.Path, "WinIP.dll");
                bool dllExist = File.Exists(dllFullFilePath);
                if (!dllExist)
                {
                    string defaultPathWithDlls = System.IO.Path.Combine(this.Path, System.IO.Path.Combine(GlobalVariables.LibraryPath, "WinIP.dll"));
                    File.Copy(defaultPathWithDlls, dllFullFilePath);
                    dllExist = true;
                }

                if (commandExist && dllExist)
                {
                    //Generate command called in Windows command prompt
                    string command = this.CommandName + ".exe" + " " + this.FileNameDependingOfType(this.CommandName, FileType.InputFile)
                        + " " + this.FileNameDependingOfType(this.CommandName, FileType.OutputFile);

                    var processStartInfo = new ProcessStartInfo();
                    processStartInfo.WorkingDirectory = this.Path;
                    processStartInfo.FileName = "cmd.exe";
                    processStartInfo.Arguments = "/C " + command;
                    Process proc = Process.Start(processStartInfo);
                    retVal = true;
                    ;
                }
                else
                {
                    retVal = false;
                    MessageBox.Show("Command with name: " + this.CommandName + " does not exist under: " + this.Path + " .Command was not executed!");
                }
            }
            catch (Exception ex)
            {
                retVal = false;
                MessageBox.Show(ex.Message);
            }

            return retVal;

        }

        //Method used to generate raw data from an object
        public bool GenerateRawDataFromObject()
        {
            //Local variable
            List<string> retValue = new List<string>();
            string dummyString = "";
            bool returnValue = false;

            try
            {
                if (this.TypeOfFile != FileType.ConfigFile)
                {
                    //Convert header object to string list
                    retValue.Add(ConvertFromListToString(this.Header.HeaderLine1.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));
                    retValue.Add(ConvertFromListToString(this.Header.HeaderLine2.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));
                    retValue.Add(ConvertFromListToString(this.Header.HeaderLine3.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));
                }
                //Convert element object to string list
                foreach (AttributeValueObject obj in this.Element)
                {

                    int i = 1;
                    //Loop through all element attributes values. Add Element mark and attribute separator to it
                    string elementAllValues = this.ElementMark;
                    foreach (string attributeValue in obj)
                    {
                        if (i == obj.AttributeValue.Count())
                        {
                            elementAllValues += attributeValue;
                        }
                        else
                        {
                            //elementAllValues += attributeValue + this.AttributesSeparator;
                            dummyString = GenerateStringWithGivenChar(this.NrOfCharsInElementAttribute - attributeValue.Length, ' ');
                            elementAllValues += attributeValue + dummyString + this.AttributesSeparator;
                        }
                        i++;

                    }
                    //elementAllValues = elementAllValues.Remove(elementAllValues.Length - 1, 1);
                    retValue.Add(elementAllValues);
                }

                //Assing created string list to internal variable
                this.RawData = retValue;
                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
                MessageBox.Show(ex.Message);
            }

            return returnValue;
        }

        //Method used to generate string from given char
        private string GenerateStringWithGivenChar(int nrOfChars, char charToBeMultiplied)
        {
            //Local variable
            string retVal = "";

            //Loop to add all chars
            for (int i = 0; i < nrOfChars; i++)
            {
                retVal += charToBeMultiplied.ToString();
            }

            return retVal;
        }

        public string ConvertFromListToString(List<string> inputList, string lineMark, string separator)
        {
            //Local variable
            string retValue = "";
            int i=0;

            //Conversion to string
            foreach (string element in inputList)
            {
                //Add line mark before first element
                if (i == 0) 
                { 
                    retValue = lineMark + element; 
                }
                else
                {
                    retValue += separator + lineMark;
                }


                i++;
            }

            return retValue;

        }


        //Method used to change value of given element ID
        //Only first occurence of element will be changed.
        public void ChangeAttributeValue(int elementID, string attributeName, string newValue)
        {
            this.Element.ChangeAttributeValue(elementID, attributeName, newValue);

        }

        public void ChangeAllElementValues(string elementID, params string[] values)
        {
            this.Element.ChangeAllElementsValue(this.AttributeNameAsID, elementID, values);

        }
        //Method used to add element to the object
        public void AddElement()
        {
            this.Element.AddElement();
        }

        //Method used to add element to the object
        public void AddElement(string attributeIDValue)
        {
            this.Element.AddElement(this.AttributeNameAsID, attributeIDValue);
        }

        private void WriteRawDataToFile(string path, string commandName, FileType typeOfFile, List<string> dataToWrite)
        {
            this.WriteDataToFile(path, this.BackupPath, commandName, typeOfFile, dataToWrite);
        }

        //Method used to write data to file
        public bool WriteDataToFile()
        {
            return this.WriteDataToFile(this.Path, this.BackupPath, this.CommandName, this.TypeOfFile, this.RawData);
        }

        //Method used to prepare raw data from Elzab documentation
        private List<string> ParsePattern(string pattern)
        {
            //Local variable
            Regex regx = new Regex(" ");
            List<string> retVal = new List<string>();
            string[] dividedNames;

            //Clear input string
            pattern = pattern.Replace("<", "").Replace(">", "").Replace("$", "");

            //Split input string into string array
            dividedNames = regx.Split(pattern);

            //Trim array of strings
            for (int i = 0; i < dividedNames.Length; i++)
            {
                dividedNames[i] = dividedNames[i].Trim();
            }
            //Add attributs names to the list
            foreach (string element in dividedNames)
            {
                if (element != "")
                {
                    retVal.Add(element);
                }

            }

            //Return value
            return retVal;
        }

        //Method use to parse string to the element list. It using specified divider, to split input string.
        private List<string> ParseStringToList(string inputString, string divider)
        {
            //Local variable
            List<string> retVal;
            string[] elementArray;

            //Define regular expression pattern
            Regex regPattern = new Regex(divider);

            //Divide string to list using given divider
            elementArray = regPattern.Split(inputString);

            //Clear list from empty marks
            for (int i = 0; i < elementArray.Length; i++)
            {
                elementArray[i] = elementArray[i].Trim();
            }

            //Convert array to list
            retVal = elementArray.ToList();

            //Return value
            return retVal;

        }

        //Method used to check if file exist. If yes, it will move it to backup folder and remove orginal one.
        internal bool BackupFileAndRemove()
        {

            bool result = base.BackupFileAndRemove(this.FileNameWithExtension, this.Path, this.BackupPath);
            ;
            return result;
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public abstract class ElzabCommandFileHandling
    {
        private string elzabFilePath { get; set; }
        private string elzabCommandName { get; set; }
        private Encoding FileEncoding { get; set; }

        //Set encoding type
        protected void SetEncoding()
        {
            this.FileEncoding = new UTF8Encoding(false);
        }

        //Method used to add Elzab command name
        protected void SetElzabCommandName(string elzabCommandName)
        {
            this.elzabCommandName = elzabCommandName;
        }

        //Method used to read file from given path.
        //It return all lines of file as array of strings
        private List<string> ReadFile(string fullPath)
        {
            //Local variable
            List<string> fileToArray = new List<string>();

            //Open file and read all lines to string array
            try
            {
                using (var file = new StreamReader(fullPath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        fileToArray.Add(line);
                    }

                }
            }
            catch( Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return fileToArray;
        } 

        //Method adds path to the Elzab file
        public void AddPathToElzabFiles(string path)
        {
            bool pathValidateResult;
            bool fileValidateResult;
            string fullPath = path + "\\" + this.elzabCommandName + ".exe";

            //Validate path and file exist
            pathValidateResult = Directory.Exists(path);
            fileValidateResult=  File.Exists(fullPath);

            //If path exist add it, 
            if (pathValidateResult && fileValidateResult)
            {
                //Add full
                this.elzabFilePath = fullPath;
            }
            else
            {
                //Show message box if path or file invalid
                if (pathValidateResult && !fileValidateResult)
                {
                    MessageBox.Show("Wrong path to Elzab files");
                }
                else if (!pathValidateResult && fileValidateResult)
                {
                    MessageBox.Show("Missing Elzab command '" + this.elzabCommandName + "' under path: " + path);
                }
            }     
        }

        //Method use to check if input, output, config or report file exist
        private bool CheckIfFileExist(string fullPath)
        {
            //Local variables
            bool retVal = false;

            //Chceck if input file exist
            retVal = File.Exists(fullPath);

            return retVal;
        }

        //Method used to save raw data to file
        private bool SaveDataToFile(string fullPath, List<string> data)
        {
            //Local variable
            bool retVal = false;
            try
            {
                //Use File stream to write data to file
                FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate);
                using (StreamWriter fs = new StreamWriter(stream, this.FileEncoding))
                {
                    foreach (string lineToWrite in data)
                    {
                       string decoded = fnStringConverterCodepage(lineToWrite);
                        fs.WriteLine(decoded);
                    }

                    //Close file
                    fs.Close();
                    retVal = true;
                }

            }
            catch (Exception ex)
            {
                retVal = false;
                //Message if exception
                MessageBox.Show(ex.ToString());
            }

            return retVal;
        }

        public static string fnStringConverterCodepage(string sText, string sCodepageIn = "UTF-8", string sCodepageOut = "UTF-8")
        {
            string myString = sText;
            byte[] bytes = Encoding.UTF32.GetBytes(myString);
            bytes = Encoding.Convert(Encoding.UTF32, Encoding.UTF8, bytes);
            myString = Encoding.UTF8.GetString(bytes);
            return myString;
        }

        //Method use to create input or config file
        private bool CreateFile(string fullPath)
        {
            //Local variable
            bool retVal = false;
            try
            {
                //Check if directory exist
                bool dirExist = Directory.Exists(fullPath);
                if (!dirExist)
                {
                    string dirName = Path.GetDirectoryName(fullPath);
                    Directory.CreateDirectory(dirName);
                }

                //Use File stream to write data to file
                FileStream stream = new FileStream(fullPath, FileMode.CreateNew);
                using (StreamWriter fs = new StreamWriter(stream, this.FileEncoding))
                {
                    //Close file
                    fs.Close();
                    retVal = true;
                }

            }
            catch (Exception ex)
            {
                retVal = false;
                //Message if exception
                MessageBox.Show(ex.ToString());
            }

            return retVal;
            
        }

        //Method use to make file backup and remove it. It has user control build in.
        private bool DeleteFile(string fullPath, string backupPath)
        {
            bool retVal = false;
            try
            {
                string fileName = Path.GetFileName(fullPath);
                DialogResult result = MessageBox.Show(string.Format("Uwaga plik {0} zostanie przeniesiony, czy chcesz kontunuowac?", fileName), 
                    "Usuwanie pliku", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    bool backupDone = MakeFileBackup(fullPath, backupPath);
                    if (backupDone)
                    {
                        File.Delete(fullPath);
                        retVal = true;
                    }

                }
                else
                {
                    retVal = false;
                }

            }
            catch (Exception ex)
            {
                //Message if exception
                MessageBox.Show(ex.ToString());
                retVal = false;
            }

            return retVal;
        }

        //Method use to delete file.
        private bool DeleteFile(string fullPath)
        {
            bool retVal = false;
            try
            {
                //Delete file
                File.Delete(fullPath);
                retVal = true;
            }
            catch (Exception ex)
            {
                //Message if exception
                MessageBox.Show(ex.ToString());
                retVal = false;
            }

            return retVal;
        }

        protected bool BackupFileAndRemove(string fileName, string fullPath, string backupPath)
        {
            //Local variable
            bool retVal = false;

            //Full path to file to delete
            string fullFilePath = Path.Combine(fullPath, fileName);

            //If file exist, make backup
            bool backupDone = MakeFileBackup(fullFilePath, backupPath);

            //Remove orginal file
            if (backupDone)
            {
                if (DeleteFile(fullFilePath)) retVal = true;

            }

            return retVal;
        }

        //Method used to make file backup.
        //Return true if file to backup does not exist or backup was done successfully
        private bool MakeFileBackup(string fullPath, string backupPath)
        {
            //Local variable
            bool retVal = false; ;
            bool subFolderCreated = false;

            string fileNameWithExtension = Path.GetFileName(fullPath);

            try
            {
                //Check if file exist
                bool exist = File.Exists(fullPath);

                if (exist)
                {
                    //Generate subdirectory name and check if exist
                    string date = DateTime.Now.Date.ToString("MM/dd/yyyy");
                    string time = DateTime.Now.TimeOfDay.Hours.ToString("00") + "." +
                        DateTime.Now.TimeOfDay.Minutes.ToString("00");
                    string subDirName = Path.Combine(backupPath, date + "_" + time);

                    //Backup path with file
                    string backupPathWithFile = Path.Combine(subDirName, fileNameWithExtension);

                    //Check if backup directory exist
                    bool dirExist = File.Exists(backupPathWithFile);
                    if (!dirExist)
                    {
                        subFolderCreated = Directory.CreateDirectory(subDirName).Exists;
                    }
                    else
                    {
                        //Try to create another name
                        for (int i = 1; i <= 10; i++)
                        {
                            string candidateDirName = subDirName;
                            candidateDirName += " (" + i + ")";
                            backupPathWithFile = Path.Combine(candidateDirName, fileNameWithExtension);
                            dirExist = File.Exists(backupPathWithFile);
                            if (!dirExist)
                            {
                                Directory.CreateDirectory(candidateDirName);
                                subDirName = candidateDirName;
                                subFolderCreated = true;
                                break;
                            }
                        }
                    }
                    if (subFolderCreated)
                    {
                        string fullPathToCopy = Path.Combine(subDirName, Path.GetFileName(fullPath));
                        File.Copy(fullPath, fullPathToCopy);
                        retVal = true;
                        MessageBox.Show("Kopia zapasowa została wykonana!");
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się utworzyć podfolderu!");
                    }
                }
                else retVal = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(string.Format("Kopia zapasowa pliku {0} nie została wykonana!", Path.GetFileName(fullPath)));
                retVal = false;

            }

            return retVal;
        }

        //Method used to consolidate path, command name and file type
        private string ConsolidatePath(string path, string commandName, FileType typeOfFile)
        {
            string fullPath = path + "\\" + FileNameDependingOfType(commandName, typeOfFile);

            return fullPath;

        }

        //Method use to create file name, depending of given file type
        protected string FileNameDependingOfType(string commandName, FileType typeOfFile)
        {
            //Local variables
            string retVal;

            //Check file type and return it name
            switch (typeOfFile)
            {
                case FileType.InputFile:
                    retVal = commandName + "IN.txt";
                    break;
                case FileType.OutputFile:
                    retVal = commandName + "OUT.txt";
                    break;
                case FileType.ConfigFile:
                    retVal = "KONFIG.txt";
                    break;
                case FileType.ReportFile:
                    retVal = "RAPORT.txt";
                    break;
                default:
                    retVal = "";
                    break;
            }

            return retVal;
        }

        //Method used to read data from specified file
        public List<string> ReadDataFromFile(string path, string commandName, FileType typeOfFile)
        {
            //Local variables
            List<string> readData = new List<string>();
            string fullPath;
            bool fileExist;

            //Generate full path to file
            fullPath = ConsolidatePath(path, commandName, typeOfFile);

            //Check if given file exist
            fileExist = CheckIfFileExist(fullPath);
            if (fileExist)
            {
                //Call method to read from file
                readData = ReadFile(fullPath);
            }
            //If file/path not valid, show message box
            else
            {
                MessageBox.Show("Specified file does not exist or cannot be opened. File: " + fullPath);
            }

            //Return variable
            return readData;    
        }

        //Method used to write data to specified file
        public bool WriteDataToFile(string path, string backupPath, string commandName, FileType typeOfFile, List<string> dataToWrite)
        {
            //Local variables
            string fullPath = "";
            bool fileExist = false;
            bool retVal;

            try
            {
                //Generate full path to file
                fullPath = ConsolidatePath(path, commandName, typeOfFile);

                //Check if given file exist
                fileExist = CheckIfFileExist(fullPath);
                retVal = true;
            }
            catch (Exception ex)
            {
                retVal = false;
                MessageBox.Show(ex.Message);
            }

            if (fileExist && retVal)
            {

                //Remove old file first
                retVal = DeleteFile(fullPath, backupPath);

                //Call method to write data to file
                if(retVal) retVal = SaveDataToFile(fullPath, dataToWrite);
            }
            //If file/path not valid, show message box
            else
            {
                //If file does not exist, create one
                retVal = CreateFile(fullPath);

                //Call method to write data to file
                if (retVal) retVal = SaveDataToFile(fullPath, dataToWrite);
            }
            return retVal;
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    #region Elzab command element class
    //Class used to define single element of Elzab command.
    //Below visual explanation of naming convesion.
    //=====================================================
    //                   |  "AttributeName" = 1               |  "AttributeName" = 2            |
    //  "ElementName"    |  "AttributeValue" = TestValue1     |   "AttributeValue" = TestValue2 |

    public class AttributeValueObject : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string val in this.AttributeValue)
            {
                yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<string> AttributeValue { get; set; }

        public AttributeValueObject()
        {
            this.AttributeValue = new List<string>();
        }


    }
    public class ElzabCommElementObject: IEnumerable<AttributeValueObject>
    {

        public IEnumerator<AttributeValueObject> GetEnumerator()
        {
            foreach (AttributeValueObject val in this.ElementsList)
            {
                yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Define class elements
        private List<string> AttributeName { get; set; }
        private List<AttributeValueObject> ElementsList { get; set; }

        public ElzabCommElementObject()
        { 
            this.AttributeName = new List<string>();
            this.ElementsList = new List<AttributeValueObject>();
            ;
        }

        //Method used to add new attribute and its value to the element
        public void AddAttribute(int elementID, string attributeName, string attributeValue)
        {
            this.AttributeName.Append(attributeName);
            this.ElementsList[elementID].AttributeValue.Append(attributeValue);
        }

        //Method used to add new attribute to the element
        public void AddAttributeName(string attributeName)
        {
            this.AttributeName.Add(attributeName);
            
        }

        //Method used to add element to the object
        public void AddElement()
        {
            this.ElementsList.Add(new AttributeValueObject());
            foreach (var element in this.AttributeName)
            {
                this.ElementsList.Last().AttributeValue.Add("1");
            }
        }


        //Method used to add element to the object
        public void AddElement(string attributeName, string attributeIDValue)
        {
            this.ElementsList.Add(new AttributeValueObject());
            foreach (var element in this.AttributeName)
            {
                this.ElementsList.Last().AttributeValue.Add("1");
            }

            //Find ID of given attribute name
            int attributeIndex = this.AttributeName.IndexOf(attributeName);
            this.ElementsList.Last().AttributeValue[attributeIndex] = attributeIDValue;

        }

        //Method used to get ID of last element of ElementList object
        public int GetLastElementID()
        {
            //Return last element ID
            return this.ElementsList.Count - 1;
        }
        


        //Method used to find value of given element name. 
        //Only first occurence of element will be found.
        //If nothing found, return empty string
        public string GetAttributeValue(int elementID, string attributeName)
        {
            //Local variables
            int index = 0;
            Boolean findingResult = false;

            //Loop through attribute name, to check if any of it element match given name
            for(int i = 0; i < this.AttributeName.Count; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributeName[i])
                {
                    index = i;
                    findingResult = true;
                }
            }

            //Check if any of element match, if not return empty string
            if (findingResult)
            {
                return this.ElementsList[elementID].AttributeValue[index];
            }
            else
            {
                return "";
            }
            
        }

        //Method used to find all values of given element name. 
        public List<string> GetAllAttributeValue(int elementID)
        {
            //Local variables
            List<string> retVal = new List<string>();

            //Collect all element values to the list
            foreach (string element in this.ElementsList[elementID].AttributeValue)
            {
                retVal.Add(element);
            }

            return retVal;
        }

        //Method used to read attribute value from certain index
        public string GetAttributNameOfIndex(int index)
        {
            //Read attribut name from certain index
            return this.AttributeName[index];

        }


        //Method used to change value of given element ID
        //Only first occurence of element will be changed.
        //If method does not find element with given ID it will generate an error
        public void ChangeAttributeValue(int elementID, string attributeName, string newValue)
        {
            try
            {
                //Check if element with given ID exist
                if (elementID > this.ElementsList.Count - 1)
                {
                    throw new System.ArgumentException($"Given element ID does not exist. Element ID: {elementID}. Attribute name: {attributeName}");
                }
                else
                {
                    //Loop through attribute name, to check if any of it element match given name
                    for (int i = 0; i < this.AttributeName.Count; i++)
                    {
                        //If attribueName match, save index and break;
                        if (attributeName == this.AttributeName.ElementAt(i))
                        {
                            //Override value
                            this.ElementsList[elementID].AttributeValue[i] = newValue;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        //Method used to change all value of given element name
        //Only first occurence of element will be changed.
        //attributeID is used to determine with of attribute is used as ID value;
        public void ChangeAllElementsValue(string attributeName, string attributeID, params string[] values)
        {

            //Find index of attribute with given name
            int attributeIndex = this.AttributeName.IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i=0; i<this.ElementsList.Count(); i++)
            {
                if (this.ElementsList[i].AttributeValue[attributeIndex] == attributeID)
                {

                    //Change attribute value
                    for (int j = 0; j < values.Length; j++)
                    {
                        //Change everything except attribute with is taken as ID
                        if (this.AttributeName[j] != attributeName)
                        {
                            this.ElementsList[i].AttributeValue[j] = values[j];
                        }
                        
                    }
                    break;
                }
                else if(i == this.ElementsList.Count() - 1)
                {
                    MessageBox.Show("Element with given ID was not found!");
                }
            }

        }

        //Method used to change all value of given element name
        //Only first occurence of element will be changed.;
        public void ChangeAllElementsAttribute(string attributeName, params string[] values)
        {

            //Find index of attribute with given name
            int attributeIndex = this.AttributeName.IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i = 0; i < this.ElementsList.Count(); i++)
            {
                //Change attribute value
                for (int j = 0; j < values.Length; j++)
                {
                    //Change everything except attribute with is taken as ID
                    if (this.AttributeName[j] != attributeName)
                    {
                        this.ElementsList[i].AttributeValue[j] = values[j];
                    }

                }
            }

        }


        //Method used to delete given attribute and its value
        //Only first occurence of element will be deleted.
        public void DeleteAttribute(string attributeName)
        {
            //Remove attribut and its value
            this.AttributeName.Remove(attributeName);

        }

        //Method used to add list of string to an object
        //If list lenght is greater then number of attributes, it will change only existing attributes
        public void StringListToAttributesValue(int elementID, List<string> inputStringList)
        {
            //Check input string array lenght
            int arrayLenght = inputStringList.Count, i = 0;

            //Check number of attributes
            int attributsNumber = this.AttributeName.Count;

            //Change attribute value by Name
            foreach (string attribute  in this.AttributeName)
            {
                if (i <= arrayLenght - 1)
                {
                    ChangeAttributeValue(elementID, attribute, inputStringList.ElementAt(i));
                }   
                else
                {
                    break;
                }
                i++;
            }
        }

        //Method used to add attributes from list
        public void AddAttributesFromList(List<string> attributesNames)
        {
            foreach (string element in attributesNames)
            {
                AddAttributeName(element);
            }
        }

    }
    #endregion    
}
