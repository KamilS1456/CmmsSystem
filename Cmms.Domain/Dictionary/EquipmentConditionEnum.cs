using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Dictionary
{
    public static class EquipmentConditionEnum
    {
        #region Stany sprzętu

        /// <summary>
        /// Stany sprzętu
        /// </summary>
        public enum EquipmentCondition
        {
            /// <summary>
            /// Działający
            /// </summary>
            Operating = 0,
            /// <summary>
            /// Nie sprawny
            /// </summary>
            Foulty = 1
        }
        #endregion
    }
}
