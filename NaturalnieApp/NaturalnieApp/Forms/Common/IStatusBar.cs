using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalnieApp.Forms.Common
{
    interface IStatusBar
    {
        /// <summary>
        /// Method used to update Database icon status. Method thread-safe.
        /// </summary>
        /// <param name="statusToSet">Requested status to set</param>
        /// <returns>True - if status was set successfuly; False - if method was locked by other task</returns>
        bool UpdateStatusFrom_Db(GeneralStatus statusToSet);

        /// <summary>
        /// Method used to update Cash register icon status. Method thread-safe.
        /// </summary>
        /// <param name="statusToSet">Requested status to set</param>
        /// <returns>True - if status was set successfuly; False - if method was locked by other task</returns>
        bool UpdateStatus_CashRegister(GeneralStatus statusToSet);
    }
}
