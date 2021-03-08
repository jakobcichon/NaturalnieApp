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
using NaturalnieApp;

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

    public class CommandExecutionStatus
    {
        public int CashRegisterNumber { get; set; }
        public int CashRegisterComPort { get; set; }
        public int CashRegisterBaudRate { get; set; }
        public int TimeoutValue { get; set; }
        public DateTime ExecutionDateAndTime { get; set; }
        public string CommandName { get; set; }
        public string InFileName { get; set; }
        public string OutFileName { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorText { get; set; }

    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public enum FileType
    {
        InputFile, OutputFile, ConfigFile, ReportFile
    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabFileObject : ElzabCommandFileHandling
    {
        protected string AttributesSeparator { get; set; }
        protected string HeaderMark { get; set; }
        protected string HeaderSeparator { get; set; }
        protected string CommentMark { get; set; }
        protected string ElementMark { get; set; }
        protected string ElementUniqueIdMark { get; set; }
        protected string AdditionMarkForConfigFile { get; set; }
        protected string Path { get; set; }
        protected string DefaultPath { get; }
        protected string BackupPath { get; }
        protected string CommandName { get; }
        protected FileType TypeOfFile { get; }
        public ElzabCommHeaderObject Header { get; set; }
        public ElzabCommElementObject Element { get; set; }
        protected List<string> RawData { get; set; }
        protected Dictionary<int, string> AttributeNameAsID { get; set; }
        protected int NrOfCharsInElementAttribute { get; set; }
        protected string FileNameWithExtension { get; set; }

        //Contains information with attributes create unique element identifier (example raport_number + date will create unique idenifier)
        //User must type column number starting from 1 (element type identifier is also count here). If user type 0, no identier consider for given type
        private Dictionary<int, List<int>> UniqueElementIdentifierForAttributesPattern { get; set;}

        //Class constructor
        public ElzabFileObject()
        {

        }

        public ElzabFileObject(string path, string commandName, FileType typeOfFile, int cashRegisterID,
            string headerPatternLine1 = "< cash_register_number > < cash_register_comm_data > < comm_timeout > <execution_date >" +
            "< execution_time > < command_name > < version_number> < input_file_name > <output_file_name>", 
            string headerPatternLine2 = " < error_number > < error_text > ", string headerPatternLine3 = " <cash_register_id > ",
            List<string> elementAttributesPattern = null, string attributeNameAsID = "", int nrOfCharsInElementAttribute = 34, Dictionary<int, 
            List<int>> uniqueElementIdentifierForAttributesPattern = null, char elementUniqueIdMark = ' ')
        {
            elementAttributesPattern = elementAttributesPattern ?? new List<string> { " < empty_element>" };

            if(uniqueElementIdentifierForAttributesPattern != null)
            {
                this.UniqueElementIdentifierForAttributesPattern = uniqueElementIdentifierForAttributesPattern;
            }


            //Initialize object variables
            this.Path = System.IO.Path.Combine(path, commandName);
            this.DefaultPath = this.Path;
            this.BackupPath = System.IO.Path.Combine(this.Path, "Backup");
            this.CommandName = commandName;
            this.TypeOfFile = typeOfFile;
            this.FileNameWithExtension = FileNameDependingOfType(this.CommandName, this.TypeOfFile);
            base.SetEncoding();

            //Create instance of Raw data object
            this.RawData = new List<string>();
            this.AttributeNameAsID = new Dictionary<int, string>();
            
            //Call method used to set marks and separators
            SetMarksAndSeparators(elementUniqueIdMark: elementUniqueIdMark);

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
                    this.Header.HeaderLine1.ChangeAttributeValue(null, 0, "device_number", cashRegisterID.ToString());
                    this.Header.HeaderLine2.AddElement();
                    this.Header.HeaderLine2.ChangeAttributeValue(null, 0, "", "");
                    this.Header.HeaderLine3.AddElement();
                    this.Header.HeaderLine3.ChangeAttributeValue(null, 0, "", "");
                }
            }

            this.Element = new ElzabCommElementObject();
            int i = 1;
            foreach (string element in elementAttributesPattern)
            {

                //Create instance of element object and initialize it
                if (element != "")
                {
                    int elementTypeId = this.Element.SelectElementUniqueId(element, this.ElementUniqueIdMark);

                    if (this.TypeOfFile == FileType.ReportFile)
                    {
                        List<string> elementPattern = ParsePattern(element);
                        this.Element.AddAttributesFromList(elementPattern, i);
                        InitializAttributeNameAsId(i, elementPattern[0]);
                        i++;
                        continue;
                    }
                    else
                    {
                        //Check if element identifier exist. If yes, add it to the element instance
                        
                        if (elementTypeId > 0)
                        {
                            this.Element.AddAttributesFromList(ParsePattern(element), elementTypeId);
                        }
                        else
                        {
                            this.Element.AddAttributesFromList(ParsePattern(element));
                        }

                        //attributeNameAsID specify with attribute must be consider as ID number of element
                        //If attributeNameAsID was not secified, it will take attribute name from index 0
                        if (attributeNameAsID == "")
                        {
                            if (elementTypeId > 0)
                            {
                                InitializAttributeNameAsId(elementTypeId, this.Element.GetAttributNameOfIndex(0, elementTypeId));
                            }
                            else
                            {
                                InitializAttributeNameAsId(0, this.Element.GetAttributNameOfIndex(0));
                            }
                        }
                        else
                        {
                            if (elementTypeId > 0)
                            {
                                InitializAttributeNameAsId(elementTypeId, attributeNameAsID);
                            }
                            else
                            {
                                InitializAttributeNameAsId(0, attributeNameAsID);
                            }
                        }
                    }

                   
                }
            }

            //nrOfCharsInElementAttribute specify number of char of each element attribute
            //If given element attribute value is shorter then, nrOfCharsInElementAttribute it will be fill with 0x20 (space)
            this.NrOfCharsInElementAttribute = nrOfCharsInElementAttribute;

        }

        //Method used to get unique element identifier
        public List<int> GetUniqueIdentifierAttributesIndexes(int elementType)
        {
            List<int> listOfAttributesIndexes = null;

            //Get list of unique identifier attributes
            if (this.UniqueElementIdentifierForAttributesPattern != null)
            {
                this.UniqueElementIdentifierForAttributesPattern.TryGetValue(elementType, out listOfAttributesIndexes);
            }

            return listOfAttributesIndexes;
        }

        //Method used to set basic information about file
        public virtual void SetMarksAndSeparators(char attributeSeparator = '\t', char headerMark = '#',
                                        char headerSeparator = '\t', char commentMark = ';',
                                        char elementMark = '$', char additionmarkforConfigFile = '\t', char elementUniqueIdMark = ' ')
        {
            //Set values to variables
            this.AttributesSeparator = attributeSeparator.ToString();
            this.HeaderMark = headerMark.ToString();
            this.HeaderSeparator = headerSeparator.ToString();
            this.CommentMark = commentMark.ToString();
            this.ElementMark = elementMark.ToString();
            this.ElementUniqueIdMark = elementUniqueIdMark.ToString();
            this.AdditionMarkForConfigFile = additionmarkforConfigFile.ToString();
        }

        //Method used to initialize attribute name as id list depending on element type
        private void InitializAttributeNameAsId(int elementType, string attributeNamaeAsId)
        {
            if(!CheckIfAttributeNamesAsIdOfTypeExist(elementType))
            {
                this.AttributeNameAsID.Add(elementType, attributeNamaeAsId);
            }

        }

        //Method used to check if element type header initialized
        public bool CheckIfAttributeNamesAsIdOfTypeExist(int elementType)
        {
            bool retVal = false;
            if (this.AttributeNameAsID.Count > 0) retVal = this.AttributeNameAsID.ContainsKey(elementType);

            return retVal;
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

            //Clear old data
            this.Header.HeaderLine1.RemoveAllElements();
            this.Header.HeaderLine2.RemoveAllElements();
            this.Header.HeaderLine3.RemoveAllElements();
            if (this.Element != null) this.Element.RemoveAllElements();

            //Parse data
            //Define header pattern
            Regex regPatternHeader = new Regex(@"^" + this.HeaderMark + ".*$");

            //Define elements pattern
            Regex regPatternElements = new Regex(@"^\" + this.ElementMark + ".*$");

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
                            this.Header.HeaderLine1.StringListToAttributesValue(null, 0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                        case 1:
                            this.Header.HeaderLine2.AddElement();
                            this.Header.HeaderLine2.StringListToAttributesValue(null, 0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                        case 2:
                            this.Header.HeaderLine3.AddElement();
                            this.Header.HeaderLine3.StringListToAttributesValue(null, 0, ParseStringToList(clearedElement, this.HeaderSeparator));
                            break;
                    }

                    i++;
                }

                if (this.Element != null)
                {
                    //Parse elements
                    if (regPatternElements.IsMatch(element))
                    {
                        //Local variable
                        string clearedElement;

                        //Remove mark sign
                        clearedElement = element.Replace(this.ElementMark.Replace("\\", ""), "");

                        //Read every element and add it to an object
                        int index = this.RawData.IndexOf(element) - 2;
                        if (this.TypeOfFile == FileType.ReportFile)
                        {
                            this.Element.AddElement(index);
                            this.Element.StringListToAttributesValue(null ,this.Element.GetLastElementID(index),
                                ParseStringToList(clearedElement, this.AttributesSeparator), index);
                        }
                        else
                        {
                            //Check if element identifier exist. If yes, add it to the element instance
                            int elementTypeId;
                            if (this.ElementUniqueIdMark == ' '.ToString()) elementTypeId = 0;
                            else elementTypeId = this.Element.SelectElementUniqueId(element, this.ElementUniqueIdMark);
                            if (elementTypeId > 0)
                            {
                                this.Element.AddElement(elementTypeId);
                                this.Element.StringListToAttributesValue(GetUniqueIdentifierAttributesIndexes(elementTypeId), this.Element.GetLastElementID(elementTypeId),
                                    ParseStringToList(clearedElement, this.AttributesSeparator), elementTypeId);
                            }
                            else
                            {
                                this.Element.AddElement();
                                this.Element.StringListToAttributesValue(null, this.Element.GetLastElementID(elementTypeId),
                                    ParseStringToList(clearedElement, this.AttributesSeparator));
                            }
                        }
                        
                    }
                }

            }
        }

        public List<int> GetListOfElementTypes()
        {
            //Local variables
            List<int> retList = new List<int>();

            retList = this.Element.ElementType;

            return retList;
        }

        public List<AttributeValueObject> GetElementsOfTypeAllValues(int type)
        {
            //Local variable
            List<AttributeValueObject> retList = new List<AttributeValueObject>();

            bool typeExist = this.Element.CheckIfHeaderOfTypeExist(type);
            if (typeExist)
            {
                int indexOfType = this.Element.GetElementTypeIndex(type);
                foreach (AttributeValueObject element in this.Element.ElementsList[indexOfType])
                {
                    retList.Add(element);
                }

            }

            return retList;
        }

        //Method used to set new path to the file
        public bool SetNewPath(string path)
        {
            //Local variables
            bool retVal = false;

            retVal = Directory.Exists(path);

            if (retVal) this.Path = path;

            return retVal;
        }

        //Method used to resotre default path
        public void RestoreDefaultPath()
        {
            this.Path = this.DefaultPath;
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
                    proc.WaitForExit();
                    retVal = true;
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

                if(this.Element != null)
                {
                    //Convert element object to string list
                    foreach (AttributeValueObject obj in this.Element)
                    {
                        //Get index of product name
                        int indexOfProducNameAttribute = -1;
                        foreach (string attributeName in this.Element.AttributesName[0])
                        {
                            if (attributeName == "naz_tow")
                            {
                                indexOfProducNameAttribute = this.Element.AttributesName[0].IndexOf("naz_tow");
                                break;
                            }
                        }
                        int i = 0, j = 1;
                        //Loop through all element attributes values. Add Element mark and attribute separator to it
                        string elementAllValues = this.ElementMark;
                        foreach (string attributeValue in obj)
                        {
                            if (j == obj.AttributeValue.Count())
                            {
                                elementAllValues += attributeValue;
                            }
                            else
                            {
                                if (indexOfProducNameAttribute > -1 && i == indexOfProducNameAttribute)
                                {
                                    dummyString = GenerateStringWithGivenChar(this.NrOfCharsInElementAttribute - attributeValue.Length, ' ');
                                }
                                else dummyString = "";
                                elementAllValues += attributeValue + dummyString + this.AttributesSeparator;
                            }
                            i++;
                            j++;

                        }
                        retValue.Add(elementAllValues);
                    }
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
            int elementType = 0;

            List<int> listOfAttributesIndexes;

            //Get list of unique identifier attributes
            listOfAttributesIndexes = GetUniqueIdentifierAttributesIndexes(elementType);

            this.Element.ChangeAttributeValue(listOfAttributesIndexes, elementID, attributeName, newValue, elementType);

        }
        public void ChangeAttributeValue(int elementID, string attributeName, string newValue, int elementType = 0)
        {
            List<int> listOfAttributesIndexes;

            //Get list of unique identifier attributes
            listOfAttributesIndexes = GetUniqueIdentifierAttributesIndexes(elementType);

            this.Element.ChangeAttributeValue(listOfAttributesIndexes, elementID, attributeName, newValue, elementType);

        }

        public void ChangeAllElementValues(string elementID, params string[] values)
        {
            int elementType = 0;

            List<int> listOfAttributesIndexes;

            //Get list of unique identifier attributes
            listOfAttributesIndexes = GetUniqueIdentifierAttributesIndexes(elementType);

            this.Element.ChangeAllElementsValue(listOfAttributesIndexes, this.AttributeNameAsID[elementType], elementID, values);

        }
        public void ChangeAllElementValues(string elementID, int elementType = 0, params string[] values)
        {
            List<int> listOfAttributesIndexes;

            //Get list of unique identifier attributes
            listOfAttributesIndexes = GetUniqueIdentifierAttributesIndexes(elementType);

            this.Element.ChangeAllElementsValue(listOfAttributesIndexes, this.AttributeNameAsID[elementType], elementID, values);

        }
        //Method used to add element to the object
        public void AddElement()
        {
            this.Element.AddElement();
        }

        //Method used to add element to the object
        public void AddElement(string attributeIDValue)
        {
            int elementType = 0;

            this.Element.AddElement(this.AttributeNameAsID[elementType], attributeIDValue);
        }
        public void AddElement(string attributeIDValue, int elementType = 0)
        {

            this.Element.AddElement(this.AttributeNameAsID[elementType], attributeIDValue);
        }

        //Method used to get all elements values
        public List<AttributeValueObject> GetAllElements()
        {
            int elementType = 0;

            //Local variables
            List<AttributeValueObject> retList = new List<AttributeValueObject>();

            foreach (var element in this.Element.ElementsList[elementType])
            {
                retList.Add(element);
            }

            return retList;
        }
        public List<AttributeValueObject> GetAllElements(int elementType)
        {
            //Local variables
            List<AttributeValueObject> retList = new List<AttributeValueObject>();

            foreach (var element in this.Element.ElementsList[elementType])
            {
                retList.Add(element);
            }

            return retList;
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
        protected List<string> ParseStringToList(string inputString, string divider)
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

        //Method used to parse dataa from report file to object
        internal CommandExecutionStatus ParseReportFileToObject()
        {
            //Local variable
            CommandExecutionStatus commandStatus = new CommandExecutionStatus();

            if (this.TypeOfFile == FileType.ReportFile)
            {
                try
                {
                    commandStatus.CashRegisterNumber = Int32.Parse(this.Header.HeaderLine1.GetAttributeValue(0, "cash_register_number"));

                    string commData = this.Header.HeaderLine1.GetAttributeValue(0, "cash_register_comm_data");
                    string[] commDataSplited = commData.Split(':');
                    commandStatus.CashRegisterComPort = Int32.Parse(commDataSplited[0].Replace("COM", ""));
                    commandStatus.CashRegisterBaudRate = Int32.Parse(commDataSplited[1]);

                    commandStatus.TimeoutValue = Int32.Parse(this.Header.HeaderLine1.GetAttributeValue(0, "comm_timeout"));
                    string dateTime = this.Header.HeaderLine1.GetAttributeValue(0, "execution_date") + " " + this.Header.HeaderLine1.GetAttributeValue(0, "execution_time");
                    commandStatus.ExecutionDateAndTime = DateTime.Parse(dateTime);
                    commandStatus.CommandName = this.Header.HeaderLine1.GetAttributeValue(0, "command_name");
                    commandStatus.InFileName = this.Header.HeaderLine1.GetAttributeValue(0, "input_file_name");
                    commandStatus.OutFileName = this.Header.HeaderLine1.GetAttributeValue(0, "output_file_name");

                    commandStatus.ErrorNumber = Int32.Parse(this.Header.HeaderLine2.GetAttributeValue(0, "error_number"));
                    commandStatus.ErrorText = this.Header.HeaderLine2.GetAttributeValue(0, "error_text");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return commandStatus;

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
            this.FileEncoding = Encoding.Default;
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
                       string decoded = EncodingConversionRelated.StringConverterCodepage(lineToWrite);
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
                bool backupDone = MakeFileBackup(fullPath, backupPath);
                if (backupDone)
                {
                    File.Delete(fullPath);
                    retVal = true;
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
        public string UniqueIdentifier { get; set; }

        public AttributeValueObject()
        {
            this.AttributeValue = new List<string>();
            this.UniqueIdentifier = "";
        }

    }
    public class ElzabCommElementObject : IEnumerable<AttributeValueObject>
    {
        public IEnumerator<AttributeValueObject> GetEnumerator()
        {

           foreach(List<AttributeValueObject> var in this.ElementsList)
           {
                int i = this.ElementsList.IndexOf(var);
                foreach (AttributeValueObject val in this.ElementsList[i])
                {
                    yield return val;
                }
           }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Define class elements
        /// <summary>
        /// Element Type used to determine attributes name collection patter
        /// It must be unique
        /// </summary>
        public List<int> ElementType { get; set; }
        public List<List<string>> AttributesName { get; set; }
        public List<List<AttributeValueObject>> ElementsList { get; set; }

        public ElzabCommElementObject()
        { 
            this.AttributesName = new List<List<string>>();
            this.ElementsList = new List<List<AttributeValueObject>>();
            this.ElementType = new List<int>();
        }

        /// <summary>
        /// Method used to create unique identifier from given value
        /// </summary>
        /// <param name="oldIdentifier">Old identifier value</param>
        /// <param name="attributeValueToAdd">VThis value will be added to old identifier</param>
        /// <returns></returns>
        private string CreateIdentifier(string attributeValueToAdd,  string oldIdentifier = "", string separator = "_")
        {
            //Local variable
            string retVal = "";

            if (oldIdentifier == "") retVal = attributeValueToAdd;
            else retVal = oldIdentifier + separator + attributeValueToAdd;

            return retVal;
        }

        //Method used to check if element type header initialized
        internal bool CheckIfHeaderOfTypeExist(int elementType)
        {
            bool retVal = false;
            if (this.ElementType.Count > 0) retVal = this.ElementType.Any<int>(e => e.Equals(elementType));

            return retVal;
        }

        //Method used to initialize Element type
        private void InitializeElementType(int elementType)
        {
            if(!CheckIfHeaderOfTypeExist(elementType))
            {
                this.ElementType.Add(elementType);
                this.ElementsList.Add(new List<AttributeValueObject>());
                this.AttributesName.Add(new List<string>());
            }

        }

        //Method used to get element type index
        internal int GetElementTypeIndex(int elementType)
        {
            int retVal = -1;
            bool exist = false;

            exist = this.ElementType.Any<int>(e => e.Equals(elementType));
            if (exist && this.ElementType.Count > 0) retVal = this.ElementType.IndexOf(elementType);

            return retVal;
        }

        //Method used to add new attribute and its value to the element
        public void AddAttribute(int elementID, string attributeName, string attributeValue)
        {
            int elementType = 0;

            this.AttributesName[elementType].Append(attributeName);
            this.ElementsList[elementType][elementID].AttributeValue.Append(attributeValue);
        }
        public void AddAttribute(int elementID, string attributeName, string attributeValue, int elementType = 0)
        {
            this.AttributesName[elementType].Append(attributeName);
            this.ElementsList[elementType][elementID].AttributeValue.Append(attributeValue);
        }

        //Method used to add new attribute to the element
        public void AddAttributeName(string attributeName)
        {
            int elementType = 0;
            InitializeElementType(elementType);

            this.AttributesName[elementType].Add(attributeName);
        }
        public void AddAttributeName(string attributeName, int elementType = 0)
        {
           InitializeElementType(elementType);

            //Get element type index
           int index =  GetElementTypeIndex(elementType);

            this.AttributesName[index].Add(attributeName);
        }

        //Method used to remove all elements
        internal void RemoveAllElements()
        {

            foreach(int elementType in this.ElementType)
            {
                int elementTypeIndex = GetElementTypeIndex(elementType);

                if (this.ElementsList.Count() > 0 && this.ElementsList[elementTypeIndex] != null)
                {
                    int count = this.ElementsList[elementTypeIndex].Count();
                    for (int i = count - 1; i >= 0; i--)
                    {
                        this.ElementsList[elementTypeIndex].RemoveAt(i);
                    }
                }
            }

        }
        internal void RemoveAllElements(int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            if (elementTypeIndex > -1)
            {
                if (this.ElementsList.Count() > 0 && this.ElementsList[elementTypeIndex] != null)
                {
                    int count = this.ElementsList[elementTypeIndex].Count();
                    for (int i = count - 1; i >= 0; i--)
                    {
                        this.ElementsList[elementTypeIndex].RemoveAt(i);
                    }
                }
            }

        }

        //Method used to add element to the object
        internal void AddElement()
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            this.ElementsList[elementTypeIndex].Add(new AttributeValueObject());
            foreach (var element in this.AttributesName[elementTypeIndex])
            {
                this.ElementsList[elementTypeIndex].Last().AttributeValue.Add("1");
            }

        }

        //Method used to add element to the object
        internal void AddElement(int elementType = 0)
        {
            InitializeElementType(elementType);

            int elementTypeIndex = GetElementTypeIndex(elementType);

            this.ElementsList[elementTypeIndex].Add(new AttributeValueObject());
            foreach (var element in this.AttributesName[elementTypeIndex])
            {
                this.ElementsList[elementTypeIndex].Last().AttributeValue.Add("1");
            }

        }
        internal void AddElement(string attributeName, string attributeIDValue)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            this.ElementsList[elementTypeIndex].Add(new AttributeValueObject());
            foreach (var element in this.AttributesName[elementTypeIndex])
            {
                this.ElementsList[elementTypeIndex].Last().AttributeValue.Add("1");
            }

            //Find ID of given attribute name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);
            this.ElementsList[elementTypeIndex].Last().AttributeValue[attributeIndex] = attributeIDValue;
        }
        internal void AddElement(string attributeName, string attributeIDValue, int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            this.ElementsList[elementTypeIndex].Add(new AttributeValueObject());
            foreach (var element in this.AttributesName[elementTypeIndex])
            {
                this.ElementsList[elementTypeIndex].Last().AttributeValue.Add("1");
            }

            //Find ID of given attribute name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);
            this.ElementsList[elementTypeIndex].Last().AttributeValue[attributeIndex] = attributeIDValue;

        }

        //Method used to get ID of last element of ElementList object
        internal int GetLastElementID()
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Return last element ID
            return this.ElementsList[elementTypeIndex].Count - 1;
        }
        internal int GetLastElementID(int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);
            //Return last element ID
            return this.ElementsList[elementTypeIndex].Count - 1;
        }

        //Method used to find value of given element name. 
        //Only first occurence of element will be found.
        //If nothing found, return empty string
        internal string GetAttributeValue(int elementID, string attributeName)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Local variables
            int index = 0;
            Boolean findingResult = false;

            //Loop through attribute name, to check if any of it element match given name
            for(int i = 0; i < this.AttributesName[elementTypeIndex].Count; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributesName[elementTypeIndex][i])
                {
                    index = i;
                    findingResult = true;
                    break;
                }
            }

            //Check if any of element match, if not return empty string
            if (findingResult)
            {
                return this.ElementsList[elementTypeIndex][elementID].AttributeValue[index];
            }
            else
            {
                return "";
            }
            
        }
        internal string GetAttributeValue(int elementID, string attributeName, int elementType = 0)
        {

            //Local variables
            int index = 0;
            Boolean findingResult = false;

            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Loop through attribute name, to check if any of it element match given name
            for (int i = 0; i < this.AttributesName[elementTypeIndex].Count; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributesName[elementTypeIndex][i])
                {
                    index = i;
                    findingResult = true;
                    break;
                }
            }

            //Check if any of element match, if not return empty string
            if (findingResult)
            {
                return this.ElementsList[elementTypeIndex][elementID].AttributeValue[index];
            }
            else
            {
                return "";
            }

        }

        //Method used to find all values of given element name. 
        internal List<string> GetAllAttributeValue(int elementID)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Local variables
            List<string> retVal = new List<string>();

            //Collect all element values to the list
            foreach (string element in this.ElementsList[elementTypeIndex][elementID].AttributeValue)
            {
                retVal.Add(element);
            }

            return retVal;
        }
        internal List<string> GetAllAttributeValue(int elementID, int elementType)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Local variables
            List<string> retVal = new List<string>();

            //Collect all element values to the list
            foreach (string element in this.ElementsList[elementTypeIndex][elementID].AttributeValue)
            {
                retVal.Add(element);
            }

            return retVal;
        }

        //Method used to find all values of given element name nd return it as a dictionary where key = attribute name
        internal List<Dictionary<string, string>> GetAllAttributeValueAsDict(int elementID, int elementType)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Local variables
            List<Dictionary<string, string>> retVal = new List<Dictionary<string, string>>();
            int i = 0;

            //Collect all element values to the list
            foreach (string element in this.ElementsList[elementTypeIndex][elementID].AttributeValue)
            {
                string attributeName = this.AttributesName[elementTypeIndex][i];
                i++;

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add(attributeName, element);
                retVal.Add(dict);
            }

            return retVal;
        }

        //Method used to read attribute value from certain index
        internal string GetAttributNameOfIndex(int index)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Read attribut name from certain index
            return this.AttributesName[elementTypeIndex][index];

        }
        internal string GetAttributNameOfIndex(int index, int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Read attribut name from certain index
            return this.AttributesName[elementTypeIndex][index];

        }

        //Method used to change value of given element ID
        //Only first occurence of element will be changed.
        //If method does not find element with given ID it will generate an error
        internal void ChangeAttributeValue(List<int> uniqueIdetifierAttributes, int elementID, string attributeName, string newValue)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            try
            {
                //Check if element with given ID exist
                if (elementID > this.ElementsList[elementTypeIndex].Count - 1)
                {
                    throw new System.ArgumentException($"Given element ID does not exist. Element ID: {elementID}. Attribute name: {attributeName}");
                }
                else
                {
                    //Loop through attribute name, to check if any of it element match given name
                    for (int i = 0; i < this.AttributesName[elementTypeIndex].Count; i++)
                    {
                        //If attribueName match, save index and break;
                        if (attributeName == this.AttributesName[elementTypeIndex].ElementAt(i))
                        {
                            //Override value
                            this.ElementsList[elementTypeIndex][elementID].AttributeValue[i] = newValue;
                            break;
                        }
                    }
                }

                //Create identifier fo an elemement
                if (uniqueIdetifierAttributes != null)
                {
                    string identifier = "";
                    foreach (int attIndex in uniqueIdetifierAttributes)
                    {
                        if (attIndex - 1 >= 0)
                        {
                            identifier = CreateIdentifier(this.ElementsList[elementTypeIndex].Last().AttributeValue[attIndex - 1], identifier);
                        }
                        else throw new InvalidOperationException("Próba generowania numeru identyfikacyjnego obiektu nie udana! Indes atrybutu mniejszy od 0");

                        this.ElementsList[elementTypeIndex].Last().UniqueIdentifier = identifier;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




        }
        internal void ChangeAttributeValue(List<int> uniqueIdetifierAttributes, int elementID, string attributeName, string newValue, int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            try
            {
                //Check if element with given ID exist
                if (elementID > this.ElementsList[elementTypeIndex].Count - 1)
                {
                    throw new System.ArgumentException($"Given element ID does not exist. Element ID: {elementID}. Attribute name: {attributeName}");
                }
                else
                {
                    //Loop through attribute name, to check if any of it element match given name
                    for (int i = 0; i < this.AttributesName[elementTypeIndex].Count; i++)
                    {
                        //If attribueName match, save index and break;
                        if (attributeName == this.AttributesName[elementTypeIndex].ElementAt(i))
                        {
                            //Override value
                            this.ElementsList[elementTypeIndex][elementID].AttributeValue[i] = newValue;
                        }
                    }
                }

                //Create identifier fo an elemement
                if (uniqueIdetifierAttributes != null)
                {
                    string identifier = "";
                    foreach (int attIndex in uniqueIdetifierAttributes)
                    {
                        if (attIndex - 1 >= 0)
                        {
                            identifier = CreateIdentifier(this.ElementsList[elementTypeIndex].Last().AttributeValue[attIndex - 1], identifier);
                        }
                        else throw new InvalidOperationException("Próba generowania numeru identyfikacyjnego obiektu nie udana! Indes atrybutu mniejszy od 0");

                        this.ElementsList[elementTypeIndex].Last().UniqueIdentifier = identifier;
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
        internal void ChangeAllElementsValue(List<int> uniqueIdetifierAttributes, string attributeName, string attributeID, params string[] values)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Find index of attribute with given name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i=0; i<this.ElementsList[elementTypeIndex].Count(); i++)
            {
                if (this.ElementsList[elementTypeIndex][i].AttributeValue[attributeIndex] == attributeID)
                {

                    //Change attribute value
                    for (int j = 0; j < values.Length; j++)
                    {
                        //Change everything except attribute with is taken as ID
                        if (this.AttributesName[elementTypeIndex][j] != attributeName)
                        {
                            this.ElementsList[elementTypeIndex][i].AttributeValue[j] = values[j];
                        }
                        
                    }
                    break;
                }
                else if(i == this.ElementsList[elementTypeIndex].Count() - 1)
                {
                    MessageBox.Show("Element with given ID was not found!");
                }
            }

            //Create identifier fo an elemement
            if (uniqueIdetifierAttributes != null)
            {
                string identifier = "";
                foreach (int attIndex in uniqueIdetifierAttributes)
                {
                    if (attIndex - 1 >= 0)
                    {
                        identifier = CreateIdentifier(this.ElementsList[elementTypeIndex].Last().AttributeValue[attIndex - 1], identifier);
                    }
                    else throw new InvalidOperationException("Próba generowania numeru identyfikacyjnego obiektu nie udana! Indes atrybutu mniejszy od 0");

                    this.ElementsList[elementTypeIndex].Last().UniqueIdentifier = identifier;
                }
            }

        }
        internal void ChangeAllElementsValue(List<int> uniqueIdetifierAttributes, string attributeName, string attributeID, int elementType = 0, params string[] values)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Find index of attribute with given name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i = 0; i < this.ElementsList[elementTypeIndex].Count(); i++)
            {
                if (this.ElementsList[elementTypeIndex][i].AttributeValue[attributeIndex] == attributeID)
                {

                    //Change attribute value
                    for (int j = 0; j < values.Length; j++)
                    {
                        //Change everything except attribute with is taken as ID
                        if (this.AttributesName[elementTypeIndex][j] != attributeName)
                        {
                            this.ElementsList[elementTypeIndex][i].AttributeValue[j] = values[j];
                        }

                    }
                    break;
                }
                else if (i == this.ElementsList[elementTypeIndex].Count() - 1)
                {
                    MessageBox.Show("Element with given ID was not found!");
                }
            }

            //Create identifier fo an elemement
            if (uniqueIdetifierAttributes != null)
            {
                string identifier = "";
                foreach (int attIndex in uniqueIdetifierAttributes)
                {
                    if (attIndex - 1 >= 0)
                    {
                        identifier = CreateIdentifier(this.ElementsList[elementTypeIndex].Last().AttributeValue[attIndex - 1], identifier);
                    }
                    else throw new InvalidOperationException("Próba generowania numeru identyfikacyjnego obiektu nie udana! Indes atrybutu mniejszy od 0");

                    this.ElementsList[elementTypeIndex].Last().UniqueIdentifier = identifier;
                }
            }

        }

        //Method used to change all value of given element name
        //Only first occurence of element will be changed.;
        internal void ChangeAllElementsAttribute(string attributeName, params string[] values)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Find index of attribute with given name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i = 0; i < this.ElementsList[elementTypeIndex].Count(); i++)
            {
                //Change attribute value
                for (int j = 0; j < values.Length; j++)
                {
                    //Change everything except attribute with is taken as ID
                    if (this.AttributesName[elementTypeIndex][j] != attributeName)
                    {
                        this.ElementsList[elementTypeIndex][i].AttributeValue[j] = values[j];
                    }

                }
            }

        }
        internal void ChangeAllElementsAttribute(string attributeName, int elementType = 0, params string[] values)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Find index of attribute with given name
            int attributeIndex = this.AttributesName[elementTypeIndex].IndexOf(attributeName);

            //Find element index using given attribute index
            for (int i = 0; i < this.ElementsList[elementTypeIndex].Count(); i++)
            {
                //Change attribute value
                for (int j = 0; j < values.Length; j++)
                {
                    //Change everything except attribute with is taken as ID
                    if (this.AttributesName[elementTypeIndex][j] != attributeName)
                    {
                        this.ElementsList[elementTypeIndex][i].AttributeValue[j] = values[j];
                    }

                }
            }

        }

        //Method used to delete given attribute and its value
        //Only first occurence of element will be deleted.
        internal void DeleteAttribute(string attributeName)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Remove attribut and its value
            this.AttributesName[elementTypeIndex].Remove(attributeName);

        }
        internal void DeleteAttribute(string attributeName, int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Remove attribut and its value
            this.AttributesName[elementTypeIndex].Remove(attributeName);

        }

        //Method used to add list of string to an object
        //If list lenght is greater then number of attributes, it will change only existing attributes
        internal void StringListToAttributesValue(List<int> uniqueIdetifierAttributes, int elementID, List<string> inputStringList)
        {
            int elementType = 0;
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Check input string array lenght
            int arrayLenght = inputStringList.Count, i = 0;

            //Check number of attributes
            int attributsNumber = this.AttributesName[elementTypeIndex].Count;

            //Change attribute value by Name
            foreach (string attribute  in this.AttributesName[elementTypeIndex])
            {
                if (i <= arrayLenght - 1)
                {
                    ChangeAttributeValue(uniqueIdetifierAttributes, elementID, attribute, inputStringList.ElementAt(i));
                }   
                else
                {
                    break;
                }
                i++;
            }
        }
        internal void StringListToAttributesValue(List<int> uniqueIdetifierAttributes, int elementID, List<string> inputStringList, int elementType = 0)
        {
            int elementTypeIndex = GetElementTypeIndex(elementType);

            //Check input string array lenght
            int arrayLenght = inputStringList.Count, i = 0;

            //Check number of attributes
            int attributsNumber = this.AttributesName[elementTypeIndex].Count;

            //Change attribute value by Name
            foreach (string attribute in this.AttributesName[elementTypeIndex])
            {
                if (i <= arrayLenght - 1)
                {
                    ChangeAttributeValue(uniqueIdetifierAttributes, elementID, attribute, inputStringList.ElementAt(i), elementType);
                }
                else
                {
                    break;
                }
                i++;
            }
        }

        //Method used to add attributes from list
        internal void AddAttributesFromList(List<string> attributesNames)
        {

            foreach (string element in attributesNames)
            {
                AddAttributeName(element);
            }
        }
        internal void AddAttributesFromList(List<string> attributesNames, int elementType)
        {

            foreach (string element in attributesNames)
            {
                AddAttributeName(element, elementType);
            }
        }


        //Method used to get identifier if exist
        internal int SelectElementUniqueId(string pattern, string idMark)
        {
            //Local variable
            Regex regx = new Regex(" ");
            List<string> retVal = new List<string>();
            string[] dividedNames;
            string elementMarkUniqueIdTemp = null;
            int elementMarkUniqueId = 0;

            //Clear input string
            pattern = pattern.Replace("<", "").Replace(">", "").Replace("\t", " ");

            //Split input string into string array
            dividedNames = regx.Split(pattern);

            //Check if element unique identifier exist
            if(dividedNames.Any<string>(e => e.Contains(idMark)))
            {
                elementMarkUniqueIdTemp = dividedNames.Where<string>(e => e.Contains(idMark)).FirstOrDefault();
                if(elementMarkUniqueIdTemp != null)
                {
                    elementMarkUniqueIdTemp.Trim();
                    elementMarkUniqueIdTemp = elementMarkUniqueIdTemp.Replace(idMark, "");
                    try
                    {
                        elementMarkUniqueId = Int32.Parse(elementMarkUniqueIdTemp);
                    }
                    catch (FormatException)
                    {
                        elementMarkUniqueId = 0;
                    }

                }
            }
            else
            {
                elementMarkUniqueId = 0;
            }

            return elementMarkUniqueId;
        }

    }
    #endregion    
}
