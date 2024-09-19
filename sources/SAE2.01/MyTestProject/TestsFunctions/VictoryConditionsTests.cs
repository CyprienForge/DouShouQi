using MyClassLibrary.Essentials;
using MyClassLibrary.Implementations;
using MyClassLibrary.Interfaces;
using MyTestProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MyTestProject.TestsFunctions
{
    /// <summary>
    /// Classe de tests sur les fonctionnalités de VictoryConditions
    /// </summary>
    public class VictoryConditionsTests
    {
        /// <summary>
        /// Teste si une tanière est occupée par l'un des 2 joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="idPlateau"> Plateau de test </param>
        [Theory]
        [MemberData(nameof(DataTests.Data_TestDenOccupied), MemberType = typeof(DataTests))]
        public void TestDenOccupied(Player player1, Player player2, int idPlateau)
        {
            IVictoryManager victoryManager = new VictoryConditions();

            bool result = victoryManager.GameOver(player1, player2, new PlateauTest(player1, player2, idPlateau), ref player1);
            Assert.True(result);
        }

        /// <summary>
        /// Teste s'il n'y a plus d'animal présent chez chacun des 2 joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="idPlateau"> Plateau de test </param>
        /*
        [Theory]
        [MemberData(nameof(DataTests.Data_TestNoMoreAnimals), MemberType = typeof(DataTests))]
        public void TestNoMoreAnimals(Player player1, Player player2, int idPlateau)
        {
            IVictoryManager victoryManager = new VictoryConditions();

            bool result = victoryManager.GameOver(player1, player2, new PlateauTest(player1, player2, idPlateau));
            Assert.True(result);
        }
        */
    }
}
