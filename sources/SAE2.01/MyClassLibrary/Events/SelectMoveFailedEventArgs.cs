namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'un événement déclenché 
    /// lorsque la saisie d'un déplacement échoue
    /// </summary>
    public class SelectMoveFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient le message d'erreur
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Obtient la valeur minimale qu'une case peut supporter
        /// </summary>
        public int Min {  get; private set; }

        /// <summary>
        /// Obtient la valeur maximale qu'une case peut supporter
        /// </summary>
        public int Max { get; private set; }

        /// <summary>
        /// Nouvelle instance de SelectMoveFailedEventArgs avec les valeurs minimale et maximale
        /// </summary>
        /// <param name="min"> Valeur minimale qu'une case peut supporter. </param>
        /// <param name="max"> Valeur maximale qu'une case peut supporter. </param>
        public SelectMoveFailedEventArgs(int min, int max, string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
