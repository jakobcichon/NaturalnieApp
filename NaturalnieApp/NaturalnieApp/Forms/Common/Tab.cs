using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturalnieApp.Forms.Common
{
    public partial class Tab : UserControl
    {
        Color BackgroundColor { get; set; }
        Color ForgoundColor { get; set; }

        public Tab()
        {
            InitializeComponent();
        }
    }
}
