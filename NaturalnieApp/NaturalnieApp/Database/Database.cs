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
using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalnieApp.Database
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ElzabProductId { get; set; }
        public string Manufacturer { get; set; }
        public string ProductName { get; set; }
        public float PriceNet { get; set; }
        public int Tax { get; set; }
        public float Marigin { get; set; }
        public string BarCode { get; set; }
        public string ProductInfo { get; set; }
    }

    [Table("stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ActualQuantity { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public bool QuantityWarning { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ExpirationDate { get; set; }
    }


    [Table("sales")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime SalesDate { get; set; }
        public int Quantity { get; set; }
    }

    [Table("supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

    }
}
