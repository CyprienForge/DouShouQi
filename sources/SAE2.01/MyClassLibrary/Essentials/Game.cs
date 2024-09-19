using System.Runtime.Serialization;

namespace MyClassLibrary.Essentials
{
    /// <summary>
    /// Représente une partie de jeu
    /// </summary>
    [DataContract]
    public class Game
    {
        /// <summary>
        /// Obtient l'identifiant de la partie
        /// </summary>
        [DataMember(Order = 1)]
        public int Id { get; private set; }

        /// <summary>
        /// Obtient le joueur gagnant de la partie
        /// </summary>
        [DataMember(Order = 2)]
        public Player Winner { get; private set; }

        /// <summary>
        /// Obtient le joueur perdant de la partie
        /// </summary>
        [DataMember(Order = 3)]
        public Player Loser { get; private set; }

        /// <summary>
        /// Obtient la date de la partie
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime Date { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe
        /// </summary>
        /// <param name="id"> Identifiant de la partie </param>
        /// <param name="winner"> Joueur gagnant de la partie </param>
        /// <param name="loser"> Joueur perdant de la partie </param>
        /// <param name="date"> Date de la partie </param>
        public Game(int id, Player winner, Player loser, DateTime date)
        {
            Id = id;
            Winner = winner;
            Loser = loser;
            Date = date;
        }

        /// <summary>
        /// Retourne le nom du joueur gagnant de la partie
        /// </summary>
        /// <returns> Nom du joueur gagnant </returns>
        public override string ToString()
        {
            return Winner.Name;
        }
    }
}
