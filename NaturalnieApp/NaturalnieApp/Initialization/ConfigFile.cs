using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using System.Xml;

namespace NaturalnieApp.Initialization
{
    class ConfigFile
    {

    //==================================================================================
    //Check if config file exist. If path not specify, use current path.
    private bool CheckIfConfigFileExist(string fileName, string path = "")
        {
            //If path not specofied, used current diectory
            if (path == "")
            {
                path = Directory.GetCurrentDirectory();
            }

            bool fExist = false;
            string fullPath = path + "\\" + fileName;
            fExist = File.Exists(fullPath);
            return fExist;
        }

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

            if (path == "")
            {
                fullPath = Directory.GetCurrentDirectory() + "\\config\\"  + fileName;
            }
            else
            {
                fullPath = path + "\\" + fileName;
            }

            //Check if file exist
            fExist = CheckIfConfigFileExist("config.txt");

            if (!fExist)
            {
               
                FileStream fs = File.Create(fullPath);
                fs.Close();
            }
        }

        public void InitializeConfigFile()
        {
            // Check if directory exist, if not create one
            CreateDirectory("config");

            //Check if file exist, if not create one
            CreateConfigFile("config.txt");

        }

        //==================================================================================
        string[] ReadFile(string path, string fileName)
        {
            //To Do!!!!!!!!!!!!!!!!!!!!!!!1
            string[] returnVal = new string[] { "" } ;
            return returnVal;
        }

        //==================================================================================

        //************************************************************************************
        //
        //  Associate the schema with XML. Then, load the XML and validate it against
        //  the schema.
        //
        //************************************************************************************
        public XmlDocument LoadDocumentWithSchemaValidation(bool generateXML, bool generateSchema)
        {
            XmlReader reader;

            XmlReaderSettings settings = new XmlReaderSettings();

            // Helper method to retrieve schema.
            XmlSchema schema = getSchema(generateSchema);

            if (schema == null)
            {
                return null;
            }

            settings.Schemas.Add(schema);

            settings.ValidationEventHandler += settings_ValidationEventHandler;
            settings.ValidationFlags =
                settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;

            try
            {
                reader = XmlReader.Create("booksData.xml", settings);
            }
            catch (System.IO.FileNotFoundException)
            {
                if (generateXML)
                {
                    string xml = generateXMLString();
                    byte[] byteArray = Encoding.UTF8.GetBytes(xml);
                    MemoryStream stream = new MemoryStream(byteArray);
                    reader = XmlReader.Create(stream, settings);
                }
                else
                {
                    return null;
                }
            }

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(reader);
            reader.Close();

            return doc;
        }

        //************************************************************************************
        //
        //  Helper method that generates an XML Schema.
        //
        //************************************************************************************
        private string generateXMLSchema()
        {
            string xmlSchema =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                "<xs:schema attributeFormDefault=\"unqualified\" " +
                "elementFormDefault=\"qualified\" targetNamespace=\"http://www.contoso.com/books\" " +
                "xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> " +
                "<xs:element name=\"books\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element maxOccurs=\"unbounded\" name=\"book\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element name=\"title\" type=\"xs:string\" /> " +
                "<xs:element name=\"price\" type=\"xs:decimal\" /> " +
                "</xs:sequence> " +
                "<xs:attribute name=\"genre\" type=\"xs:string\" use=\"required\" /> " +
                "<xs:attribute name=\"publicationdate\" type=\"xs:date\" use=\"required\" /> " +
                "<xs:attribute name=\"ISBN\" type=\"xs:string\" use=\"required\" /> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:sequence> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:schema> ";
            return xmlSchema;
        }

        //************************************************************************************
        //
        //  Helper method that gets a schema
        //
        //************************************************************************************
        private XmlSchema getSchema(bool generateSchema)
        {
            XmlSchemaSet xs = new XmlSchemaSet();
            XmlSchema schema;
            try
            {
                schema = xs.Add("http://www.contoso.com/books", "booksData.xsd");
            }
            catch (System.IO.FileNotFoundException)
            {
                if (generateSchema)
                {
                    string xmlSchemaString = generateXMLSchema();
                    byte[] byteArray = Encoding.UTF8.GetBytes(xmlSchemaString);
                    MemoryStream stream = new MemoryStream(byteArray);
                    XmlReader reader = XmlReader.Create(stream);
                    schema = xs.Add("http://www.contoso.com/books", reader);
                }
                else
                {
                    return null;
                }
            }
            return schema;
        }

        //************************************************************************************
        //
        //  Helper method to validate the XML against the schema.
        //
        //************************************************************************************
        private void validateXML(bool generateSchema, XmlDocument doc)
        {
            if (doc.Schemas.Count == 0)
            {
                // Helper method to retrieve schema.
                XmlSchema schema = getSchema(generateSchema);
                doc.Schemas.Add(schema);
            }

            // Use an event handler to validate the XML node against the schema.
            doc.Validate(settings_ValidationEventHandler);
        }

        //************************************************************************************
        //
        //  Event handler that is raised when XML doesn't validate against the schema.
        //
        //************************************************************************************
        void settings_ValidationEventHandler(object sender,
            System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                System.Windows.Forms.MessageBox.Show
                    ("The following validation warning occurred: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                System.Windows.Forms.MessageBox.Show
                    ("The following critical validation errors occurred: " + e.Message);
                Type objectType = sender.GetType();
            }
        }

    }
        
}
