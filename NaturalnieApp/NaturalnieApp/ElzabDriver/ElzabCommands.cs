using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace NaturalnieApp.ElzabDriver
{

    class ElzabFileStruct
    {
        List<string> FileHeader;

        List<ElzabCommElementObject> ListOfFileElements;
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OTOWAR : ElzabCommandGeneral
    {
        private string CommandName { get; }
        private string Path { get; }

        private string InputFile

            FileType.

        public List<ElzabCommElementObject> DataToSend { get; set; }
        public List<ElzabCommElementObject> DataReceived { get; set; }

        public ElzabCommand_OTOWAR(string elzabCommandPath)
        {       
            //Local variable
            List<string> attributesNamesInFile = new List<string>();
            List<string> attributesNamesOutFile = new List<string>();
            List<ElzabCommElementObject> DataToSend = new List<ElzabCommElementObject>();
            List<ElzabCommElementObject> DataReceived = new List<ElzabCommElementObject>();
            this.Path = elzabCommandPath;

            //###############################################################################################
            //Variable used to call comand. Class create output and in file with same name, adding *in/*out, to it.
            this.CommandName = "OTOWAR";

            //Define input file attributes
            attributesNamesInFile = attributeNameFromDoc("$nr_unik");

            //Define output file attributes
            attributesNamesOutFile = attributeNameFromDoc("< plu_no > < art_name > < tax_rate_no > " +
                    "< dept_no > < quantity_precision > < unit_no > < sale_bloc > < main_barcode > " +
                    "< price > < is_pack > < disc_sur_bloc > < free_price_allow > < on_handy_list > " +
                    "< scale_no > < last_sale_date_time >link_plu_no >");

            InitElzabData(attributesNamesInFile, attributesNamesOutFile, ref DataToSend, ref DataReceived);

        }



    }
    //-----------------------------------------------------------------------------------------------------------------------------------------
    /*public abstract class ElzabCommandGeneral : ElzabCommandFileHandling
    {
        private string CommandName{ get; }
        private string Path { get; }

        //Class constructor
        public void InitElzabData(List<string> attributesNamesInFile, 
            List<string> attributesNamesOutFile, 
            ref List<ElzabCommElementObject> dataToSend, ref List<ElzabCommElementObject> dataReceived)
        {
            //Initialize atributes in input file of given command
            foreach (string element in attributesNamesInFile)
            {
                dataToSend.AddAttributeName(element);
            }

            //Initialize atributes in out file of given command
            foreach (string element in attributesNamesOutFile)
            {
                dataReceived.AddAttributeName(element);
            }
        }
        public void ExecuteCommand()
        {
            ExecuteCommand(this.Path, this.CommandName);
        }

        public void AddHeaderToFile()
        {

        }

        //Method used to prepare raw data from Elzab documentation
        protected List<string> attributeNameFromDoc(string attributesNames)
        {
            //Local variable
            Regex regx = new Regex(">|$");
            List<string> retVal = new List<string>();
            string[] dividedNames;

            //Clear input string
            attributesNames = attributesNames.Replace("<", "").Replace("$", "");

            //Split input string into string array
            dividedNames = regx.Split(attributesNames);

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


    }
    */
    //-----------------------------------------------------------------------------------------------------------------------------------------
    class ElzabFileObject : ElzabCommandFileHandling
    {
        private string AttributesSeparator { get; set; }
        private string HeaderMark { get; set; }
        private string HeaderSeparator { get; set; }
        private string CommentMark { get; set; }
        private string ElementMark { get; set; }
        private string Path { get; }
        private string CommandName { get; }
        private FileType TypeOfFile { get; }
        public ElzabFileHeaderStructure Header { get; set; }
        public List<ElzabCommElementObject> ElementList { get; set; }
        public List<string> RawData { get; set; }
        private string HeaderPattern { get; set; }
        private string ElementsPatter { get; set; }


        public class ElzabFileHeaderStructure
        {
            ElzabCommElementObject Line1 { get; set; }
            ElzabCommElementObject Line2 { get; set; }
            ElzabCommElementObject Line3 { get; set; }
        }

        public void InitializePattern(string headerPattern, string elementPatter)
        {

        }

        //Class constructor
        public ElzabFileObject(string path, string commandName, FileType typeOfFile )
        {
            //Create instance of header object
            this.Header = new ElzabFileHeaderStructure();

            //Create instance of Raw data object
            this.RawData = new List<string>();

            //Initialize object variables
            this.Path = path;
            this.CommandName = commandName;
            this.TypeOfFile = typeOfFile;

        }



        //Method used to set basic information about file
        public void SetMarksAndSeparators(string attributeSeparator = " ", string headerMark = "#",
                                        string headerSeparator = " ", string commentMark = ";",
                                        string elementMark = "$")
        {
            //Set values to variables
            this.AttributesSeparator = attributeSeparator;
            this.HeaderMark = headerMark;
            this.HeaderSeparator = headerSeparator;
            this.CommentMark = commentMark;
            this.ElementMark = elementMark;
        }
        public void GenerateObjectFromRawData()
        {
            //Read raw data from file
            this.RawData = ReadDataFromFile(this.Path, this.CommandName, this.TypeOfFile);

            //Parse data
        }

        public void GenerateRawDataFromObject()
        {

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

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public abstract class ElzabCommandFileHandling
    {
        private string elzabFilePath { get; set; }
        private string elzabCommandName { get; set; }

        //Define file type as enum
        public enum FileType
        {
            Inputfile, OutputFile, ConfigFile, ReportFile
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
        private string FileNameDependingOfType(string commandName, FileType typeOfFile)
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
                MessageBox.Show("Specified file does not exist or cannot be opened. File: " + fullPath);
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
    public class ElzabCommElementObject
    {
        //Define class elements
        private List<string> ElementName { get; set; }
        private List<string> AttributeName { get; set; }
        private List<string> AttributeValue { get; set; }

        public ElzabCommElementObject()
        { 
            this.AttributeName = new List<string>();
            this.AttributeValue = new List<string>();
        }

        //Method used to add new attribute and its value to the element
        public void AddAttribute(string attributeName, string attributeValue)
        {
            this.AttributeName.Append(attributeName);
            this.AttributeValue.Append(attributeValue);
        }

        //Method used to add new attribute to the element
        public void AddAttributeName(string attributeName)
        {
            this.AttributeName.Add(attributeName);
            //As attribute value, use empty string
            this.AttributeValue.Add("");
        }


        //Method used to find value of given element name. 
        //Only first occurence of element will be found.
        //If nothing found, return empty string
        public string FindAttribute(string attributeName)
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
                return this.AttributeValue[index];
            }
            else
            {
                return "";
            }
            
        }

        //Method used to change value of given element name
        //Only first occurence of element will be changed.
        public void ChangeAttribute(string attributeName, string newValue)
        {
            //Loop through attribute name, to check if any of it element match given name
            for (int i = 0; i < this.AttributeName.Count; i++)
            {
                //If attribueName match, save index and break;
                if (attributeName == this.AttributeName[i])
                {
                    //Override value
                    this.AttributeValue[i] = newValue;
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

        //Method used to add element
        public void AddElement(string elementName, params string[] attributNameAndValue )
        {
            //Local variabe
            string[] splittedString;

            foreach (string element in attributNameAndValue )
            {
                splittedString = element.Split('=');
                ChangeAttribute(splittedString[0], splittedString[1]);
            }


        }

        //Method used to add series of string to object
        //If array lenght is bigger then number of attributes, it will change only existing attributes
        public void StringArrayToAttributesValue(string[] inputStringArray)
        {
            //Check input string array lenght
            int arrayLenght = inputStringArray.Length, i = 0;

            //Check number of attributes
            int attributsNumber = this.AttributeName.Count;

            //Change attribute value by Name
            foreach (string attribute  in this.AttributeName)
            {
                if (arrayLenght <= i)
                {
                    ChangeAttribute(attribute, inputStringArray[i]);
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
                AddAttribute(element, "");
            }
        }

    }
    #endregion    
}
