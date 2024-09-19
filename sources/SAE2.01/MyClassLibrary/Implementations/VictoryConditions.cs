using MyClassLibrary.Essentials;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary.Implementations
{
    /// <summary>
    /// Implémentation des méthode(s) annoncée(s) dans l'interface IVictory Manager
    /// Représente les règles/conditions de victoire du jeu
    /// </summary>
    public class VictoryConditions : IVictoryManager
    {
        /// <summary>
        /// Vérifie si la partie est terminée en vérifiant si une tanière est occupée
        /// et en contrôlant le nombre d'animal encore vivant pour les 2 joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <returns></returns>
        public bool GameOver(Player player1, Player player2, Plateau board, ref Player winnerPlayer)
        {
            if (board.Cases[0, 3].IsOccuped)
            {
                winnerPlayer = player2;
                return true;
            }

            if (board.Cases[8, 3].IsOccuped)
            {
                winnerPlayer = player1;
                return true;
            }

            if (player1.Animals.Count() == 0)
            {
                winnerPlayer = player2;
                return true;
            }

            if (player2.Animals.Count() == 0)
            {
                winnerPlayer = player1;
                return true;
            }


            return false;
            
        }
    }
}

