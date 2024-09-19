using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MyClassLibrary.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.Data
{
    /// <summary>
    /// Fournit des données pour les tests unitaires
    /// </summary>
    public class DataTests
    {
        /// <summary>
        /// Fournit des données pour tester la méthode CheckMove
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestCheckMove()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");
            Player currentPlayer = player1;

            yield return new object[]
            {
                // 01 - rowStart < 1
                0, 1, 1, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 02 - rowEnd < 1
                1, 0, 1, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 03 - colStart < 1
                1, 1, 0, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 04 - colEnd < 1
                1, 1, 1, 0,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 05 - Coordonnées de la case < 0
                0, 0, 0, 0,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 06 - rowStart > 9
                10, 1, 1, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 07 - rowEnd > 9
                1, 10, 1, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 08 - colStart > 7
                1, 1, 8, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 09 - colEnd > 7
                1, 1, 1, 7,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {   // 10
                // Coordonnées x de la case > 9 
                // Coordonnées y de la case > 7 
                10, 10, 8, 8,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 11 - Case de départ vide
                1, 1, 1, 2,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 12 - Case d'arrivée occupée par un allié
                2, 1, 1, 1,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 13 - Case d'arrivée non occupée par un allié
                1, 1, 2, 1,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 14 - Case d'arrivée occupée par un ennemi (sur piège appartenant au joueur courant) 
                3, 4, 2, 4,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 15 - Cas d'une attaque de rat sur un éléphant (case de départ s'agissant d'une rivière) 
                6, 3, 6, 4,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 16 - Cas d'une attaque de rat sur un éléphant
                2, 4, 3, 4,
                true,
                player2,
                player1,
                currentPlayer
            };
            yield return new object[]
            {
                // 17 - Cas d'une attaque d'éléphant sur un rat
                6, 4, 6, 3,
                false,
                player2,
                player1,
                currentPlayer
            };
            yield return new object[]
            {
                // 18 - Cas d'une attaque sur un animal supérieur
                5, 4, 6, 4,
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                // 19 - Cas d'une attaque sur un animal inférieur
                6, 4, 5, 4,
                true,
                player2,
                player1,
                currentPlayer
            };
            yield return new object[]
            {
                // 20 - Case non adjacente à une rivière suite à un saut
                3, 6, 8, 6,
                false,
                player1,
                player2,
                currentPlayer
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode MoveAnimal
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestMoveAnimal()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");
            Player currentPlayer = player1;

            yield return new object[]
            {
                1, 1, 2, 1,
                true,
                player1,
                player2,
                currentPlayer,
            };
            yield return new object[]
            {
                1, 1, 1, 2,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                3, 1, 2, 1,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                3, 1, 3, 2,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 7, 2, 7,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 7, 1, 6,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 6, 3, 6,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 6, 2, 5,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 6, 1, 6,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 6, 2, 7,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 1, 3, 1, // Aucun animal sélectionné
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 8, 1, // Animal adverse sélectionné
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 0, 1, // Numéro de ligne = 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 1, 0, // Animal de colonne = 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 1, 1, // Déplacement nul
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 2, 2, // Déplacement en diagonale
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                2, 2, 3, 3, // Déplacement diagonale 2
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 3, 1, // Saut de ligne
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 1, 3, // Saut de colonne
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, -1, 1, // Numéro de ligne négatif
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 1, -1, // Numéro de colonne négatif
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                -1, 1, 1, 1, // Numéro de ligne négatif
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, -1, 1, 1, // Numéro de colonne négatif
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                -1, -1, -1, -1, // Toutes les coordonnées négatives
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                10, 7, 9, 7, // Numéro de ligne > 9
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 10, 9, 7, // Numéro de colonne > 7
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 7, 10, 7, // Numéro de ligne > 9
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 7, 8, 8, // Numéro de colonne > 7
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                15, 18, 88, 55, // Coordonnées largement en dehors du plateau
                false,
                player1,
                player2,
                currentPlayer
            };
            currentPlayer = player2;
            yield return new object[]
            {
                9, 7, 8, 7,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 7, 9, 6,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                7, 7, 8, 7,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                7, 7, 6, 7,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 8, 1,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 9, 2,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                8, 2, 9, 2,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                8, 2, 8, 3,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                8, 2, 7, 2,
                true,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 9, 1, // Déplacement nul
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 7, 1, // Saut de ligne
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 9, 3, // Saut de colonne
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 8, 2, // Déplacement diagonale
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, -4, 2, // Numéro de ligne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 9, -4, // Numéro de colonne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, -1, 8, 1, // Numéro de colonne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                8, 1, 7, 1, // Aucun animal sélectionné
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                1, 1, 2, 1, // Animal adverse sélectionné
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 8, 0, // Numéro de colonne == 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 9, 0, // Numéro de colonne == 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 10, 1, // Numéro de ligne > 9
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 1, 88, 4156, // Numéro de colonne bien au dessus de 7
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 7, 9, 8, // Numéro de colonne > 7
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                -9, 1, 2, 3, // Numéro de ligne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 8, -9, 1, // Numéro de ligne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                9, 8, 8, -1, // Numéro de colonne < 0
                false,
                player1,
                player2,
                currentPlayer
            };
            yield return new object[]
            {
                -9, -8, -8, -8, // Coordonnées négatives
                false,
                player1,
                player2,
                currentPlayer
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestTrap
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestCheckTrapMovement()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                1, 2, 1, 3,
                true,
                player1,
                player2,
                player1,
                player2,
                1
            };
            yield return new object[]
            {
                2, 5, 1, 5,
                true,
                player1,
                player2,
                player1,
                player2,
                1
            };
            yield return new object[]
            {
                7, 4, 8, 4,
                true,
                player1,
                player2,
                player1,
                player2,
                1
            };
            yield return new object[]
            {
                9, 3, 9, 2,
                true,
                player1,
                player2,
                player1,
                player2,
                1
            };
            yield return new object[]
            {
                9, 3, 8, 3,
                true,
                player1,
                player2,
                player1,
                player2,
                1
            };
            yield return new object[]
            {
                2, 3, 1, 3,
                true,
                player1,
                player2,
                player2,
                player1,
                1
            };
            yield return new object[]
            {
                2, 4, 3, 4,
                true,
                player1,
                player2,
                player2,
                player1,
                1
            };
            yield return new object[]
            {
                1, 5, 2, 5,
                true,
                player1,
                player2,
                player2,
                player1,
                1
            };
            yield return new object[]
            {
                8, 3, 9, 3,
                true,
                player1,
                player2,
                player2,
                player1,
                1
            };
            yield return new object[]
            {
                8, 3, 8, 4,
                true,
                player1,
                player2,
                player2,
                player1,
                1
            };
            yield return new object[]
            {
                1, 3, 2, 3,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                1, 3, 0, 3,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                6, 4, 7, 4,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                1, 3, 2, 4,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                1, 3, 2, 2,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                1, 3, 1, 0,
                false,
                player1,
                player2,
                player1,
                player2,
                2
            };
            yield return new object[]
            {
                1, 3, 2, 3,
                false,
                player1,
                player2,
                player2,
                player1,
                2
            };
            yield return new object[]
            {
                9, 3, 8, 3,
                false,
                player1,
                player2,
                player2,
                player1,
                2
            };
            yield return new object[]
            {
                2, 5, 1, 5,
                false,
                player1,
                player2,
                player2,
                player1,
                2
            };
            yield return new object[]
            {
                9, 5, 10, 5,
                false,
                player1,
                player2,
                player2,
                player1,
                2
            };
            yield return new object[]
            {
                9, 5, 9, 8,
                false,
                player1,
                player2,
                player2,
                player1,
                2
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestDen
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestCheckDenMovement()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                1, 3, 1, 4,
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                1, 5, 1, 4,
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                2, 4, 1, 4,
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                3, 4, 1, 4,
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                9, 3, 9, 4,
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                9, 5, 9, 4,
                false,
                player1,
                player2,
                player2,
                player1
            };
            yield return new object[]
            {
                8, 4, 9, 4,
                false,
                player1,
                player2,
                player2,
                player1
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestRiver
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestCheckRiverMovement()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                4, 1, 4, 4, // Animal qui saute la rivière en horizontal
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                5, 1, 5, 4, // Animal qui saute la rivière en horizontal
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 4, 6, 3, // Rat qui rentre dans l'eau
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 2, 6, 3, // Rat dans l'eau qui se déplace vers la droite
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 2, 7, 2, // Rat qui sort de l'eau en se déplacant vers le bas
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 2, 6, 1, // Rat qui sort de l'eau par la gauche
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                3, 3, 7, 3, // Animal qui saute la rivière en vertical
                true,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 4, 6, 1, // Rat qui essaye de sauter une rivière
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 4, 7, 5, // Rat qui essaye de marcher sur une rivière en diagonal
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 1, 4, 2, // Lion qui essaye de marcher sur une rivière 
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 7, 4, 6, // Elephant qui essaye de marcher sur une rivière
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 7, 4, 4, // Elephant qui essaye de sauter une rivière
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                5, 7, 5, 4, // Lion qui essaye de sauter une rivière avec un rat allié sur la trajectoire (horizontal)
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 7, 6, 4, // Lion qui essaye de sauter une rivière avec un rat ennemi sur la trajectoire (horizontal)
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                6, 4, 4, 4, // Rat qui essaye de sauter des cases dans l'eau
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                5, 1, 4, 4, // Tigre qui essaye de sauter une rivière en diagonale
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 1, 5, 4, // Lion qui essaye de sauter une rivière en diagonale
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 5, 3, 5, // Rat qui essaye de tuer un éléphant en sortant d'une rivière
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                4, 5, 10, 5, // Rat dans l'eau qui essaye de sortir du plateau
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                3, 5, 4, 5, // Elephant qui essaye d'attaquer un rat qui se trouve dans l'eau
                false,
                player1,
                player2,
                player1,
                player2
            };
            yield return new object[]
            {
                8, 5, 8, 7, // Le lion essaye de sauter la rivi�re et veut r�atterir sur un éléphant ==> IMPOSSIBLE
                false,
                player1,
                player2,
                player1,
                player2
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestDenOccupied
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestDenOccupied()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                player1,
                player2,
                13, 
            };
            yield return new object[]
            {
                player1,
                player2,
                14,
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestNoMoreAnimals
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestNoMoreAnimals()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                player1,
                player2,
                15
            };
            yield return new object[]
            {
                player1,
                player2,
                16
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestCurrentPlayerChanged
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestCurrentPlayer()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                player1,
                player2,
                player1,
                player2
            };

            yield return new object[]
            {
                player2,
                player1,
                player2,
                player1
            };
            yield return new object[]
            {
                player1,
                player2,
                player2,
                player1
            };
            yield return new object[]
            {
                player2,
                player1,
                player1,
                player2
            };
        }

        /// <summary>
        /// Fournit des données pour tester la méthode TestGameOver
        /// </summary>
        /// <returns> Enumérable d'objets contenant les données de test </returns>
        public static IEnumerable<object[]> Data_TestGameOver()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            yield return new object[]
            {
                player1,
                player2,
                new PlateauTest(player1, player2, 19),
                true
            };

            yield return new object[]
            {
                player1,
                player2,
                new PlateauTest(player1, player2, 20),
                true
            };

            yield return new object[]
            {
                player1,
                player2,
                new PlateauTest(player1, player2, 21),
                false
            };

            yield return new object[]
            {
                player1,
                player2,
                new PlateauTest(player1, player2, 22),
                true
            };

            yield return new object[]
            {
                player1,
                player2,
                new PlateauTest(player1, player2, 23),
                true
            };
        }

        public static IEnumerable<object[]> Data_TestPlayersEquals()
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");
            Player player3 = new Player(2, "Cyprien");
            Player player4 = new Player(1, "Tommy");

            yield return new object[]
            {
                player1,
                player4,
                true
            };
            yield return new object[]
            {
                player1,
                player2,
                false
            };
            yield return new object[]
            {
                player1,
                player3,
                false
            };
            yield return new object[]
            {
                player2,
                player4,
                false
            };
            yield return new object[]
            {
                player2,
                player3,
                true
            };
            yield return new object[]
            {
                player3,
                player2,
                true
            };
            yield return new object[]
            {
                player1,
                player1,
                true
            };
            yield return new object[]
            {
                player3,
                player3,
                true
            };
            yield return new object[]
            {
                player1,
                (Player)null,
                false
            };
            yield return new object[]
            {
                player1,
                new NotAPlayer(),
                false
            };
            yield return new object[]
            {
                player1,
                new Player(1, "Tommy"),
                true
            };
            yield return new object[]
            {
                player1,
                new Player(5, "Hugo"),
                false
            };
        }
    }

    /// <summary>
    /// Classe créée à des fins de tests
    /// </summary>
    public class NotAPlayer
    {
    }
}
