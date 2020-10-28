using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace NaturalnieApp.Initialization
{
    public class ConfigFileObject
    {
        private ConfigFile ConfigFileInst { get; set; }
        public List<ConfigElement> ConfigFileElements { get; set; }


        public ConfigFileObject()
        {
            ConfigFileInst = new ConfigFile();
            ConfigFileInst.InitializeConfigFile("\\config\\config.txt", "");

            ConfigFileElements = new List<ConfigElement>();
            ConfigFileElements = ConfigFileInst.ReadConfigFileElement(ConfigFileInst.FullPath);
        }

        //Method used to get variable value by variable name
        public string GetValueByVariableName(string variableName)
        {
            //Return variable
            string retVal = "";

            //Scan throught Config Element list and return Variable value if name match
            foreach (ConfigElement element in this.ConfigFileElements)
            {
                if (element.ElementName == variableName)
                {
                    retVal = element.ElementValue;
                    break;
                }
            }

            return retVal;
        }

        //Method used to change value of given variable
        public void ChangeVariableValue(string variableName, string variableValue)
        {
            //Local variable
            int indexOfElement = -1;

            foreach (ConfigElement element in this.ConfigFileElements)
            {
                if (element.ElementName == variableName)
                {
                    indexOfElement = this.ConfigFileElements.IndexOf(element);
                }
            }

            if (indexOfElement != -1)
            {
                this.ConfigFileElements[indexOfElement].ElementValue = variableValue;
            }
        }

        //Method used to list all varriables in config file
        public string[] ListAllVariables()
        {
            //Local variable
            string[] retVal = new string[this.ConfigFileElements.Count];
            int i = 0;

            //Scan throught all variable names and return it
            foreach (ConfigElement element in this.ConfigFileElements)
            {
                retVal[i] = element.ElementName;
                i++;
            }

            return retVal;
        }

        //Method used to save current data from object fo text file
        public void SaveData()
        {
            ;
        }

    }

    //==================================================================================
    //ConfigElement class used to properly parse single element from config file.
    // Patter used to parse config element: Variable name starts from "#"; Variable value in same line with varibale Name and starts with "=";
    public class ConfigElement
    {
        //Declare class elements
        public string ElementName { get; set; }
        public string ElementValue { get; set; }
        public string ElementComment { get; set; }

        //Class constructor
        public ConfigElement(string name, string value, string comment = @"\\Default comment")
        {
            this.ElementName = name;
            this.ElementValue = value;
            this.ElementComment = comment;
        }

        //Method used to clean a little bit name and value 
        public void ClearElementName()
        {
            ElementName = ElementName.Replace(@"#", @"").Trim();
            ElementComment = ElementComment.Replace(@"\\", @"").Trim();
        }

        //Metod used to prepare element comment, to be written into text file
        public string PrepareCommentToWrite()
        {
            //New string variable to be returned
            string retVal = @"\\" + this.ElementComment;

            //Return value
            return retVal;
        }

        //Metod used to prepare element data, to be written into text file
        public string PrepareDataToWrite()
        {
            //New string variable to be returned
            string retVal = @"\\" + this.ElementComment + "\n" + "#" + this.ElementName + " = " + this.ElementValue;

            //Return value
            return retVal;
        }


    }
    class ConfigFile
    {
        //Declare class elements
        public string FullPath { get; set; }

        //==================================================================================
        //Metod use to create full config file information
        public void InitializeConfigFile(string fileName, string path = "")
        {

            //Consolidate path
            this.FullPath = ConsolidatePathAndFile(path, fileName);

            // Check if directory exist, if not create one
            //CreateDirectory(path, fileName);
            VerifyAndCreateFullPath(this.FullPath);

            //Check if file exist, if not create one
            CreateConfigFile(this.FullPath);

        }

        //==================================================================================
        //Method used to scan through config file and read all of its elements
        public List<ConfigElement> ReadConfigFileElement(string path)
        {

            Regex rVariableName = new Regex(@"^.*#.*$");
            Regex rPattern = new Regex("=");
            List<ConfigElement> configElements = new List<ConfigElement>();
            try
            {
                // Open the text file using a stream reader.
                using (var file = new StreamReader(path))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (rVariableName.IsMatch(line))
                        {
                            string[] element;
                            element = rPattern.Split(line);
                            configElements.Add(new ConfigElement(element[0], element[1].Trim()));
                        }

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //Clear config elements. By clear means remove variable marker "#" and value marker "="
            for (int i = 0; i < configElements.Count; i++)
            {
                configElements[i].ClearElementName();
            }

            return configElements;
        }

        //==================================================================================
        //Method check if given path is valid. If not it create one.
        private void VerifyAndCreateFullPath(string path)
        {
            //Local variables
            Regex r = new Regex(@"\\");
            string[] directoryList;
            string pathToVerify = "";
            bool bPathExist;

            //Split given path into list
            directoryList = r.Split(path);

            //Verify full path. If any of directory does not exist, create one
            for (int i=0; i<(directoryList.Length - 1); i++)
            {
                //Assigne first element without slash
                pathToVerify += directoryList[i] + "\\"; 

                //Verify path
                bPathExist = Directory.Exists(pathToVerify);

                //If given path does not exist, create directory
                if (!bPathExist)
                {
                    try
                    {
                        Directory.CreateDirectory(pathToVerify);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                }
            }
        }

        //==================================================================================
        //Check if config file exist. If path not specify, use current path.
        private bool CheckIfConfigFileExist(string fileName, string path = "")
        {
            //If path not specofied, used current diectory
            if (path == "")
            {
                path = Directory.GetCurrentDirectory();
            }

            bool dExist = false;
            string fullPath = path + "\\" + fileName;
            dExist = File.Exists(fullPath);
            return dExist;
        }

        //==================================================================================
        //Create file under specify path. fileName must include file extension
        //If file with given name does not exist under given path method will create a new file
        // and return "True".
        //Otherwise method return "False"
        bool CreateFile(string path)
        {
            //Local variable
            bool fExist, retVal = false;

            //Check if directory exist
            fExist = CheckIfConfigFileExist(path);

            //Create file of not exist
            if (!fExist)
            {
                try
                {
                    //Use File stream to creale file
                    using(FileStream fs = File.Create(path))
                    {
                        retVal = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    //Message if exception
                    MessageBox.Show(ex.ToString());
                }
                
            }

            //Return value
            return retVal;

        }

        //==================================================================================
        //Check if config directory exist. If path not specify, use current path.
        List<ConfigElement> TemplateConfigFile()
        {
            //Create new list with ConfigElement type
            List<ConfigElement> retList = new List<ConfigElement>();

            //Template of config file

            //Get current path of applciation and add "config" to it
            string fullPath = Directory.GetCurrentDirectory() + "\\config\\";
            //Add first element to list
            retList.Add(new ConfigElement("ElzabCommandPath", fullPath, "Elzab command path"));

            //Add next element to list
            retList.Add(new ConfigElement("ElzabCOMPort", "COM3", "Elzab default COM port"));

            //Add next element to list
            retList.Add(new ConfigElement("ElzabBaudRate", "115200", "Elzab default baud rate"));

            //Add next element to list
            retList.Add(new ConfigElement("DatabseName", "TestDatabaseName", "Test database name"));

            //To Add next element to list, act as above
            //Placeholder for next element

            //Return value
            return retList;

        }

        //==================================================================================
        void CreateConfigFile(string path, List<ConfigElement> DataToWrite = null)
        {
            bool fCreated;
            List<ConfigElement> configDataToWrite;
            if (DataToWrite == null)
            {
                configDataToWrite = new List<ConfigElement>();
            }
            else
            {
                configDataToWrite = DataToWrite;
            }
                 
            //Verify if fileName contain proper .txt extension
            Regex r = new Regex(@"^.*\.txt$");

            //Call method to create new file
            fCreated = CreateFile(path);

            //If file created successfully, fill it with template
            if (fCreated)
            {
                configDataToWrite = TemplateConfigFile();

                try
                {
                    // Open the text file using a stream reader.
                    using (var file = new StreamWriter(path))
                    {

                        foreach (ConfigElement element in configDataToWrite)
                        {
                            file.WriteLine(element.PrepareDataToWrite());
                            file.WriteLine("\n");
                        }

                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }
            else
            {

                try
                {
                    // Open the text file using a stream reader.
                    using (var file = new StreamWriter(path))
                    {
                        file.Write("");
                        foreach (ConfigElement element in configDataToWrite)
                        {
                            file.WriteLine(element.PrepareDataToWrite());
                            file.WriteLine("\n");
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

        }

        //==================================================================================
        string ConsolidatePathAndFile(string path, string fileName)
        {
            //Local variable
            string fullPath = "";
            Regex r = new Regex(@"^\\.*$");

            //Verify if file name match pattern
            if (r.IsMatch(fileName))
            {
                //Check if path empty
                if (path == "")
                {
                    fullPath = Directory.GetCurrentDirectory() + fileName;
                }
                else
                {
                    fullPath = path + fileName;
                }
            }
            else
            {
                //Check if path empty
                if (path == "")
                {
                    fullPath = Directory.GetCurrentDirectory() + "\\" + fileName;
                }
                else
                {
                    fullPath = path + "\\" + fileName;
                }
            }

            //Return variable
            return fullPath;
        }





    }
        
}
