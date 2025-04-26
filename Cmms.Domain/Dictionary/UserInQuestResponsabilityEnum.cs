using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Dictionary
{
    public static class UserInQuestResponsabilityEnum
    {
        #region typy odpowiedzialności użytkowników przypisanych do zadania

        /// <summary>
        /// Typy odpowiedzialności użytkowników przypisanych do zadania
        /// </summary>
        public enum UserInQuestResponsability
        {
            /// <summary>
            /// Nadzorujący
            /// </summary>
            Menager = 0,

            /// <summary>
            /// Wykonujący
            /// </summary>
            Worker = 1,

            /// <summary>
            /// Obserwator
            /// </summary>
            Observer = 1
        }
        #endregion
    }
}
