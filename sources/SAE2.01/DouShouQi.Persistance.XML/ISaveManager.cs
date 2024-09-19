using MyClassLibrary.Essentials;
using System.Runtime.Serialization;

namespace DouShouQi.Persistance.XML
{
    /// <summary>
    /// Interface pour gérer la sauvegarde et le chargement des parties de jeu au format XML
    /// </summary>
    public interface ISaveManager
    {
        /// <summary>
        /// Liste des parties de jeu
        /// </summary>
        public static List<Game> Games { get; set; }

        /// <summary>
        /// Serializer utilisé pour la sérialisation des données
        /// </summary>
        DataContractSerializer Serializer { get; }

        /// <summary>
        /// Charge la liste des parties de jeu à partir d'un fichier XML
        /// </summary>
        /// <param name="pathFile"> Chemin du fichier de sauvegarde </param>
        /// <returns> Liste des parties de jeu chargée </returns>
        public GameList LoadGames(string pathFile);

        /// <summary>
        /// Sauvegarde la liste des parties de jeu dans un fichier XML
        /// </summary>
        /// <param name="gameList"> Liste des parties de jeu à sauvegarder </param>
        /// <param name="pathFile"> Chemin du fichier de sauvegarde </param>
        public void SaveGames(GameList gameList, string pathFile);
    }
}
