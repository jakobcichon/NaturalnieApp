using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturalnieApp.Forms.TestForm
{
    partial class PopupMessage : Form
    {
        public PopupMessage()
        {
            InitializeComponent();
        }
        public PopupMessage(string title, string description)
        {

            InitializeComponent();
        }

        /// <summary>
        /// Your custom message box helper.
        /// </summary>
        public void CustomMessageBox()
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new PopupMessage())
            {
                form.ShowDialog();
                ;
            }
        }
    }


}
