using MyClassLibrary.Interfaces;
using MyClassLibrary.Implementations;
using MyTestProject.Data;
using MyClassLibrary.Essentials;

namespace MyTestProject.TestsFunctions
{
    /// <summary>
    /// Classe de tests sur les fonctionnalités du MoveMaster
    /// </summary>
    public class MoveMasterTests
    {
        /// <summary>
        /// Teste si le déplacement demandé est autorisé par les règles/contraintes du jeu
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestCheckMove), MemberType = typeof(DataTests))]
        public void TestCheckMove(int rowStart, int rowDest, int colStart, int colDest, bool expectedResult, Player player1, Player player2, Player currentPlayer)
        {
            string error = "";
            IMoveManager moveManager = new MoveMaster();
            bool result = moveManager.CheckMove(rowStart, rowDest, colStart, colDest, currentPlayer, new PlateauTest(player1, player2, 24), ref error);
            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Teste si le déplacement demandé est effectué ou non
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestMoveAnimal), MemberType = typeof(DataTests))]
        public void TestMoveAnimal(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult, Player player1, Player player2, Player currentPlayer)
        {
            IMoveManager moveManager = new MoveMaster();

            bool result = moveManager.MoveAnimal(rowStart, colStart, rowDest, colDest, currentPlayer, player2, new Plateau(player1, player2));
            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si le déplacement s'achève sur une case Piège ou non
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="idPlateau"> Plateau de Test </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestCheckTrapMovement), MemberType = typeof(DataTests))]
        public void TestTrap(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult, Player player1, Player player2, Player currentPlayer, Player waitingPlayer, int idPlateau)
        {
            IMoveManager moveManager = new MoveMaster();

            bool result = moveManager.MoveAnimal(rowStart, colStart, rowDest, colDest, currentPlayer, waitingPlayer, new PlateauTest(player1, player2, idPlateau));
            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si le déplacement s'achève sur une case Tanière ou non
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestCheckDenMovement), MemberType = typeof(DataTests))]
        public void TestDen(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult, Player player1, Player player2, Player currentPlayer, Player waitingPlayer)
        {
            IMoveManager moveManager = new MoveMaster();

            bool result = moveManager.MoveAnimal(rowStart, colStart, rowDest, colDest, currentPlayer, waitingPlayer, new PlateauTest(player1, player2, 3));
            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si le déplacement s'achève sur une case Rivière ou non
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestCheckRiverMovement), MemberType = typeof(DataTests))]
        public void TestRiver(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult, Player player1, Player player2, Player currentPlayer, Player waitingPlayer)
        {
            IMoveManager moveManager = new MoveMaster();

            bool result = moveManager.MoveAnimal(rowStart, colStart, rowDest, colDest, currentPlayer, waitingPlayer, new PlateauTest(player1, player2, 4));
            Assert.Equal(result, expectedResult);
        }
    }
}