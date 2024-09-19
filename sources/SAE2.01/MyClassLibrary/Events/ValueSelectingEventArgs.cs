namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'un événement déclenché 
    /// lorsqu'une saisie de valeur est demandé à un joueur
    /// </summary>
    public class ValueSelectingEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient le message
        /// </summary>
        public string Message {  get; private set; }

        /// <summary>
        /// Nouvelle instance de ValueSelectingEventArgs avec le message
        /// </summary>
        /// <param name="message"></param>
        public ValueSelectingEventArgs(string message) 
        {
            Message = message;
        }
    }
}
