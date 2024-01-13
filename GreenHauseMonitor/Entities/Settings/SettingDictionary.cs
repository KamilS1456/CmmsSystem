namespace Cmms.Entities.Settings
{
    public static class SettingDictionary
    {
        #region Typy ustawień

        /// <summary>
        /// Typy ustawień
        /// </summary>
        public enum SettingType
        {
            /// <summary>
            /// Logiczne
            /// </summary>
            Boolean = 0,
            /// <summary>
            /// Całkowite
            /// </summary>
            Integer = 1,
            /// <summary>
            /// Tekstowe
            /// </summary>
            String = 2,
            /// <summary>
            /// Identyfikacyjne
            /// </summary>
            Uniqueidentifier = 3,
        }
        #endregion
    }
}
