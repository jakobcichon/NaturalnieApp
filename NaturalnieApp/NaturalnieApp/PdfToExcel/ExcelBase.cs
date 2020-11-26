using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NaturalnieApp.PdfToExcel
{
    [Serializable()]
    public class InvalidFileExtensionException : Exception
    {
        public InvalidFileExtensionException() : base() { }
        public InvalidFileExtensionException(string message) : base(message) { }
        public InvalidFileExtensionException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidFileExtensionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class Properties
    {
        //If set to true, row which contain StartString will be taken as the one containing column names.
        //If set to false it will start from next one row
        private bool startStringDefineColumnNames;
        public bool StartStringDefineColumnNames
        {
            get { return true; }
            set { startStringDefineColumnNames = value; }
        }

        //If set to true, row which contain EndString will be taken as the las entity.
        //If set to false it will take previous row as last entity
        private bool endStringDefineLastEntity;
        public bool EndStringDefineLastEntity
        {
            get { return true; }
            set { endStringDefineLastEntity = value; }
        }

    }

    public class ExcelBase
    {
        public static void ExtractEntities(IExcel template, List<DataTable> data)
        {
            //LocalVariables
            DataTable dataTable = new DataTable();
            int i = -1;
            bool dataStarted = false;
            List<string> tempData;
            List<string> returnData = new List<string>();

            //Get data from excel
            foreach (DataTable table in data)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.ItemArray.Select(e => e.ToString()).Any(x => x.Contains(template.StartString)) && i == -1)
                    {
                        dataStarted = true;
                        i = 0;
                    }

                    if (row.ItemArray.Select(e => e.ToString()).Any(x => x.Contains(template.EndString)))
                    {
                        dataStarted = false;
                    }

                    if (dataStarted)
                    {
                        //Get data to the local variable                        
                        tempData = row.ItemArray.Select(e => e.ToString()).ToList();
                        //Get rid of empty fields
                        tempData = tempData.Select(e => e.Trim()).ToList();
                        tempData = tempData.Select(e => e.Replace("\n", " ")).ToList();

                        //Check if first field contains any of data. If no add data to the previous row
                        if (tempData[0] == "")
                        {
                            if (dataTable.Rows.Count > 0 )
                            {
                                //Get last row from already added data rows, and convert it to list
                                DataRow lastDataRow = dataTable.Rows[dataTable.Rows.Count - 1];
                                List<string> lastDataRowAsList = lastDataRow.ItemArray.Select(e => e.ToString()).ToList();

                                //Loop through all elements in data row and contact both strings
                                for (int z=1; z<tempData.Count; z++)
                                {
                                    if (tempData[z] != "")
                                    {
                                        lastDataRowAsList[z] = lastDataRowAsList[z] + " " + tempData[z];
                                    }
                                    
                                }
                                dataTable.Rows[dataTable.Rows.Count - 1].ItemArray = lastDataRowAsList.ToArray();
                            }
                        }
                        else
                        {
                            //Assume first data are columns names
                            if (i == 0)
                            {

                                foreach (string element in tempData)
                                {
                                    DataColumn tempDataColumn = new DataColumn();
                                    tempDataColumn.DataType = Type.GetType("System.String");
                                    tempDataColumn.ColumnName = element;
                                    dataTable.Columns.Add(tempDataColumn);
                                    tempDataColumn.Dispose();
                                }

                                i++;
                            }
                            else
                            {
                                DataRow tempDataRow = dataTable.NewRow();
                                tempDataRow.ItemArray = tempData.ToArray();
                                dataTable.Rows.Add(tempDataRow);
                                i++;
                            }
                        }

                        ;
                    }
                }

                dataStarted = false;
            }
            ;
            foreach (DataRow row in dataTable.Rows)
            {
                tempData = row.ItemArray.Select(e => e.ToString()).ToList(); 
                ;
            }

        }

        //Get all data from excel sheet. Each excel sheet would be separated list element
        public static List<DataTable> GetAllDataFromExcel(string excelPath)
        {
            //Get connection string
            string connectionString = GetConnectionString(excelPath);

            //Get excel sheet names from specified excel
            List<string> sheetNames = GetExcelSheetNames(connectionString);

            //Local variables
            List<DataTable> localDataTables = new List<DataTable>();

            //Load data from all excel sheets to the DataTable
            using (OleDbConnection objConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    objConnection.Open();

                    foreach (string element in sheetNames)
                    {
                       
                        string sQuery = "Select * From [" + element + "]";
                        OleDbCommand dbCmd = new OleDbCommand(sQuery, objConnection);
                        OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(dbCmd);
                        DataTable dtData = new DataTable();
                        dbDataAdapter.Fill(dtData);
                        localDataTables.Add(dtData);

                    }
                    objConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }

            return localDataTables;

        }

        //Method used to get all sheet names from specified excel sheet
        static private List<string> GetExcelSheetNames(string connectionString)
        {
            //Local variables
            DataTable localDataTable;
            List<string> retList = new List<string>();
            
            using (OleDbConnection objConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    objConnection.Open();
                    localDataTable = objConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    // Add the sheet name to the string array.
                    foreach (DataRow row in localDataTable.Rows)
                    {
                        retList.Add(row["TABLE_NAME"].ToString());
                    }

                    objConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }


            return retList;
        }

        //Method used to make connection string
        static private string GetConnectionString(string filePath)
        {
            //Local variables
            string connectionString = "";
            string fileExtension = "";

            //Get file extension
            fileExtension = Path.GetExtension(filePath);

            if (fileExtension == ".xls")
            {
                //Set connection string for .xls files
                connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source = '" + filePath + "';Extended Properties=\"Excel 8.0;HDR=NO; IMEX=1\"";
            }
            else if (fileExtension == ".xlsx")
            {
                //Set connection string for .xls files
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + filePath + "';Extended Properties=\"Excel 12.0;HDR=NO; IMEX=1\"";
            }
            else
            {
                //Throw an exception
                throw new InvalidFileExtensionException("Wrong file extension. Possible file extension are: '.xls' or '.xlsx'.");
            }

            return connectionString;
        }




    }
}
