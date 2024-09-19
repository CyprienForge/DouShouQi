using MyClassLibrary.Essentials;

namespace MyClassLibrary.Interfaces
{
    /// <summary>
    /// Représente le type de contrat qui définit l'ensemble des membres utilisés 
    /// pour définir les règles/conditions de victoire du jeu
    /// </summary>
    public interface IVictoryManager
    {   
        /// <summary>
        /// Vérifie si la partie est terminée en vérifiant si une tanière est occupée
        /// et en contrôlant le nombre d'animal encore vivant pour les 2 joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <returns></returns>
        public bool GameOver(Player player1, Player player2, Plateau board, ref Player winnerPlayer);
    }
}
