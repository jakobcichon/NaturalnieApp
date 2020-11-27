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
        public void ExtractEntities(IExcel template, List<DataTable> data)
        {
            //LocalVariables
            DataTable dataTable = new DataTable();
            int i = 0;
            bool dataStarted = false;
            bool headerRead = false;
            List<string> tempData;
            List<string> returnData = new List<string>();
            List<DataRow> dataRowsFromFile;

            //Get data from excel
            foreach (DataTable table in data)
            {
                dataRowsFromFile = ExtractDataFromStartToEndString(template, table);
                foreach (DataRow row in dataRowsFromFile)
                {
                    tempData = row.ItemArray.Select(e => e.ToString()).ToList();
                    ;
                }
            }
            ;


        }

        private List<DataRow> ExtractDataFromStartToEndString(IExcel template, DataTable table)
        {
            //Local variables
            bool dataStarted = false;
            bool moreThanOneRowByEntity = false ;
            List<DataRow> returnRowList = new List<DataRow>();
            Properties.LastEntityMark lastEntityAction = template._Properties.LastEntity;
            List<DataRow> rowsBySingleEntity = new List<DataRow>();

            //Determine if there is more that one row per Entity
            if (template._Properties.NumberOfRowByEntity > 1) moreThanOneRowByEntity = true;

            //Get last entity action
            switch (lastEntityAction)
            {
                case Properties.LastEntityMark.RowWithLastNumericValueInFirstColumn:
                    
                    break;
            }

            //Get all rows starting from StartString till end option
            foreach (DataRow row in table.Rows)
            {
                //Numer of the first column empty in the row
                int numbersOfEmptyFirstColumm = 0;

                //Check if in current row any string match to the StartString
                if (row.ItemArray.Select(e => e.ToString()).Any(x => x.Contains(template.StartString))) dataStarted = true; 

                //Check if option with more than one row by entity supported here
                if (moreThanOneRowByEntity)
                {
                    //Check if in current row any string match to the EndString
                    if (row.ItemArray.First().ToString().Any(char.IsDigit)) numbersOfEmptyFirstColumm = 0;
                    else if (!row.ItemArray.First().ToString().Any(char.IsDigit)) numbersOfEmptyFirstColumm++;
                }

                //Check if maximal number of empty fors column in the row was achieved
                if (numbersOfEmptyFirstColumm > template._Properties.NumberOfRowByEntity)
                {
                    dataStarted = false; 
                    break;
                }
                else if (row.ItemArray.Select(e => e.ToString()).Any(x => x.Contains(template.EndString)))
                {
                    dataStarted = false;
                    break;
                }


                //Add row to the return list
                if (dataStarted) returnRowList.Add(row);

            }
            return returnRowList;
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
