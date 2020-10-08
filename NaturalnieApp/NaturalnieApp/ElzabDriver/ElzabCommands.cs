using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace ElzabDriver
{



    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OTOWAR: ElzabFileObject
    {
        //Local variable
        public ElzabFileObject DataFromElzab { get; set; }
        public ElzabFileObject DataToElzab { get; set; }
        private string CommandName = "OTOWAR";

        //Class constructor
        public ElzabCommand_OTOWAR(string path, int cashRegisterID)
        {
            //Initialize object containing information from ELZAB
            this.DataFromElzab = new ElzabFileObject(path, CommandName, FileType.OutputFile,
                elementAttributesPattern : "< plu_no > < art_name > < tax_rate_no > " +
            "< dept_no > < quantity_precision > < unit_no > < sale_bloc > < main_barcode > " +
            "< price > < is_pack > < disc_sur_bloc > < free_price_allow > < on_handy_list > " +
            "< scale_no > < last_sale_date_time >link_plu_no >");

            //Initialize object containing information to ELZAB
            this.DataToElzab = new ElzabFileObject(path, CommandName, FileType.Inputfile,
                headerPatternLine1 : "< device_number >",
                headerPatternLine2: "< dummy >",
                headerPatternLine3: "< dummy >",
                elementAttributesPattern: "< nr_tow > ");

            //Initialize basic header information
            this.DataToElzab.Header.HeaderLine1.AddElement();
            this.DataToElzab.Header.HeaderLine1.ChangeAttributeValue(0, "device_number", cashRegisterID.ToString());
            this.DataToElzab.Header.HeaderLine2.AddElement();
            this.DataToElzab.Header.HeaderLine2.ChangeAttributeValue(0, "", "");
            this.DataToElzab.Header.HeaderLine3.AddElement();
            this.DataToElzab.Header.HeaderLine3.ChangeAttributeValue(0, "", "");

            

        }

    }

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
        Inputfile, OutputFile, ConfigFile, ReportFile
    }


    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabFileObject : ElzabCommandFileHandling
    {
        private string AttributesSeparator { get; set; }
        private string HeaderMark { get; set; }
        private string HeaderSeparator { get; set; }
        private string CommentMark { get; set; }
        private string ElementMark { get; set; }
        private string Path { get; }
        private string CommandName { get; }
        private FileType TypeOfFile { get; }
        public ElzabCommHeaderObject Header { get; set; }
        public ElzabCommElementObject Element { get; set; }
        public List<string> RawData { get; set; }

        //Class constructor
        public ElzabFileObject()
        {

        }

        public ElzabFileObject(string path, string commandName, FileType typeOfFile, 
            string headerPatternLine1 = "< cash_register_number > < cash_register_comm_data > < comm_timeout > <execution_date >" +
            "< execution_time > < command_name > < version_number> < input_file_name > <output_file_name>", 
            string headerPatternLine2 = " < error_number > < error_text > ", string headerPatternLine3 = " <cash_register_id > ",
            string elementAttributesPattern = " < empty_element>")
        {

            //Initialize object variables
            this.Path = path;
            this.CommandName = commandName;
            this.TypeOfFile = typeOfFile;

            //Create instance of Raw data object
            this.RawData = new List<string>();
            
            //Call method used to set marks and separators
            SetMarksAndSeparators();

            //Create instance of header object and initialize it
            this.Header = new ElzabCommHeaderObject();
            this.Header.HeaderLine1.AddAttributesFromList(ParsePattern(headerPatternLine1));
            this.Header.HeaderLine2.AddAttributesFromList(ParsePattern(headerPatternLine2));
            this.Header.HeaderLine3.AddAttributesFromList(ParsePattern(headerPatternLine3));

            //Create instance of element object and initialize it
            this.Element = new ElzabCommElementObject();
            this.Element.AddAttributesFromList(ParsePattern(elementAttributesPattern));

        }

        //Method used to set basic information about file
        public void SetMarksAndSeparators(char attributeSeparator = '\t', char headerMark = '#',
                                        char headerSeparator = '\t', char commentMark = ';',
                                        char elementMark = '$')
        {
            //Set values to variables
            this.AttributesSeparator = attributeSeparator.ToString();
            this.HeaderMark = headerMark.ToString();
            this.HeaderSeparator = headerSeparator.ToString();
            this.CommentMark = commentMark.ToString();
            this.ElementMark = elementMark.ToString();
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
                    ElzabCommElementObject tempObject;

                    //Remove mark sign
                    clearedElement = element.Replace(this.ElementMark.Replace("\\",""), "");

                    //Read every element and add it to an object
                    this.Element.AddElement();
                    this.Element.StringListToAttributesValue(this.Element.GetLastElementID(), ParseStringToList(clearedElement, this.AttributesSeparator));
                }
            }
        }

        public void RunCommand()
        {
            string command = this.CommandName + ".exe" + " " + this.FileNameDependingOfType(this.CommandName, FileType.Inputfile)
                + " " + this.FileNameDependingOfType(this.CommandName, FileType.OutputFile);

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = this.Path;
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = "/C " + command;
            Process proc = Process.Start(processStartInfo);
            ;
        }

            public void GenerateRawDataFromObject()
        {
            //Local variable
            List<string> retValue = new List<string>();

            //Convert header object to string list
            retValue.Add(ConvertFromListToString(this.Header.HeaderLine1.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));
            retValue.Add(ConvertFromListToString(this.Header.HeaderLine2.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));
            retValue.Add(ConvertFromListToString(this.Header.HeaderLine3.GetAllAttributeValue(0), this.HeaderMark, this.HeaderSeparator));

            //Convert element object to string list
            foreach (AttributeValueObject obj in this.Element)
            {
                //Loop through all element attributes values. Add Element mark and attribute separator to it
                string elementAllValues = this.ElementMark;
                foreach (string attributeValue in obj)
                {
                    elementAllValues += attributeValue + this.AttributesSeparator;            
                }
                retValue.Add(elementAllValues);
            }

            //Assing created string list to internal variable
            this.RawData = retValue;
            
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

        public void ChangeAllElementValues(int elementID, params string[] values)
        {
            this.Element.ChangeAllElementValues(elementID, values);

        }

        //Method used to add element to the object
        public void AddElement()
        {
            this.Element.AddElement();
        }

        public void WriteRawDataToFile(string path, string commandName, FileType typeOfFile, List<string> dataToWrite)
        {
            this.WriteDataToFile(path, commandName, typeOfFile, dataToWrite);
        }

        //Method used to prepare raw data from Elzab documentation
        private List<string> ParsePattern(string pattern)
        {
            //Local variable
            Regex regx = new Regex(">|$");
            List<string> retVal = new List<string>();
            string[] dividedNames;

            //Clear input string
            pattern = pattern.Replace("<", "").Replace("$", "");

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
        List<string> ParseStringToList(string inputString, string divider)
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

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public abstract class ElzabCommandFileHandling
    {
        private string elzabFilePath { get; set; }
        private string elzabCommandName { get; set; }

        //Define file type as enum

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
        private void SaveDataToFile(string fullPath, List<string> data)
        {
            try
            {
                //Use File stream to write data to file
                using (StreamWriter fs = File.CreateText(fullPath))
                {
                    foreach (string lineToWrite in data)
                    {
                        fs.WriteLine(lineToWrite);
                    }

                    //Close file
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                //Message if exception
                MessageBox.Show(ex.ToString());
            }
        }

        //Method use to create input or config file
        private void CreateFile(string fullPath)
        {
            try
            {
                //Use File stream to creale file
                using (StreamWriter fs = File.CreateText(fullPath))
                {
                    //Close file
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                //Message if exception
                MessageBox.Show(ex.ToString());
            }
            
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
                case FileType.Inputfile:
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
        public void WriteDataToFile(string path, string commandName, FileType typeOfFile, List<string> dataToWrite)
        {
            //Local variables
            string fullPath;
            bool fileExist;

            //Generate full path to file
            fullPath = ConsolidatePath(path, commandName, typeOfFile);

            //Check if given file exist
            fileExist = CheckIfFileExist(fullPath);
            if (fileExist)
            {
                //Call method to write data to file
                SaveDataToFile(fullPath, dataToWrite);
            }
            //If file/path not valid, show message box
            else
            {
                //If file does not exist, create one
                CreateFile(fullPath);

                //Call method to write data to file
                SaveDataToFile(fullPath, dataToWrite);
            }
        }

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    #region Elzab command element class
    //Class used to define single element of Elzab command.
    //Below visual explanation of naming convesion.
    //=====================================================
    //                   |  "AttributeName" = 1               |  "AttributeName" = 2            |
    //  "ElementName"    |  "AttributeValue" = TestValue1     |   "AttributeValue" = TestValue2 |

    public class AttributeValueObject: IEnumerable<string>
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
                this.ElementsList.Last().AttributeValue.Add("");
            }
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
        public void ChangeAllElementValues(int elementID, params string[] values)
        {
            //Check if number of given numbers, are not greater than number of element valuess
            if (values.Length > this.ElementsList[elementID].AttributeValue.Count)
            {
                MessageBox.Show("Number of parameters to change are bigger than number of attribute values. " +
                    "Debug: ElzabCommElementObject.ChangeAllElementValues");
            }
            else
            {

                //Change attribute value
                for (int i = 0; i < values.Length; i++)
                {
                    this.ElementsList[elementID].AttributeValue[i] = values[i];
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
