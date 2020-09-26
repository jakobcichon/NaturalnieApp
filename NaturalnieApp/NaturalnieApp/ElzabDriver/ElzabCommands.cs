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

namespace NaturalnieApp.ElzabDriver
{
    public abstract class ElzabCommandGeneral: ElzabCommElementObject
    {
        private string elementMark { get; set; }
        private string attributsDivider { get; set; }
        private string fileHeader { get; set; }
        private string elzabFilePath { get; set; }
        private string elzabCommandName { get; set; }

        private enum FileType
        {
            Inputfile, OutputFile, ConfigFile, ReportFile
        }

        //Method used to add Elzab command name
        protected void SetElzabCommandName(string elzabCommandName)
        {
            this.elzabCommandName = elzabCommandName;
        }

        //Method used to open file from given path.
        //It return all lines of file as array of strings
        private List<string> OpenFiles(string path)
        {
            //Local variable
            List<string> fileToArray = new List<string>();

            //Open file and read all lines to string array
            try
            {
                using (var file = new StreamReader(path))
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

        public void ParseListToObject(List<string> inputList)
        { 
            //Add attribute name to the element
            foreach (string element in inputList)
            {
                AddAttributeName(element);
            }
 
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
        private bool CheckIfFileExist(string path, string commandName, FileType typeOfFile)
        {
            //Local variables
            bool retVal = false;

            string fullPath = path + "\\" + FileNameDependingOfType(commandName, typeOfFile);

            //Chceck if input file exist
            retVal = File.Exists(fullPath);

            return retVal;
        }

        //Method use to create input or config file
        private void CreateFile(string path, string commandName, FileType typeOfFile)
        {
            //Check if given file is the proper one
            if (typeOfFile == FileType.Inputfile || typeOfFile == FileType.ConfigFile)
            {

                string fullPath = path + "\\" + FileNameDependingOfType(commandName, typeOfFile);

                try
                {
                    
                }
            }



        }

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

        //Method use to create input file
        private bool CheckIfInputFileExist(string path, string commandName)
        {
            //Local variables
            bool retVal = false;
            string fullPath = path + "\\" + commandName + "IN.txt";

            //Chceck if input file exist
            retVal = File.Exists(fullPath);

            return retVal;
        }

        private void PrepareDataToWritetoFile(List<ElzabCommElementObject> objectsToWrite, string header)
        {
            //Local variable
            List<string> dataToWrite = new List<string>();

            //Add header
            fileHeader = header;

            //Add data
        }

        //Method used to execute specified Elzab command
        private void ExecuteCommand (string commandName)
        {

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
        private string ElementName { get; set; }
        private List<string> AttributeName { get; set; }
        private List<string> AttributeValue { get; set; }

        public ElzabCommElementObject(): this("")
        {
            
        }
        public ElzabCommElementObject(string elementName)
        {
            this.AttributeName = new List<string>();
            this.AttributeValue = new List<string>();
            this.ElementName = elementName;
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

    }
    #endregion

    //-----------------------------------------------------------------------------------------------------------------------------------------
    public class ElzabCommand_OTOWAR : ElzabCommandGeneral
    {
        public ElzabCommElementObject DataToSend { get; set; }

        public ElzabCommElementObject DataReceived { get; set; }

        //Class constructor
        public ElzabCommand_OTOWAR(string elzabCommandPath)
        {
            //Local variable
            List<string> attributesNamesInFile = new List<string>();
            List<string> attributesNamesOutFile = new List<string>();

            //###############################################################################################
            //Variable used to call comand. Class create output and in file with same name, adding *in/*out, to it.
            string commandName = "OTOWAR";

            //Define input file attributes
            attributesNamesInFile = attributeNameFromDoc("$nr_unik");

            //Define output file attributes
            attributesNamesOutFile = attributeNameFromDoc("< plu_no > < art_name > < tax_rate_no > " +
                "< dept_no > < quantity_precision > < unit_no > < sale_bloc > < main_barcode > " +
                "< price > < is_pack > < disc_sur_bloc > < free_price_allow > < on_handy_list > " +
                "< scale_no > < last_sale_date_time >link_plu_no >");

            //###############################################################################################

            //Method used to send basic information to child class
            SetElzabCommandName(commandName);
            AddPathToElzabFiles(elzabCommandPath);

            //Create input file instance
            this.DataToSend = new ElzabCommElementObject();
            foreach (string element in attributesNamesInFile)
            {
                this.DataToSend.AddAttributeName(element);
            }

            //Create input file instance
            this.DataReceived = new ElzabCommElementObject();
            foreach (string element in attributesNamesOutFile)
            {
                this.DataReceived.AddAttributeName(element);
            }
        }

        public void ExecuteCommand()
            {
                
            }


        //Method used to prepare raw data from Elzab documentation
        private List<string> attributeNameFromDoc(string attributesNames)
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
            for (int i=0; i<dividedNames.Length; i++)
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

            //Return v
            return retVal;
        }
        
    }
}
