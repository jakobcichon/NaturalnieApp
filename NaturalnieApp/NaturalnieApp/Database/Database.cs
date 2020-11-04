using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace NaturalnieApp.Database
{

    public class Product
    {

        public int ProductId { get; set; }
        public string Manufacturer { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float PriceNet { get; set; }
        public int Tax { get; set; }
        public float Marigin { get; set; }
    }


    public class Suppliers
    {

        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }
        public string SupplierAddressLine3 { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierInfo { get; set; }
        public string SupplierPhone { get; set; }

    }

    /*
    public class DatabaseMain
    {
        private const string SERVER = "127.0.0.1";
        private const string DATABSE = "shop";
        private const string UID = "root";
        private const string PASSWORD = "admin";

        // Class fields
        MySqlConnection connection { get; set; }
        string mySqlConnectionString { get; set; }

        //Class constructor
        public DatabaseMain()
        {
            //Prepare connection string
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.Database = DATABSE;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            this.mySqlConnectionString = builder.ToString();
            this.connection = new MySqlConnection();
            this.connection.ConnectionString = this.mySqlConnectionString;
            ProjectDBEni
        }

        //Method uesd to connect to database
        public void ConnectToDb()
        {
            //Try to connect to Database
            try
            {
                this.connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method used to disconnect from database
        public void DisconnectFromDb()
        {
            //Disconnect from DB
            try
            {
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method used to read all data from specific table
        public void ReadAllFromTable(string tableName)
        {
            
            string query = "SELECT * FROM " + tableName;
            MySqlCommand command = new MySqlCommand(query, this.connection);
            ConnectToDb();
            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                string tmp = dataReader[1].ToString();
                ;
            }
            dataReader.Close();
            DisconnectFromDb();
        }


    }
    */
}
