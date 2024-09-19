using MyClassLibrary.Essentials;
using System.Runtime.Serialization;

namespace DouShouQi.Persistance.XML
{
    /// <summary>
    /// Gère la sauvegarde et le chargement des parties de jeu au format XML
    /// </summary>
    public class SaveManager : ISaveManager
    {
        /// <summary>
        /// Liste des parties de jeu enregistrées
        /// </summary>
        public static List<Game> Games { get; private set; } = new List<Game>();

        /// <summary>
        /// Nom du fichier de sauvegarde par défaut
        /// </summary>
        private string nameFile = "game.xml";

        /// <summary>
        /// Serializer utilisé pour la sérialisation des données
        /// </summary>
        public DataContractSerializer Serializer { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe SaveManager
        /// </summary>
        public SaveManager()
        {
            Serializer = new DataContractSerializer(typeof(List<Game>), new DataContractSerializerSettings() { PreserveObjectReferences = true });
        }

        /// <summary>
        /// Sauvegarde la liste des parties de jeu dans un fichier XML
        /// </summary>
        /// <param name="gameList"> Liste des parties de jeu à sauvegarder </param>
        /// <param name="pathFile"> Chemin du fichier de sauvegarde </param>
        public void SaveGames(GameList gameList, string pathFile)
        {
            GameList games = LoadGames(pathFile);

            var serializer = new DataContractSerializer(typeof(GameList));
            using (Stream s = File.Create(pathFile))
            {
                serializer.WriteObject(s, gameList);
            }
        }

        /// <summary>
        /// Charge la liste des parties de jeu à partir d'un fichier XML
        /// </summary>
        /// <param name="pathFile"> Chemin du fichier de sauvegarde </param>
        /// <returns> Liste des parties de jeu chargée </returns>
        public GameList LoadGames(string pathFile)
        {
            GameList games = new GameList();

            var serializer = new DataContractSerializer(typeof(GameList));
            using (Stream s = File.OpenRead(pathFile))
            {
                games = serializer.ReadObject(s) as GameList;
            }

            return games;
        }

    }
}
