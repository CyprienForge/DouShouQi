using MyClassLibrary.Essentials;
using MyClassLibrary.Events;

namespace MyClassLibrary.Interfaces
{
    /// <summary>
    /// Représente le type de contrat qui définit l'ensemble des membres utilisés 
    /// pour définir les règles/contraintes de déplacement pour chaque joueur et ses animaux
    /// </summary>
    public interface IMoveManager
    {
        /// <summary>
        /// Vérifie que le déplacement demandé est autorisé par les règles/contraintes du jeu
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur en cas d'échec du déplacement </param>
        /// <returns> True : Le déplacement est autorisé, False : Le déplacement est refusé </returns>
        public bool CheckMove(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Plateau board, ref string errorMessage);

        /// <summary>
        /// Effectue le déplacement d'un animal sur le plateau de tests
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur en cas d'échec du déplacement </param>
        /// <returns> True : Le déplacement réussie, False : Le déplacement échoue </returns>
        public bool MoveAnimal(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Player waitingPlayer, Plateau board);

        // <summary>
        /// Événement déclenché lorsqu'un combat a lieu entre deux animaux.
        /// </summary>
        public event EventHandler<FightedEventArgs>? Fighted;

        /// <summary>
        /// Événement déclenché lorsqu'un animal est déplacé sur le plateau.
        /// </summary>
        public event EventHandler<MovedEventArgs>? Moved;
    }
}
