using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Dictionary
{
    public static class OrderStateEnum
    {
        #region Stany zamowienia
        /// <summary>
        /// Stany Zdarzenia
        /// </summary>
        public enum OrderState
        {
            /// <summary>
            /// Nowy
            /// </summary>
            New = 0,
            /// <summary>
            /// W trakcie
            /// </summary>
            InProgress = 1,
            /// <summary>
            /// Ukończony
            /// </summary>
            Complete = 2,

        }
        #endregion
    }
}
