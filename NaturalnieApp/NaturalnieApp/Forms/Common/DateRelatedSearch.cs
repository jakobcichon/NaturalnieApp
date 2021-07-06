using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturalnieApp.Database;

namespace NaturalnieApp.Forms.Common
{
    public partial class DateRelatedSearch : UserControl
    {
        #region Event definition

        //New Ent selected event
        public class NewEntSelectedEventArgs : EventArgs
        {
            public Manufacturer SelectedManufacturer { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public delegate void NewEntSelectedEventHandler(Object sender, NewEntSelectedEventArgs e);

        protected virtual void OnNewEntSelected(NewEntSelectedEventArgs e)
        {
            NewEntSelectedEventHandler handler = NewEntSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event NewEntSelectedEventHandler NewEntSelected;


        //Generic button click event
        public class GenericButtonClickEventArgs : EventArgs
        {
            public Manufacturer SelectedManufacturer { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public delegate void GenericButtonClickEventHandler(Object sender, GenericButtonClickEventArgs e);

        protected virtual void OnGenericButtonClick(GenericButtonClickEventArgs e)
        {
            GenericButtonClickEventHandler handler = GenericButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event GenericButtonClickEventHandler GenericButtonClick;

        //New Ent selected by additional request (by calling SelectEntAdditionalRequest)
        public delegate void NewEntSelectedByAdditionalRequestEventHandler(Object sender, NewEntSelectedEventArgs e);

        protected virtual void OnNewEntSelectedByAdditionalRequest(NewEntSelectedEventArgs e)
        {
            NewEntSelectedByAdditionalRequestEventHandler handler = NewEntSelectedByAdditionalRequest;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event NewEntSelectedByAdditionalRequestEventHandler NewEntSelectedByAdditionalRequest;
        #endregion

        //Properties class
        public class PropertiesClass
        {
            public bool GenButtonExist { get; set; }

            public PropertiesClass()
            {
                this.GenButtonExist = false;
            }
        }


        //DB events Args
        public class ManufacturerDataFromDatabase
        {
            //Dictionary for manufacturers list <key = manufacturerId, value = manufacturer name>
            public Dictionary<string, int> ManufacturersDict { get; set; }

        }

        //Private fields        
        private Manufacturer ManufacturerEntity { get; set; }

        private Dictionary<string, int> FullManufacturersDict { get; set; }

        //Dictionary for product list <key = manufacturerId, value = product name>
        private Dictionary<string, int> ManufacturersToDisplayDict { get; set; }

        //Auiliary variables to  bypass calling selected index chnaged if entity was selected by program
        private bool SelectEntByAdditionalRequest { get; set; }

        //Database context
        DatabaseCommands DatabaseCommands;

        //Backgound worker for connection to db
        BackgroundWorker DbBackgroundWorker;

        //Properties
        private PropertiesClass Properties { get; set; }

        //Public fields
        //Show if search bar busy
        public bool IsBussy { get; set; }
        
        public DateRelatedSearch()
        {
            //Call setup method
            Setup();

            //Initialize generic button
            this.Properties.GenButtonExist = true;

            //Adjust appearance of search bar
            AdjustSearchBarAppearance();
        }

        public DateRelatedSearch(bool genButtonExist = true)
        {
            //Call setup method
            Setup();

            //Initialize generic button
            this.Properties.GenButtonExist = genButtonExist;

            //Adjust appearance of search bar
            AdjustSearchBarAppearance();
        }

        //Setup method
        public void Setup()
        {
            //Initialize component
            InitializeComponent();

            //Set double buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);

            //Initialize database commands
            this.DatabaseCommands = new DatabaseCommands();

            //Initialize background worker
            InitializeBackgroundWorker();


            //Initialize autocomplete source
            this.cbManufacturers.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbManufacturers.AutoCompleteMode = AutoCompleteMode.Suggest;

            //Prevent Comboboxes flickering
            DoDoubleBuffered(cbManufacturers.Parent, true);

            //Initialize properties
            this.Properties = new PropertiesClass();

        }

        //Mathod used to adjusted search bar appearance
        public void AdjustSearchBarAppearance()
        {
            if(this.Properties.GenButtonExist)
            {
                this.bGenericButton.Visible = true;
                this.bGenericButton.Enabled = true;
                this.pManufacturer.Size = new Size(220,70);
                this.pStartDate.Size = new Size(300, this.pManufacturer.Size.Height);
                this.pEndDate.Size = new Size(300, this.pManufacturer.Size.Height);

                this.pStartDate.Location = new Point(this.pManufacturer.Location.X + this.pManufacturer.Size.Width + 5
                    , this.pStartDate.Location.Y);
                this.pEndDate.Location = new Point(this.pStartDate.Location.X + this.pStartDate.Size.Width + 5
                    , this.pEndDate.Location.Y);
            }
            else
            {
                this.bGenericButton.Visible = false;
                this.bGenericButton.Enabled = false;
                this.pManufacturer.Size = new Size(220, 70);
                this.pStartDate.Size = new Size(300, this.pManufacturer.Size.Height);
                this.pEndDate.Size = new Size(300, this.pManufacturer.Size.Height);

                this.pStartDate.Location = new Point(this.pManufacturer.Location.X + this.pManufacturer.Size.Width + 5
                    , this.pStartDate.Location.Y);
                this.pEndDate.Location = new Point(this.pStartDate.Location.X + this.pStartDate.Size.Width + 5
                    , this.pEndDate.Location.Y);
            }
        }

        //=============================================================================
        //                              Background worker
        //=============================================================================
        // Set up the BackgroundWorker object by attaching event handlers. 
        #region Backgroundworker
        private void InitializeBackgroundWorker()
        {
            this.DbBackgroundWorker = new BackgroundWorker();
            // here you have also to implement the necessary events
            // this event will define what the worker is actually supposed to do
            this.DbBackgroundWorker.DoWork += this.DbBackgroundWorker_DoWork;
            // this event will define what the worker will do when finished
            this.DbBackgroundWorker.RunWorkerCompleted += this.DbBackgroundWorker_RunWorkerCompleted;
        }
        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            try
            {
                ManufacturerDataFromDatabase manufacturerData = new ManufacturerDataFromDatabase();
                manufacturerData.ManufacturersDict = new Dictionary<string, int>();

                //Get list of product and manufacurers ents
                List<Manufacturer> manufacturersList = this.DatabaseCommands.GetAllManufacturersEnts();

                //Assigne manufacturer data from DB to dictionares
                foreach (Manufacturer manufacturer in manufacturersList)
                {
                    manufacturerData.ManufacturersDict.Add(manufacturer.Name, manufacturer.Id);
                }

                e.Result = manufacturerData;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // This event handler is where the actual, potentially time-consuming work is done.
        private void DbBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //Get all data from DB
                ManufacturerDataFromDatabase localData = (ManufacturerDataFromDatabase)e.Result;

                //Initialize with fetched data
                this.FullManufacturersDict = localData.ManufacturersDict;
                this.FullManufacturersDict.Add("Wszyscy",0);
                this.ManufacturersToDisplayDict = this.FullManufacturersDict;

                //Update data sources
                UpdateDataSources(this.ManufacturersToDisplayDict);

                //Hide loading bar
                HideLoadingBar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region General methods
        //General methods
        public static void DoDoubleBuffered(Control formControl, bool setting)
        {
            Type conType = formControl.GetType();
            PropertyInfo pi = conType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(formControl, setting, null);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if ((keyData == Keys.Enter))
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);

            }
            else if (keyData == Keys.Escape)
            {
                //Update control
                UpdateControl(ref tbDummyForCtrl);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Update control
        private void UpdateControl(ref TextBox dummyForControl)
        {
            this.Focus();
            dummyForControl.Select();
        }

        //Method used to update comboboxes datasources 
        private void UpdateDataSources(Dictionary<string, int> manufacturersData = null)
        {
            List<string> dataToList;

            //Update manufacturers list
            if (manufacturersData != null)
            {
                //Copy datasource to local variable first
                this.cbManufacturers.DataSource = null;
                dataToList = manufacturersData.Keys.ToList();
                dataToList.Remove("Wszyscy");
                dataToList.Sort();
                dataToList.Insert(0, "Wszyscy");
                this.cbManufacturers.DataSource = dataToList;
            }

            //Update control
            this.UpdateControl(ref this.tbDummyForCtrl);
        }
        //=============================================================================
        #endregion

        //Public methods
        public void ShowGenericButton()
        {
            this.Properties.GenButtonExist = true;
            AdjustSearchBarAppearance();
        }
        public void HideGenericButton()
        {
            this.Properties.GenButtonExist = false;
            AdjustSearchBarAppearance();
        }
     

        //Private methods
        private void ShowLoadingBar()
        {
            this.cbManufacturers.Enabled = false;
            if (this.Properties.GenButtonExist) this.bGenericButton.Enabled = false;
            this.pbLoadingBar.BringToFront();
            this.tpLoadingBar.Show();
            this.IsBussy = true;
        }
        private void HideLoadingBar()
        {
            this.tpLoadingBar.Hide();
            this.cbManufacturers.Enabled = true;
            if (this.Properties.GenButtonExist) this.bGenericButton.Enabled = true;
            this.IsBussy = false;
        }
        private void SearchBarTemplate_Load(object sender, EventArgs e)
        {
            if(!this.DesignMode)
            {
                //Show loading bar
                ShowLoadingBar();

                //Run backgorundworker
                if(!this.DbBackgroundWorker.IsBusy) this.DbBackgroundWorker.RunWorkerAsync();
            }
        }
        private void cbManufacturers_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void cbManufacturers_TextChanged(object sender, EventArgs e)
        {
            //Cast sender
            ComboBox localSender = (ComboBox)sender;
            if (localSender.DroppedDown)
            {
                localSender.DroppedDown = false;
            }
        }
       
        private void bGenericButton_Click(object sender, EventArgs e)
        {
            //Get manufacturer entity
            Manufacturer localManufacturer = null;
            if(this.cbManufacturers.SelectedItem != null && this.cbManufacturers.SelectedItem.ToString() != "Wszyscy")
            {
                try
                {
                    localManufacturer = this.DatabaseCommands.GetManufacturerEntityByName(this.cbManufacturers.SelectedItem.ToString());
                }
                catch
                {
                    localManufacturer = null;
                }
            }

            //Call an event
            NewEntSelectedEventArgs args = new NewEntSelectedEventArgs();
            args.SelectedManufacturer = localManufacturer;
            args.StartDate = this.dtpStartDate.Value;
            args.EndDate = this.dtpEndDate.Value;
            this.NewEntSelected(this, args);
           
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            //Prevent to select start date grater than end date
            if (this.dtpStartDate.Value > this.dtpEndDate.Value) this.dtpEndDate.Value = this.dtpStartDate.Value.AddDays(1.0);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            //Prevent to select end date lower than start date
            if (this.dtpEndDate.Value < this.dtpStartDate.Value) this.dtpEndDate.Value = this.dtpStartDate.Value;
        }
    }

}
