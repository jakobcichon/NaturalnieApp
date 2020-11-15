using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Dymo;

namespace ASP.NET_Sample
{
    public partial class _Default : System.Web.UI.Page
    {
        private DymoAddInClass _dymoAddin = new DymoAddInClass();
        private DymoLabelsClass _dymoLabels = new DymoLabelsClass();
        
        private void InitLabelObjects()
        {
            objNamesCmb.Items.Clear();
            string str = _dymoLabels.GetObjectNames(false);
            foreach (string name in str.Split(new char[] { '|' }))
            {
                objNamesCmb.Items.Add(name);
            }

            if (objNamesCmb.Items.Count > 0)
            {
                objDataEdit.Enabled = true;
                objNamesCmb.SelectedIndex = 0;
                objDataEdit.Text = _dymoLabels.GetText(objNamesCmb.Text);
            }
            else
            {
                objDataEdit.Enabled = false;
                objDataEdit.Text = string.Empty;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labelFileNamelbl.Text = _dymoAddin.FileName;

                // init mru
                string str = _dymoAddin.GetMRULabelFiles();
                foreach (string name in str.Split(new char[] { '|' }))
                {
                    mruCmb.Items.Add(Path.GetFileNameWithoutExtension(name));
                }
                
                // init printer list
                trayCmb.Enabled = false;
                printersCmb.Items.Clear();
                str = _dymoAddin.GetDymoPrinters();
                foreach (string name in str.Split(new char[] { '|' }))
                {
                    printersCmb.Items.Add(name);
                    if (_dymoAddin.IsTwinTurboPrinter(name))
                    {
                        trayCmb.Enabled = true;
                    }
                }

                if (printersCmb.Items.Count > 0)
                {
                    printersCmb.SelectedIndex = 0;
                }

                if (trayCmb.Enabled)
                {
                    trayCmb.SelectedIndex = 0;
                }

                InitLabelObjects();
            }
        }

        protected void objNamesCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string objName = objNamesCmb.SelectedValue;
            objDataEdit.Text = _dymoLabels.GetText(objName);
        }

        protected void setObjDataBtn_Click(object sender, EventArgs e)
        {
            _dymoLabels.SetField(objNamesCmb.Text, objDataEdit.Text);
        }

        protected void printBtn_Click(object sender, EventArgs e)
        {
            _dymoAddin.Print2(1, false, trayCmb.SelectedIndex);
        }

        protected void mruCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dymoAddin.OpenMRULabelFileByName(mruCmb.SelectedValue))
            {
                InitLabelObjects();
            }
        }
    }
}
