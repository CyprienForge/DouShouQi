using MyClassLibrary.Essentials;
using MyClassLibrary.Events;
using MyClassLibrary.Implementations;
using MyClassLibrary.Interfaces;
using MyTestProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MyTestProject.TestsFunctions
{
    /// <summary>
    /// Classe de tests sur les fonctionnalités du GameMaster
    /// </summary>
    public class GameMasterTests
    {
        /// <summary>
        /// Teste si le changement du joueur courant s'effectue correctement
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="expectedPlayer"> Joueur attendu </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestCurrentPlayer), MemberType = typeof(DataTests))]
        public void TestCurrentPlayerChanged(Player player1, Player player2, Player currentPlayer, Player expectedPlayer)
        {
            IGameManager game = new GameMaster(player1, player2, currentPlayer);

            game.ChangeCurrentPlayer();
            Assert.Equal(game.CurrentPlayer, expectedPlayer);
        }

        /// <summary>
        /// Teste si la partie se termine correctement 
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="board"> Plateau du jeu </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        /*
        [Theory]
        [MemberData(nameof(DataTests.Data_TestGameOver), MemberType = typeof(DataTests))]
        public void TestGameOver(Player player1, Player player2, Plateau board, bool expectedResult)
        {
            IGameManager game = new GameMaster();
            bool result = game.IsGameOver(player1, player2, board);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("Tommy", "Cyprien")]
        [InlineData("a","b")]
        [InlineData("c", "d")]
        [InlineData("e", "f")]
        [InlineData("f", "g")]
        public void TestCreateGame(string namePlayer1, string namePlayer2)
        {
            IGameManager game = new GameMaster();

            game.CreateGame(namePlayer1, namePlayer2);
            Assert.Equal(game.Player1.Name, namePlayer1);
            Assert.Equal(game.Player2.Name, namePlayer2);
        }
        */
    }
}
