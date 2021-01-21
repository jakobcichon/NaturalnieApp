using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Database;

namespace NaturalnieApp.Forms.Common
{
    public partial class SearchBarTemplate : UserControl
    {
        public struct Properties
        {
            bool FilterByManufacturer;
        }


        //Private fields        
        private Manufacturer ManufacturerEntity;
        private Product ProductEntity;
        private Tax TaxEntity;

        private List<string> FullManufacturersList;
        private List<string> FullProductsList;
        private List<string> FullBarcodesList;

        private List<string> FilteredProductsList;
        private List<string> FilteredBarcodeList;

        Dictionary

        public SearchBarTemplate()
        {
            InitializeComponent();
            cbManufacturer.Dis
        }


        //Public methods
        public void UpdateCurrentEntity()
        {
            ;
        }

        public void SelectBarcode(string barcodeValue)
        {
            ;
        }
        public void SelectManufacturer(string ManufacturerName)
        {
            ;
        }
        public void SelectProduct(string ProductName)
        {
            ;
        }

        //Private methods
        private void GetEntityByBarcode()
        {
            ;
        }
    }

}
