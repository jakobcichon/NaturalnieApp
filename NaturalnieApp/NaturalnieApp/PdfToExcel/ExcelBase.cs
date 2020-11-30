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

            //Create file 
            //File.Create(fullPath);

            //Create file
            CreateExcelFileFromTemplate(template, connectionString);


        }

        public void ExtractEntities(IExcel template, List<DataTable> data)
        {
            //LocalVariables
            DataTable dataTable = new DataTable();
            int i = 0;
            List<string> tempData;
            List<string> returnData = new List<string>();
            List<DataRow> dataRowsFromFile;

            //Get data from excel
            foreach (DataTable table in data)
            {
                dataRowsFromFile = ExtractDataFromExcel(template, table);
                foreach (DataRow row in dataRowsFromFile)
                {
                    tempData = row.ItemArray.Select(e => e.ToString()).ToList();
                }
            }
        }

        private List<DataRow> ExtractDataFromExcel(IExcel template, DataTable table)
        {
            //Local variables
            List<DataRow> returnList = new List<DataRow>();
             
            //Check if number of columns from excel match schema
            if (template.DataTableSchema.Count == table.Columns.Count)
            {
                //Check if data in first column exist. If yes add it to list
                foreach (DataRow row in table.Rows)
                {
                    if((row[0].ToString() !=  "") && (row[0].ToString().Any(char.IsDigit)))
                    {
                        returnList.Add(row);
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Format("Błąd! Niezgodna liczba kolumn! Oczekiwane: {0}, Aktualne:{1}", 
                    template.DataTableSchema.Count, 
                    table.Columns.Count));
            }

            //Return
            return returnList;

        }

        //Method used to create excel file from template
        static private void CreateExcelFileFromTemplate(IExcel template, string connectionString)
        {
            
            OleDbConnection connection = new OleDbConnection();
            
            try
            {
                //Connection string
                connection.ConnectionString = connectionString;
                connection.Open();
                var cmd = connection.CreateCommand();

                //Create command for create columns
                string columnNames = "";
                foreach (string element in template.DataTableSchema)
                {
                    columnNames += "[" + element + "]" + " string, ";
                }

                //Remove last space and coma from command
                columnNames = columnNames.Remove(columnNames.Length - 2, 2);

                //Create command string
                cmd.CommandText = string.Format("CREATE TABLE [Sheet1] ({0})", columnNames); 

                //Execute query
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
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
                //Set connection string for .xlsx files
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
