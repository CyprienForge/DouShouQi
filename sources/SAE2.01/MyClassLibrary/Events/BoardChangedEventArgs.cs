using MyClassLibrary.Essentials;

namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'un événement déclenché 
    /// lorsque le plateau recencie un déplacement
    /// </summary>
    public class BoardChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtient le plateau de jeu
        /// </summary>
        public Plateau Board { get; private set; }

        /// <summary>
        /// Obtient le nom du joueur
        /// </summary>
        public string NamePlayer { get; private set; }

        /// <summary>
        /// Nouvelle instance de BoardChangedEventArgs avec le plateau de jeu modifié
        /// </summary>
        /// <param name="board"> Plateau de jeu </param>
        public BoardChangedEventArgs(Plateau board, string namePlayer)
        {
            this.Board = board;
            this.NamePlayer = namePlayer;
        }   
    }
}
