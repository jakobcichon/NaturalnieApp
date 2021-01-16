using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElzabCommands;
using static NaturalnieApp.Program;

namespace NaturalnieApp.Forms
{

    public partial class ElzabCommands : UserControl
    {
        //Declaration of used elzab commands
        ElzabCommand_OTOWAR AllProductsReading { get; set; }


        TextBox StatusBox { get; set; }


        public ElzabCommands()
        {
            InitializeComponent();

            //Initialization of Elzab commands instances
            this.AllProductsReading = new ElzabCommand_OTOWAR(GlobalVariables.ElzabCommandPath, GlobalVariables.ElzabCashRegisterId);

            //Status box
            this.StatusBox = this.tbStatus;
        }

        private void bReadingFromCashRegister_Click(object sender, EventArgs e)
        {
            try
            {

                //ChangeStatus
                this.StatusBox.Text = "Generowanie listy produktów";
                //Generate all product numbers
                List<int> productToReadList = GenerateProductNumbers(1, 6);
                int i = 0;
                foreach(int element in productToReadList)
                {
                    this.AllProductsReading.DataToElzab.AddElement(element.ToString());
                }

                //ChangeStatus
                this.StatusBox.Text = "Generowanie pliku textowego do kasy Elzab";
                this.AllProductsReading.ExecuteCommand();
                //this.AllProductsReading.Report.GenerateObjectFromRawData();
                ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<int> GenerateProductNumbers(int startIndex, int count)
        {

            if (startIndex >= 0 && count >= 1)
            {
                //Local variable
                List<int> retList = new List<int>();
                int endIndex = startIndex + count;

                for (int i = startIndex; i <= endIndex - 1; i++)
                {
                    retList.Add(i);
                }


                return retList;
            }
            else
            {
                MessageBox.Show("Błąd metody " + this.GetType().FullName + "." + startIndex + " :: " + count);
                return null;
            }
        }

    }
}
