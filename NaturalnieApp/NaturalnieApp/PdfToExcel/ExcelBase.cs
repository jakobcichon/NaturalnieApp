﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;



//This is first version of this library. In this stage it support only loading products from excel with certain structure.
//Next release will support adding product directly from pdf
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

    public enum ColumnsAttributes
    {
        Percentage,
        Price,
        GeneralText,
        GeneralNumber
    }

    public class Properties
    {
        //Method used to recognize of last entity entry
        public enum LastEntityMark
        {
            RowWithLastNumericValueInFirstColumn,
            ContainEndString,
            OneBeforeEndMark,
        }

        //Property used to determine if entity in exclel file can consist of a few rows
        //It is used in cooperation with LastEntityMark enum
        public int NumberOfRowByEntity { get; set; }

        //If set to true, row which contain StartString will be taken as the one containing column names.
        //If set to false it will start from next one row
        public bool StartStringDefineColumnNames { get; set; }
        
        //Property used to define how to recognize last data as entity
        public LastEntityMark LastEntity { get; set; }

    }

    public class ExcelBase
    {

        //Create excel file from template
        static public void CreateExcelFile(IExcel template, string filePath, string outFileName)
        {
            //Local variable
            string fullPath;

            //Combine path and file name
            fullPath = Path.Combine(filePath, outFileName + ".xlsb");

            //Connection string
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + fullPath + "';Extended Properties=\"Excel 12.0;HDR=YES\"";

            //Create message box and show message box
            if (CreateExcelFileFromTemplate(template, connectionString))
            {
                MessageBox.Show(string.Format("Plik {0} został utworzony!", fullPath));
            }

        }

        public DataTable ExtractEntities(IExcel template, List<DataTable> data)
        {
            //LocalVariables
            DataTable returnData = new DataTable();
            List<DataRow> dataRowsFromFile = new List<DataRow>();

            //Initialize data table from template
            foreach ( string columnName in template.DataTableSchema.Values)
            {
                //dataColumn.ColumnName = columnName;
                //dataColumn.DataType = Type.GetType("System.String");
                returnData.Columns.Add(columnName, typeof(String));
            }

            //Get data from excel for every sheet
            foreach (DataTable table in data)
            {
                dataRowsFromFile.AddRange(ExtractDataFromExcel(template, table));
            }

            //Check if row contains empty filelds. 
            //If only product name is empty, contact it with previous row
            foreach (DataRow row in dataRowsFromFile)
            {
                //Get product with the product name. This is done in case if name of product 
                // will take two rows in excel sheet
                if(row.ItemArray[0].ToString() == "")
                {
                    int indexOfLastRow = returnData.Rows.Count - 1;
                    int indexOfDesireColumn = returnData.Columns.IndexOf("Nazwa towaru");
                    string valueToSet = returnData.Rows[indexOfLastRow][indexOfDesireColumn] + " " + row.ItemArray[indexOfDesireColumn].ToString();
                    returnData.Rows[indexOfLastRow].SetField(indexOfDesireColumn, valueToSet);
                }
                else
                {
                    DataRow dataRow = returnData.NewRow();
                    for (int i=0;  i < dataRow.Table.Columns.Count; i++)
                    {
                        dataRow.SetField(i, row.ItemArray[i].ToString());
                    }
                   
                    returnData.Rows.Add(dataRow);
                }
            }

            return returnData;

        }

        //Method used to clean data from excel
        private DataTable CleanDataFromExcel(List<DataRow> rows)
        {
            //LocalVariables
            DataTable returnData = new DataTable();

            //Check if row contains empty filelds. 
            //If only product name is empty, contact it with previous row
            foreach (DataRow row in rows)
            {
                //Get product with the product name. This is done in case if name of product 
                //will take two rows in excel sheet
                if (row.ItemArray[0].ToString() == "")
                {
                    //Necessary indexes
                    int indexOfLastRow = returnData.Rows.Count - 1;
                    int indexOfDesireColumn = returnData.Columns.IndexOf("Nazwa towaru");

                    //Get value to set
                    string valueToSet = returnData.Rows[indexOfLastRow][indexOfDesireColumn] + " " + row.ItemArray[indexOfDesireColumn].ToString();
                    returnData.Rows[indexOfLastRow].SetField(indexOfDesireColumn, valueToSet);
                }
                else
                {
                    DataRow dataRow = returnData.NewRow();
                    for (int i = 0; i < dataRow.Table.Columns.Count; i++)
                    {
                        dataRow.SetField(i, row.ItemArray[i].ToString());
                    }

                    returnData.Rows.Add(dataRow);
                }
            }

            //Loop through rows and clean it (change comma to point mark, double form of percentage to decimal one, etc..)
            foreach (DataRow row in returnData.Rows)
            {
                //Change comma to point for every row element
                int indexOfCurrentRow = returnData.Rows.IndexOf(row);
                returnData.Rows[indexOfCurrentRow].ItemArray = row.ItemArray.Select(e => e.ToString().Replace(",", ".")).ToArray();

                //Change float percentage representation for decimal one

            }

            return returnData;
        }

        //Method used to add some additional columns to data table. 
        //These columns are used to put calculated data 
        private DataTable AddAdditionalColumns(DataTable data)
        {

        }

        private List<DataRow> ExtractDataFromExcel(IExcel template, DataTable table)
        {
            //Local variables
            List<DataRow> returnList = new List<DataRow>();
             
            //Check if number of columns from excel match schema
            if (template.DataTableSchema.Values.Count == table.Columns.Count)
            {
                //Check if data in first column exist. If yes add it to list
                foreach (DataRow row in table.Rows)
                {
                    //First row is an header. Skip it
                    if (table.Rows.IndexOf(row) != 0)
                    {
                        returnList.Add(row);
                    }

                }
            }
            else
            {
                MessageBox.Show(string.Format("Błąd! Niezgodna liczba kolumn! Oczekiwane: {0}, Aktualne:{1}", 
                    template.DataTableSchema.Values.Count, 
                    table.Columns.Count));
            }

            //Return
            return returnList;

        }

        //Method used to create excel file from template
        static private bool CreateExcelFileFromTemplate(IExcel template, string connectionString)
        {

            //Local variable
            bool retValue = false;
            
            //Create connection
            OleDbConnection connection = new OleDbConnection();
            
            try
            {
                //Connection string
                connection.ConnectionString = connectionString;
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();

                //Create command for create columns
                string columnNames = "";
                foreach (string element in template.DataTableSchema.Values)
                {
                    columnNames += "[" + element + "]" + " string, ";
                }

                //Remove last space and coma from command
                columnNames = columnNames.Remove(columnNames.Length - 2, 2);

                //Create command string
                cmd.CommandText = string.Format("CREATE TABLE [Sheet1] ({0})", columnNames); 

                //Execute query
                cmd.ExecuteNonQuery();

                //Set return value
                retValue = true;
                
            }
            catch (OleDbException oleDbEx)
            {
                if (oleDbEx.ErrorCode == -2147217900)
                {
                    MessageBox.Show("Plik o podanej nazwie już istnieje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return retValue;
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
            else if ((fileExtension == ".xlsx") || (fileExtension == ".xlsb"))
            {
                //Set connection string for .xlsx files
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + filePath + "';Extended Properties=\"Excel 12.0;HDR=NO; IMEX=1\"";
            }
            else
            {
                //Throw an exception
                throw new InvalidFileExtensionException("Wrong file extension. Possible file extension are: '.xls', '.xlsx' or '.xlsx'.");
            }

            return connectionString;
        }




    }
}
