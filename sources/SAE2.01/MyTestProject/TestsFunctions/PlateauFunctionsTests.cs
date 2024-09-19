using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Exceptions;
using MyClassLibrary.Essentials;

namespace MyTestProject.TestsFunctions
{
    /// <summary>
    /// Classe de tests sur les cases du Plateau
    /// </summary>
    public class PlateauFunctionsTests
    {
        /// <summary>
        /// Teste si la case sélectionnée est une case Rivière
        /// </summary>
        /// <param name="row"> Coordonnée 'x' de la case </param>
        /// <param name="col"> Coordonnée 'y' de la case </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(3, 4, false)]
        [InlineData(4, 6, true)]
        [InlineData(4, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(5, 6, true)]
        [InlineData(6, 5, true)]
        [InlineData(6, 6, true)]
        [InlineData(2, 4, false)]
        [InlineData(5, 4, false)]
        [InlineData(4, 2, true)]
        [InlineData(4, 3, true)]
        [InlineData(5, 2, true)]
        [InlineData(5, 3, true)]
        [InlineData(6, 2, true)]
        [InlineData(6, 3, true)]
        [InlineData(6, 4, false)]
        [InlineData(7, 3, false)]
        [InlineData(9, 7, false)]
        public void TestIsRiver(int row, int col, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));
            bool result = board.IsRiver(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si la case sélectionnée est une case Piège
        /// </summary>
        /// <param name="row"> Coordonnée 'x' de la case </param>
        /// <param name="col"> Coordonnée 'y' de la case </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 3, true)]
        [InlineData(1, 4, false)]
        [InlineData(1, 5, true)]
        [InlineData(2, 4, true)]
        [InlineData(4, 2, false)]
        [InlineData(9, 3, true)]
        [InlineData(9, 5, true)]
        [InlineData(8, 4, true)]
        public void TestIsTrap(int row, int col, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));

            bool result = board.IsTrap(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si la case sélectionnée est une case Tanière
        /// </summary>
        /// <param name="row"> Coordonnée 'x' de la case </param>
        /// <param name="col"> Coordonnée 'y' de la case </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(1, 1, false)]
        [InlineData(1, 3, false)]
        [InlineData(1, 4, true)]
        [InlineData(4, 2, false)]
        [InlineData(9, 3, false)]
        [InlineData(9, 5, false)]
        [InlineData(9, 4, true)]
        public void TestIsDen(int row, int col, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));

            bool result = board.IsDen(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si la case sélectionnée est adjacente à une rivière
        /// </summary>
        /// <param name="row"> Coordonnée 'x' de la case </param>
        /// <param name="col"> Coordonnée 'y' de la case </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(1, 1, false)] // Coin en haut à gauche
        [InlineData(3, 1, false)]
        [InlineData(3, 2, true)]
        [InlineData(3, 3, true)]
        [InlineData(3, 4, false)]
        [InlineData(4, 4, true)]
        [InlineData(5, 4, true)]
        [InlineData(6, 4, true)]
        [InlineData(7, 1, false)]
        [InlineData(1, 4, false)]
        [InlineData(9, 4, false)]
        [InlineData(8, 2, false)]
        [InlineData(1, 7, false)] // Coin en haut à droite
        [InlineData(9, 7, false)]
        [InlineData(7, 7, false)]
        public void TestIsNextRiver(int row, int col, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));

            bool result = board.IsNextRiver(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(1, 1, 25, true)]
        [InlineData(1, 7, 25, true)]
        [InlineData(1, 3, 25, true)]
        [InlineData(1, 2, 25, false)]
        [InlineData(1, 6, 25, false)]
        [InlineData(1, 1, 26, true)]
        [InlineData(1, 7, 26, true)]
        [InlineData(1, 4, 26, false)]
        [InlineData(1, 3, 26, true)]
        [InlineData(1, 5, 26, true)]    

        public void TestIsRiverFirstLine(int row , int col, int idPlateau, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, idPlateau);

            bool result = board.IsRiverFirstLine(row - 1, col - 1);

            Assert.Equal(result, expectedResult);   
        }

        [Theory]
        [InlineData(9, 1, 25, true)]
        [InlineData(9, 7, 25, true)]
        [InlineData(9, 4, 25, true)]
        [InlineData(9, 2, 25, false)]
        [InlineData(9, 1, 26, true)]
        [InlineData(9, 7, 26, true)]
        public void TestIsRiverLastLine(int row, int col, int idPlateau, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, idPlateau);

            bool result = board.IsRiverLastLine(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(7, 1, true)]
        [InlineData(3, 1, true)]
        [InlineData(3, 7, true)]
        [InlineData(5, 1, false)]
        [InlineData(6, 7, false)]
        public void TestIsRiverTopOrBottom(int row, int col, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, 25);

            bool result = board.IsRiverTopOrBottom(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(2, 6, true)]
        [InlineData(8, 3, true)]
        [InlineData(3, 3, false)]
        [InlineData(7, 6, false)]
        public void TestIsRiverLeftOrRight(int row, int col, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, 25);

            bool result = board.IsRiverLeftOrRight(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(7, 4, true)]
        [InlineData(8, 6, true)]
        [InlineData(5, 4, true)]
        [InlineData(2, 3, false)]
        [InlineData(2, 5, false)]
        public void TestIsRiverAround(int row, int col, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, 25);

            bool result = board.IsRiverAround(row - 1, col - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si les 2 cases sélectionnées sont adjacentes entre elles
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(1, 1, 1, 2, true)]
        [InlineData(1, 1, 2, 2, false)]
        [InlineData(1, 1, 2, 1, true)]
        [InlineData(1, 1, 3, 1, false)]
        [InlineData(2, 2, 1, 2, true)]
        [InlineData(2, 2, 2, 1, true)]
        [InlineData(2, 2, 3, 2, true)]
        [InlineData(2, 2, 2, 3, true)]
        public void TestIsAdjacentCase(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));

            bool result = board.IsAdjacentCase(rowStart - 1, colStart - 1, rowDest - 1, colDest - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si le déplacement est sur une rivière et en diagonale
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(4, 1, 4, 4, false)]
        [InlineData(5, 1, 5, 4, false)]
        [InlineData(4, 1, 5, 4, true)]
        [InlineData(4, 4, 4, 7, false)]
        [InlineData(4, 4, 5, 7, true)]
        [InlineData(3, 2, 7, 2, false)]
        [InlineData(3, 2, 7, 3, true)]
        [InlineData(7, 2, 3, 3, true)]
        [InlineData(7, 5, 3, 6, true)]
        [InlineData(7, 6, 3, 5, true)]
        [InlineData(7, 6, 3, 6, false)]
        [InlineData(6, 7, 6, 4, false)]
        [InlineData(6, 4, 6, 1, false)]
        [InlineData(6, 4, 5, 7, true)]
        public void TestIsDiagonalDeplacementOnRiver(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));

            bool result = board.IsDiagonalDeplacementOnRiver(rowStart - 1, colStart - 1, rowDest - 1, colDest - 1);

            Assert.Equal(result, expectedResult);
        }

        /// <summary>
        /// Teste si, lors d'un déplacement (saut au dessus de la rivière), il y a un rat sur la trajectoire de saut
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <param name="expectedResult"> Résultat attendu </param>
        [Theory]
        [InlineData(7, 6, 3, 6, true)] //
        [InlineData(3, 6, 7, 6, true)] //
        [InlineData(5, 4, 5, 7, true)] //
        [InlineData(5, 7, 5, 4, true)] //
        [InlineData(3, 5, 7, 5, false)] //
        [InlineData(7, 5, 3, 5, false)] //
        [InlineData(6, 4, 6, 7, false)] //
        [InlineData(6, 7, 6, 4, false)] //
        [InlineData(4, 4, 4, 7, false)] //
        [InlineData(4, 7, 4, 4, false)] //

        public void TestIsRatOnPath(int rowStart, int colStart, int rowDest, int colDest, bool expectedResult)
        {
            Player player1 = new Player(1, "Tommy");
            Player player2 = new Player(2, "Cyprien");

            Plateau board = new PlateauTest(player1, player2, 17);

            bool result = board.IsRatOnPath(rowStart, colStart, rowDest, colDest);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1,1, true)]
        [InlineData(5, 5, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(7, 5, true)]
        [InlineData(9, 7, true)]
        [InlineData(9, 0, false)]
        [InlineData(9, 1, true)]
        [InlineData(10, 1, false)]
        [InlineData(9, 8, false)]
        [InlineData(0, 7, false)]
        [InlineData(1, 7, true)]
        [InlineData(1, 8, false)]
        public void TestIsInBoard(int x, int y, bool expected)
        {
            Plateau board = new Plateau(new Player(1, "Tommy"), new Player(2, "Cyprien"));
            bool result = board.IsInBoard(x,y);

            Assert.Equal(expected, result);
        }
    }

}
