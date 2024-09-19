using MyClassLibrary.Essentials;

namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour la fin de partie
    /// </summary>
    public class GameOverEventArgs
    {
        /// <summary>
        /// Obtient l'instance de jeu associée à la fin de partie
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe GameOverEventArgs avec l'instance de jeu associée
        /// </summary>
        /// <param name="game">Instance de jeu associée à la fin de partie</param>
        public GameOverEventArgs(Game game)
        {
            Game = game;
        }
    }
}
