using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NaturalnieApp.Initialization
{
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
            string retVal = "\\\\" + this.ElementComment + "\\n" + "#" + this.ElementName + " = " + this.ElementValue;

            //Return value
            return retVal;
        }
    }
    class ConfigFile
    {

        //==================================================================================
        //Check if config directory exist. If path not specify, use current path.
        private bool CheckIfConfigDirectoryExist(string directoryName, string path = "")
        {
            //If path not specofied, used current diectory
            if (path == "")
            {
                path = Directory.GetCurrentDirectory();
            }

            bool dExist = false;
            string fullPath = path + "\\" + directoryName;
            dExist = Directory.Exists(fullPath);
            return dExist;
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
        //Create directory under specify path.
        private void CreateDirectory(string directoryName, string path = "")
        {
            bool fExist = false;
            string fullPath;

            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + "\\" + directoryName;
            }
            else
            {
                fullPath = path + "\\" + directoryName;
            }

            //Check if directory exist
            fExist = CheckIfConfigDirectoryExist("config");

            if (!fExist)
            {
                Directory.CreateDirectory(fullPath);
            }

        }

        //==================================================================================
        //Create file under specify path. fileName must include file extension
        //If file with given name does not exist under given path method will create a new file
        // and return "True".
        //Otherwise method return "False"
        bool CreateFile(string fileName, string path = "")
        {
            bool fExist = false;
            string fullPath;
            bool retVal = false;

            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + "\\" + fileName;
            }
            else
            {
                fullPath = path + "\\" + fileName;
            }

            //Check if directory exist
            fExist = CheckIfConfigFileExist("config.txt");

            if (!fExist)
            {
                try
                {
                    using(FileStream fs = File.Create(fullPath))
                    {
                        retVal = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }

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
                retList.Add(new ConfigElement("ElzabCommand", fullPath, "Elzab command path"));

                //Add next element to list
                retList.Add(new ConfigElement("DatabseName", "TestDatabaseName", "Test database name"));

                //To Add next element to list, act as above
                //Placeholder for next element

            //Return value
            return retList;

        }

        //==================================================================================
        void CreateConfigFile(string fileName, string path = "")
        {
            bool fCreated = false;
            string fullPath;
            List<ConfigElement> configDataToWrite = new List<ConfigElement>();
                 
            //Verify if fileName contain proper .txt extension
            Regex r = new Regex(@"^.*\.txt$");

            if (!r.IsMatch(fileName))
            {
                throw new System.ArgumentException("Wrong name extension", "fileName");
            }
            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + "\\" + fileName;
            }
            else
            {
                fullPath = path + "\\" + fileName;
            }

            //Call method to create new file
            fCreated = CreateFile(fileName, path);

            //If file created successfully, fill it with template
            if (fCreated)
            {
                configDataToWrite = TemplateConfigFile();

                try
                {
                    // Open the text file using a stream reader.
                    using (var file = new StreamWriter(fullPath))
                    {

                        foreach (ConfigElement element in configDataToWrite)
                        {
                            file.WriteLine(element.PrepareDataToWrite());
                            file.WriteLine("\\n");
                        }

                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

            }

        }

        public void InitializeConfigFile(string fileName, string path = "", string subFolder = "")
        {
            string fullPath = "";

            
            if (path != "")
            {
                if (subFolder != "")
                {
                    fullPath = path + "\\" + subFolder;
                }
                else
                {
                    fullPath = path;
                }
            }
            else
            {
                if (subFolder != "")
                {
                    fullPath = "\\" + subFolder;
                }
            }

            // Check if directory exist, if not create one
            CreateDirectory(fullPath);

            //Check if file exist, if not create one
            CreateConfigFile(fileName, fullPath);

        }

        //==================================================================================
        public List<ConfigElement> ReadConfigFileElement(string path, string fileName, string elementNameTemp, string subFolder = "")
        {

            string fullPath = ConsolidatePathAndFile(path, fileName, "txt", subFolder);
            Regex rVariableName = new Regex(@"^.*#.*$");
            Regex rPattern = new Regex("=");
            List<ConfigElement> configElements = new List<ConfigElement>();
            try
            {
                // Open the text file using a stream reader.
                using (var file = new StreamReader(fullPath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (rVariableName.IsMatch(line))
                        {
                            string[] element;
                            element = rPattern.Split(line);
                            configElements.Add(new ConfigElement(element[0], element[1]));
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
            for (int i = 0; i < configElements.Count; i++ )
            {
                configElements[i].ClearElementName();
            }

            return configElements;
        }

        //==================================================================================
        string ConsolidatePathAndFile(string path, string fileName)
        {
            string fullPath;
            Regex r = new Regex(@"^\.*$");

                if (path == "")
                {
                    fullPath = Directory.GetCurrentDirectory() + "\\" + fileName;
                }
                else
                {
                    fullPath = path + "\\" + fileName;
                }

            return fullPath;
        }
        string ConsolidatePathAndFile(string path, string fileName, string fileExtension = "", string subFolder = "")
        {
            string fullPath;

            if (path == "")
            {
                if (subFolder == "")
                {
                    @fullPath = @Directory.GetCurrentDirectory() + @"\" + fileName + "." + fileExtension;
                }
                else
                {
                    @fullPath = @Directory.GetCurrentDirectory() + @"\" + subFolder + @"\" + fileName + "." + fileExtension;
                }
                    
            }
            else
            {
                if (subFolder == "")
                {
                    fullPath = path + "\\" + fileName + "." + fileExtension;
                }
                else
                {
                    fullPath = path + "\\" + subFolder + "\\" + fileName + "." + fileExtension;
                }
            }

            return fullPath;
        }




    }
        
}
