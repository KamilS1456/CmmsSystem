using System;

namespace Cmms.Domain.Dictionary
{
    public static class Dictionary
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
        #region Typy operacji
        /// <summary>
        /// Typy operacji
        /// </summary>
        [Flags]
        public enum OperationType
        {
            /// <summary>
            /// Odczytanie
            /// </summary>
            Read = 0,
            /// <summary>
            /// Stworzenie/dodanie
            /// </summary>
            Create = 1,
            /// <summary>
            /// Aktualizaczja/zmiana
            /// </summary>
            Update = 2,
            /// <summary>
            /// Usunięcie
            /// </summary>
            Delete = 4
        }
        #endregion
        #region Stany Zdarzenia
        /// <summary>
        /// Stany Zdarzenia
        /// </summary>
        public enum OccuranceState
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
