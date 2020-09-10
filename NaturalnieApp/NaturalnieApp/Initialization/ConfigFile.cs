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

namespace NaturalnieApp.Initialization
{
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
        void CreateDirectory(string directoryName, string path = "")
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

            //Check if direcotry exist
            fExist = CheckIfConfigDirectoryExist("config");

            if (!fExist)
            {
                Directory.CreateDirectory(fullPath);
            }

        }

        //==================================================================================
        void CreateConfigFile(string fileName, string path = "")
        {
            bool fExist = false;
            string fullPath;

            //Verify if fileName contain proper .xml extension
            Regex r = new Regex(@"^.*\.xml$");
            if (!r.IsMatch(fileName))
            {
                throw new System.ArgumentException("Wrong name extension", "fileName");
            }
            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + "\\config\\"  + fileName;
            }
            else
            {
                fullPath = path + "\\" + fileName;
            }


            //Check if xml file exist
            fExist = File.Exists(fullPath);
            
            //If not exist, create new file and fill it with pattern
            if (!fExist)
            {
                //Default path for ElzabCommandsPath

                //Create xml file inf not exist
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = false;
                using (XmlWriter writer = XmlWriter.Create(fullPath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Settings");
                        writer.WriteStartElement("Paths");
                            writer.WriteElementString("ElzabCommandPath", "Tes");
                            writer.WriteElementString("OtherSettings", "TestSetting");
                        writer.WriteEndElement();
                        writer.WriteStartElement("Paths2");
                            writer.WriteElementString("Elzab2", "Tes2");
                            writer.WriteElementString("OtherSettings2", "TestSetting2");
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                }
            }

        }

        public void InitializeConfigFile()
        {
            // Check if directory exist, if not create one
            CreateDirectory("config");

            //Check if file exist, if not create one
            CreateConfigFile("config.xml");

        }

        //==================================================================================
        public void ReadConfigFileElement(string path, string fileName, string elementNameTemp, string subFolder = "")
        {

            string fullPath = ConsolidatePathAndFile(path, fileName, "txt");
            Regex rVariableName = new Regex(@"^.*#$");
            Regex rPattern = new Regex(@"^.*=$");
            string[] elements;

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
                            elements = rPattern.Split(line);
                            foreach (string element in elements)
                            {
                                element.Trim();
                            }
                        }
                        ;

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }

        //==================================================================================
        string ConsolidatePathAndFile(string path, string fileName)
        {
                string fullPath;


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
        string ConsolidatePathAndFile(string path, string fileName, string fileExtension = "")
        {
            string fullPath;

            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + fileName + "." + fileExtension ;
            }
            else
            {
                fullPath = path + "\\" + fileName + "." + fileExtension;
            }

            return fullPath;
        }




    }
        
}
