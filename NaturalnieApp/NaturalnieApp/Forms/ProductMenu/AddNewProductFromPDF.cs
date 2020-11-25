using System;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using NaturalnieApp.Initialization;
using Aspose.Pdf;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace NaturalnieApp.Forms
{
    public partial class AddNewProductFromPDF : Form
    {
        // Required for AnyCPU implementation.

        public AddNewProductFromPDF()
        {
            InitializeComponent();

            // Initialize PDFNet before using any PDFTron related
            // classes and methods (some exceptions can be found in API)

        }

        void SaveToPDF(string pdfPath, string outPath)
        {
            // Load PDF document
            Document pdfDocument = new Document(pdfPath);
            // Initialize ExcelSaveOptions
            ExcelSaveOptions options = new ExcelSaveOptions();
            // Set output format
            options.Format = ExcelSaveOptions.ExcelFormat.XLSX;
            // Save output file
            pdfDocument.Save(outPath, options);
            ;
        }


        private void bBrowsePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbPdfPath.Text = ofd.FileName;
                //SaveToPDF(this.tbPdfPath.Text,"F:\\Projekty\\02. NaturalnieApp\\NaturalnieApp\\TempFolder\\test.xlsx");
                List<DataTable> excelData = ReadExcel(@"F:\Projekty\02. NaturalnieApp\NaturalnieApp\TempFolder\test.xlsx");
                RemoveRowsUntilString(excelData[0], "Lp");
            }

        }

        //Method used to remove rows until find specified string
        bool RemoveRowsUntilString(DataTable data, string wantedString)
        {
            List<string> itemArray = new List<string>() ;
            foreach (DataRow row in data.Rows)
            {
                int index = -2;
                itemArray = row.ItemArray.Select(s => s.ToString()).ToList();
                index = itemArray.FindIndex(e => e.Contains( wantedString));
                if ( index != -1)
                {
                    
                }
               
            }

            ;

            return false;
        }

        //Method used to read data from excel from the specified path
        //Method return List of data table, where one list element contains one sheet data from excel file
        private List<DataTable> ReadExcel(string filePath)
        {
            //Local variables
            string fileExtension;
            string connectionString = "";
            bool extensionValidatedSuccessfully = false;

            List<DataTable> excelData = new List<DataTable>();

            //Check file extension
            fileExtension = Path.GetExtension(filePath);

            //Create connection string
            // if the File extension is .XLS using below connection string
            if (fileExtension == ".xls")
            {
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = '" + filePath + "';Extended Properties=\"Excel 8.0;HDR=YES;\"";
                extensionValidatedSuccessfully = true;
            }
            // if the File extension is .XLSX using below connection string
            else if(fileExtension == ".xlsx")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";
                extensionValidatedSuccessfully = true;
            }
            else
            {
                MessageBox.Show("Błędne rozszerzenie pliku! Oczekiwane : '.xls' lub '.xlsx'. Aktualne : '" + fileExtension +"'.");
            }
            
            //Check if extension has proper format
            if (extensionValidatedSuccessfully)
            {
                // Connect EXCEL sheet with OLEDB using connection string
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    try
                    {
                        //Open connection
                        conn.Open();

                        //Get list of sheet names
                        List<string> sheetNames = GetListOfSheetNames(conn);

                        //Get data from all excel sheets
                        excelData = GetExcelSheetData(conn, sheetNames);

                    }
                    catch (Exception ex)
                    {
                        //exception here
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }

                }

            }

            return excelData;

        }

        //Method used to get the list of sheet names from specified excel file
        List<string> GetListOfSheetNames(OleDbConnection connection)
        {
            //Get number of sheet in excel file
            DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<string> listOfSheetNames = new List<string>();

            foreach (DataRow element in schemaTable.Rows)
            {
                listOfSheetNames.Add(element["TABLE_NAME"].ToString());
            }

            return listOfSheetNames;
        }

        //Method used to get the data from the specified excel sheet
        List<DataTable> GetExcelSheetData(OleDbConnection connection, List<string> sheetNames)
        {
            //Local variables
            List<DataTable> retValue = new List<DataTable>();

            foreach (string element in sheetNames)
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(string.Format("select * from [{0}]", element), connection);
                DataSet excelDataSet = new DataSet();
                dataAdapter.Fill(excelDataSet);
                DataTable excelDataTable = new DataTable(element);
                excelDataTable = excelDataSet.Tables[0];
                retValue.Add(excelDataTable);

            }

            return retValue;
        }

    }
}
