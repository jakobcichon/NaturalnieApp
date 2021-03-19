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
        public int ManufacturerId { get; set; }
        public string ProductName { get; set; }
        public string ElzabProductName { get; set; }
        public float PriceNet { get; set; }
        public int Discount { get; set; }
        public float PriceNetWithDiscount { get; set; }
        public int TaxId { get; set; }
        public int Marigin { get; set; }
        public float FinalPrice { get; set; }
        public string BarCode { get; set; }
        public string BarCodeShort { get; set; }
        public string SupplierCode { get; set; }
        public string ProductInfo { get; set; }

        public Product DeepCopy()
        {
            Product product = (Product)this.MemberwiseClone();
            product.Id = this.Id;
            product.SupplierId = this.SupplierId;
            product.ElzabProductId = this.ElzabProductId;
            product.ManufacturerId = this.ManufacturerId;
            product.ProductName = this.ProductName;
            product.ElzabProductName = this.ElzabProductName;
            product.PriceNet = this.PriceNet;
            product.Discount = this.Discount;
            product.PriceNetWithDiscount = this.PriceNetWithDiscount;
            product.TaxId = this.TaxId;
            product.Marigin = this.Marigin;
            product.FinalPrice = this.FinalPrice;
            product.BarCode = this.BarCode;
            product.BarCodeShort = this.BarCodeShort;
            product.SupplierCode = this.SupplierCode;
            product.ProductInfo = this.ProductInfo;
            return product;
        }
    }

    public enum ProductOperationType
    {
        AddNew,
        Update,
        Delete
    }
    public enum StockOperationType
    {
        AddNew,
        Update,
        Delete,
        AutomaticUpdate,
        AutomaticAddedNew
    }

    [Table("product_changelog")]
    public class ProductChangelog
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int ElzabProductId { get; set; }
        public int ManufacturerId { get; set; }
        public string ProductName { get; set; }
        public string ElzabProductName { get; set; }
        public float PriceNet { get; set; }
        public int Discount { get; set; }
        public float PriceNetWithDiscount { get; set; }
        public int TaxId { get; set; }
        public int Marigin { get; set; }
        public float FinalPrice { get; set; }
        public string BarCode { get; set; }
        public string BarCodeShort { get; set; }
        public string SupplierCode { get; set; }
        public string ProductInfo { get; set; }
        public DateTime DateAndTime { get; set; }
        public string  OperationType { get; set; }
    }

    [Table("stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ActualQuantity { get; set; }
        public int LastQuantity { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string BarcodeWithDate { get; set; }
    }

    [Table("stock_history")]
    public class StockHistory
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAndTime { get; set; }
        public string OperationType { get; set; }
        public string SalesIdForAutomaticUpdate { get; set; }
    }


    [Table("sales")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int ElementType { get; set; }
        public DateTime TimeOfAdded { get; set; }
        public string EntryUniqueIdentifier {get; set;}
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        public string Attribute10 { get; set; }
        public string Attribute11 { get; set; }
        public string Attribute12 { get; set; }
        public string Attribute13 { get; set; }
        public string Attribute14 { get; set; }
        public string Attribute15 { get; set; }
        public string Attribute16 { get; set; }
        public string Attribute17 { get; set; }

    }

    [Table("supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

    }

    [Table("manufacturer")]
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarcodeEanPrefix { get; set; }
        public int MaxNumberOfProducts { get; set; }
        public int FirstNumberInCashRegister{ get; set; }
        public int LastNumberInCashRegister { get; set; }
        public string Info { get; set; }

    }

    [Table("tax")]
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public int TaxValue { get; set; }

    }

    [Table("elzab_communication")]
    public class ElzabCommunication
    {
        public enum CommunicationStatus
        {
            Started,
            FinishSuccess,
            FinishFailed,
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateOfCommunication { get; set; }
        public CommunicationStatus StatusOfCommunication { get; set; }
        public string ElzabCommandName { get; set; }
        public int ElzabCommandReportStatusCode { get; set; }
        public string ElzabCommandReportStatusText{ get; set; }

    }
}
