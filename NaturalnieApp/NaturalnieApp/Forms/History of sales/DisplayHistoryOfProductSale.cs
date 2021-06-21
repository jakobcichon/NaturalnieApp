using System.Windows.Forms;


namespace NaturalnieApp.Forms
{
    /// <summary>
    /// Class properties
    /// </summary>
  


    public partial class DisplayHistoryOfProductSale : UserControl
    {
        /// <summary>
        /// Class constructor
        /// </summary>
       public DisplayHistoryOfProductSale()
       {
            //Initialize component
            InitializeComponent();

            //Initialize name of current user control
            this.lName.Text = "Historia sprzedaży";
       }
    }
}
