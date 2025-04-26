using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Dictionary
{
    public static class QuestStateEnum
    {
        #region Stany Zadania

        /// <summary>
        /// Stany Zadania
        /// </summary>
        public enum QuestState
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
            /// Wstrzymany
            /// </summary>
            OnBreak = 2,
            /// <summary>
            /// Ukończony
            /// </summary>
            Complete = 3,
            /// <summary>
            /// Zamknięty
            /// </summary>
            Closed = 4
        }
        #endregion
    }
}
