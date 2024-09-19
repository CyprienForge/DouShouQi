namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'un événement déclenché 
    /// lorsqu'un joueur échoue la saisie d'un mouvement
    /// </summary>
    public class PlayersSelectFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient l'erreur de message
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Nouvelle instance de PlayersSelectFailedEventArgs avec le message d'erreur
        /// </summary>
        /// <param name="errorMessage"> Message d'erreur </param>
        public PlayersSelectFailedEventArgs(string errorMessage) 
        { 
            ErrorMessage = errorMessage;
        }
    }
}
