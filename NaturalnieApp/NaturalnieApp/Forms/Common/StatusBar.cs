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

    public partial class StatusBar : UserControl, IStatusBar
    {
        //Thread lockers
        private object dbLocker = new object();
        private object cashRegisterLocker = new object();

        public StatusBar()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Method used to update Database icon status. Method thread-safe.
        /// </summary>
        /// <param name="statusToSet">Requested status to set</param>
        /// <returns>True - if status was set successfuly; False - if method was locked by other task</returns>
        public bool UpdateStatusFrom_Db(GeneralStatus statusToSet)
        {
            //Lock the object
            lock(this.dbLocker)
            {
                //Switch the case
                switch (statusToSet)
                {
                    case GeneralStatus.Offline:
                        this.pbDbStatus.Image = Properties.Resources.DbStatusNok;
                        return true;
                    case GeneralStatus.Online:
                        this.pbDbStatus.Image = Properties.Resources.DbStatusOK;
                        return true;
                    case GeneralStatus.Transfering:
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method used to update Cash register icon status. Method thread-safe.
        /// </summary>
        /// <param name="statusToSet">Requested status to set</param>
        /// <returns>True - if status was set successfuly; False - if method was locked by other task</returns>
        public bool UpdateStatus_CashRegister(GeneralStatus statusToSet)
        {
            //Lock the object
            lock (this.dbLocker)
            {
                try
                {
                    //Switch the case
                    switch (statusToSet)
                    {
                        case GeneralStatus.Offline:
                            this.pbCashRegisterCommunication.Size = new Size(30, 30);
                            this.pbCashRegisterCommunication.Image = Properties.Resources.cashRegisterOffline;
                            return true;
                        case GeneralStatus.Online:
                            this.pbCashRegisterCommunication.Size = new Size(30, 30);
                            this.pbCashRegisterCommunication.Image = Properties.Resources.CashRegisterOnline;
                            return true;
                        case GeneralStatus.Transfering:
                            this.pbCashRegisterCommunication.Size = new Size(60, 30);
                            this.pbCashRegisterCommunication.Image = Properties.Resources.cashRegisterExchange;
                            return true;
                    }

                }
                catch
                {
                    ;

                }
            }
            return false;
        }

        private void pbDbStatus_ControlAdded(object sender, ControlEventArgs e)
        {
            //Get background colour from parent form
            this.BackColor = this.Controls.Owner.BackColor;
        }

        private void GeneralEvent_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }


        private void GeneralEvent_MouseUp(object sender, MouseEventArgs e)
        {
           this.OnMouseUp(e);
        }

        private void GeneralEvent_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }
    }

    //Enums
    public enum GeneralStatus
    {
        Offline,
        Online,
        Transfering,
    }
}
