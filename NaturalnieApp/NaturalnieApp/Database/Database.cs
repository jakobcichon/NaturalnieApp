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
        [Key]
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
        [Key]
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }
        public string SupplierAddressLine3 { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierInfo { get; set; }
        public string SupplierPhone { get; set; }

    }
}
