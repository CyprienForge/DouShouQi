using MyClassLibrary.Essentials;

namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour le changement du joueur actuel
    /// </summary>
    public class CurrentPlayerChangedEventArgs
    {
        /// <summary>
        /// Obtient le joueur actuel
        /// </summary>
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// Obtient le joueur 1
        /// </summary>
        public Player Player1 { get; set; }

        /// <summary>
        /// Obtient le joueur 2
        /// </summary>
        public Player Player2 { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe CurrentPlayerChangedEventArgs
        /// </summary>
        /// <param name="currentPlayer">Le joueur actuel</param>
        /// <param name="player1">Le joueur 1</param>
        /// <param name="player2">Le joueur 2</param>
        public CurrentPlayerChangedEventArgs(Player currentPlayer, Player player1, Player player2)
        {
            CurrentPlayer = currentPlayer;
            Player1 = player1;
            Player2 = player2;
        }
    }
}
