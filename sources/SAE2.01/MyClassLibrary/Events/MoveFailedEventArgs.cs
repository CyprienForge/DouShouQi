namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour un échec de déplacement
    /// </summary>
    public class MoveFailedEventArgs
    {
        /// <summary>
        /// Obtient le message d'erreur de l'échec de déplacement
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe MoveFailedEventArgs avec le message d'erreur
        /// </summary>
        /// <param name="errorMessage">Le message d'erreur de l'échec de déplacement</param>
        public MoveFailedEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
