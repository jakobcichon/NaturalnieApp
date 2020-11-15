//----------------------------------------------------------------------------
//
//  $Id: Form1.cs 11740 2010-05-06 18:54:48Z vbuzuev $ 
//
// Project -------------------------------------------------------------------
//
//  DYMO Label Framework Samples
//
// Content -------------------------------------------------------------------
//
//  Sample demonstrates basic Framework using from a C# application
//
//----------------------------------------------------------------------------
//
//  Copyright (c), 2010, Sanford, L.P. All Rights Reserved.
//
//----------------------------------------------------------------------------
using System;
using System.Threading;
using System.Windows.Forms;
using DYMO.Label.Framework;

namespace CSharp_Sample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : Form
	{
		//public DymoAddInClass DymoAddIn;
		//public DymoLabelsClass DymoLabels;
	    private ILabel _label;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
				
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox FileNameEdit;
		private System.Windows.Forms.Button BrowseBtn;
		private System.Windows.Forms.ComboBox ObjectNameCmb;
		private System.Windows.Forms.TextBox ObjectDataEdit;
		private System.Windows.Forms.ComboBox LabelWriterCmb;
		private System.Windows.Forms.ComboBox TrayCmb;
		private System.Windows.Forms.Button PrintLabelBtn;
		private System.Windows.Forms.Button CloseBtn;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameEdit = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObjectDataEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjectNameCmb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrintLabelBtn = new System.Windows.Forms.Button();
            this.TrayCmb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelWriterCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a label file here: (click Browse... to browse to the file)";
            // 
            // FileNameEdit
            // 
            this.FileNameEdit.Location = new System.Drawing.Point(16, 32);
            this.FileNameEdit.Name = "FileNameEdit";
            this.FileNameEdit.ReadOnly = true;
            this.FileNameEdit.Size = new System.Drawing.Size(424, 20);
            this.FileNameEdit.TabIndex = 1;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(448, 32);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.Click += new System.EventHandler(this.Browse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ObjectDataEdit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ObjectNameCmb);
            this.groupBox1.Location = new System.Drawing.Point(20, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 148);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Object";
            // 
            // ObjectDataEdit
            // 
            this.ObjectDataEdit.Enabled = false;
            this.ObjectDataEdit.Location = new System.Drawing.Point(204, 48);
            this.ObjectDataEdit.Multiline = true;
            this.ObjectDataEdit.Name = "ObjectDataEdit";
            this.ObjectDataEdit.Size = new System.Drawing.Size(284, 84);
            this.ObjectDataEdit.TabIndex = 3;
            this.ObjectDataEdit.Leave += new System.EventHandler(this.ObjectDataEdit_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(208, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Set label object data here:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a label object here:";
            // 
            // ObjectNameCmb
            // 
            this.ObjectNameCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectNameCmb.Enabled = false;
            this.ObjectNameCmb.Location = new System.Drawing.Point(16, 48);
            this.ObjectNameCmb.Name = "ObjectNameCmb";
            this.ObjectNameCmb.Size = new System.Drawing.Size(172, 21);
            this.ObjectNameCmb.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PrintLabelBtn);
            this.groupBox2.Controls.Add(this.TrayCmb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LabelWriterCmb);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(20, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 132);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LabelWriter Selection";
            // 
            // PrintLabelBtn
            // 
            this.PrintLabelBtn.Enabled = false;
            this.PrintLabelBtn.Location = new System.Drawing.Point(8, 96);
            this.PrintLabelBtn.Name = "PrintLabelBtn";
            this.PrintLabelBtn.Size = new System.Drawing.Size(84, 23);
            this.PrintLabelBtn.TabIndex = 4;
            this.PrintLabelBtn.Text = "Print Label";
            this.PrintLabelBtn.Click += new System.EventHandler(this.PrintLabelBtn_Click);
            // 
            // TrayCmb
            // 
            this.TrayCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrayCmb.Enabled = false;
            this.TrayCmb.Items.AddRange(new object[] {
            "Auto",
            "Left",
            "Right"});
            this.TrayCmb.Location = new System.Drawing.Point(312, 64);
            this.TrayCmb.Name = "TrayCmb";
            this.TrayCmb.Size = new System.Drawing.Size(128, 21);
            this.TrayCmb.TabIndex = 3;
            this.TrayCmb.SelectedIndexChanged += new System.EventHandler(this.TrayCmb_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(308, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Set tray selection (available only with LabelWriter TWIN TURBO)";
            // 
            // LabelWriterCmb
            // 
            this.LabelWriterCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LabelWriterCmb.Location = new System.Drawing.Point(8, 64);
            this.LabelWriterCmb.Name = "LabelWriterCmb";
            this.LabelWriterCmb.Size = new System.Drawing.Size(280, 21);
            this.LabelWriterCmb.TabIndex = 1;
            this.LabelWriterCmb.SelectedIndexChanged += new System.EventHandler(this.LabelWriterCmb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select a LabelWriter here:";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(452, 372);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "lwl";
            this.openFileDialog1.Filter = "DYMO Label File (*.label)|*.label";
            this.openFileDialog1.Title = "Open DYMO Label File";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(540, 402);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.FileNameEdit);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DYMO Label Framework C# Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void SetupLabelObject()
		{
			// clear edit control
			ObjectDataEdit.Clear();
			
			// clear all items first
			ObjectNameCmb.Items.Clear();

            if (_label == null)
                return;

            foreach (string objName in _label.ObjectNames)
                if (!string.IsNullOrEmpty(objName))
                    ObjectNameCmb.Items.Add(objName);

            if (ObjectNameCmb.Items.Count > 0)
                ObjectNameCmb.SelectedIndex = 0;

		    //// get the objects on the label
            //string ObjNames = DymoLabels.GetObjectNames(true);
            //// parse the result
            //if (ObjNames != null)
            //{
            //    int i = ObjNames.IndexOf('|');
            //    while (i >= 0)
            //    {
            //        ObjectNameCmb.Items.Add(ObjNames.Substring(0, i));
            //        ObjNames = ObjNames.Remove(0, i + 1);
            //        i = ObjNames.IndexOf('|');
            //    }
            //    if (ObjNames.Length > 0)
            //        ObjectNameCmb.Items.Add(ObjNames);

            //    ObjectNameCmb.SelectedIndex = 0;
            //}
		}
		
        //private void SetupLabelWriterSelection(bool InitCmb)
        //{
        //    // get the objects on the label
        //    if (InitCmb)
        //    {
        //        // clear all items first
        //        LabelWriterCmb.Items.Clear();
				
        //        string PrtNames = DymoAddIn.GetDymoPrinters();

        //        if (PrtNames != null)
        //        {
        //            // parse the result
        //            int i = PrtNames.IndexOf('|');
        //            while (i >= 0)
        //            {
        //                LabelWriterCmb.Items.Add(PrtNames.Substring(0, i));
        //                PrtNames = PrtNames.Remove(0, i + 1);
        //                i = PrtNames.IndexOf('|');
        //            }
        //            if (PrtNames.Length > 0)
        //                LabelWriterCmb.Items.Add(PrtNames);
						
        //            PrtNames = DymoAddIn.GetCurrentPrinterName();
        //            if (PrtNames != null)
        //                LabelWriterCmb.SelectedIndex = LabelWriterCmb.Items.IndexOf(PrtNames);
        //            else
        //                LabelWriterCmb.SelectedIndex = 0;
        //        }
        //    }
				
        //    // check if selected/current printer is a twin turbo printer
        //    TrayCmb.Enabled = DymoAddIn.IsTwinTurboPrinter(LabelWriterCmb.Text);
        //    if (TrayCmb.Enabled)
        //    {
        //        // show the current tray selection if the printer
        //        // is a twin turbo
        //        switch (DymoAddIn.GetCurrentPaperTray())
        //        {
        //            case 0: // left tray
        //                TrayCmb.SelectedIndex = 0;
        //                break;
						
        //            case 1: // right tray
        //                TrayCmb.SelectedIndex = 1;
        //                break;
					
        //            case 2: // auto switch
        //                TrayCmb.SelectedIndex = 2;
        //                break;
						
        //            default: // tray selection not set, so default to auto switch
        //                TrayCmb.SelectedIndex = 2;
        //                break;
        //        }
        //    }
        //}

        private void SetupTraySelection()
        {
            // enable/disable tray based on selected printer

            TrayCmb.Enabled = false; // disable by default

            string printerName = LabelWriterCmb.Text;
            ILabelWriterPrinter printer = Framework.GetPrinters()[printerName] as ILabelWriterPrinter;
            TrayCmb.Enabled = printer != null && printer.IsTwinTurbo;
        }

        private void SetupLabelWriterSelection()
        {
            // clear all items first
            LabelWriterCmb.Items.Clear();

            foreach (IPrinter printer in Framework.GetPrinters())
                LabelWriterCmb.Items.Add(printer.Name);

            if (LabelWriterCmb.Items.Count > 0)
                LabelWriterCmb.SelectedIndex = 0;

            LabelWriterCmb.Enabled = LabelWriterCmb.Items.Count > 0;
        }
        
        private static void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            MessageBox.Show(t.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);  
        }

        private void Form1_Load(object sender, System.EventArgs e)
		{
            Application.ThreadException += OnThreadException;

            TrayCmb.SelectedIndex = 0;

			// populate label objects
			SetupLabelObject();					

			// obtain the currently selected printer
			SetupLabelWriterSelection();

            UpdateControls();
		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
		}
		
		private void Browse_Click(object sender, System.EventArgs e)
		{
			// use the current file name's folder as the initial
			// directory for the open file dialog
            //string str = FileNameEdit.Text;
            //int i = str.LastIndexOf("\\");
            //str = str.Substring(0, i);
            //openFileDialog1.InitialDirectory = str;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
			    _label = Framework.Open(openFileDialog1.FileName);

                // show the file name
				FileNameEdit.Text = openFileDialog1.FileName;
					
				// populate label objects
				SetupLabelObject();					

				// setup paper tray selection
				//SetupLabelWriterSelection(false);

                UpdateControls();
			}
		}
		
		private void LabelWriterCmb_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			//DymoAddIn.SelectPrinter(LabelWriterCmb.Text);
		    SetupTraySelection();
		}

        //private void PrintLabelBtn_Click(object sender, System.EventArgs e)
        //{
        //    // ATTENTION: This call is very important if you're making mutiple calls to the Print() or Print2() function!
        //    // It's a good idea to always wrap StartPrintJob() and EndPrintJob() around a call to Print() or Print2() function.
        //    DymoAddIn.StartPrintJob();
			
        //    // print two copies
        //    DymoAddIn.Print2(1, false, TrayCmb.SelectedIndex);
			
        //    // ATTENTION: Every StartPrintJob() must have a matching EndPrintJob()
        //    DymoAddIn.EndPrintJob();
        //}

        private void PrintLabelBtn_Click(object sender, System.EventArgs e)
        {
            IPrinter printer = Framework.GetPrinters()[LabelWriterCmb.Text];
            if (printer is ILabelWriterPrinter)
            {
                ILabelWriterPrintParams printParams = null;
                ILabelWriterPrinter labelWriterPrinter = printer as ILabelWriterPrinter;
                if (labelWriterPrinter.IsTwinTurbo)
                {
                    printParams = new LabelWriterPrintParams();
                    printParams.RollSelection = (RollSelection)Enum.Parse(typeof(RollSelection), TrayCmb.Text);
                }

                _label.Print(printer, printParams);
            }
            else
                _label.Print(printer); // print with default params
        }
        
        private void CloseBtn_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void ObjectDataEdit_Leave(object sender, System.EventArgs e)
		{
			//DymoLabels.SetField(ObjectNameCmb.Text, ObjectDataEdit.Text);
            _label.SetObjectText(ObjectNameCmb.Text, ObjectDataEdit.Text);
		}

        private void TrayCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateControls()
        {
            ObjectNameCmb.Enabled = ObjectNameCmb.Items.Count > 0;
            ObjectDataEdit.Enabled = ObjectNameCmb.Items.Count > 0 && !string.IsNullOrEmpty(ObjectNameCmb.Text);
            PrintLabelBtn.Enabled = _label != null && !string.IsNullOrEmpty(PrintLabelBtn.Text);
        }
	}
}
