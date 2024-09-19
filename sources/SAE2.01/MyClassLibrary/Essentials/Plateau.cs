using MyClassLibrary.Enum;
using MyClassLibrary.Events;
using MyClassLibrary.Exceptions;

namespace MyClassLibrary.Essentials
{

    /// <summary>
    /// Représente le plateau du jeu
    /// </summary>
    public class Plateau
    {
        /// <summary>
        /// Événement déclenché lorsqu'une case change
        /// </summary>
        public event EventHandler<CaseChangedEventArgs>? CaseChanged;

        /// <summary>
        /// Déclenche l'événement <see cref="CaseChanged"/>
        /// </summary>
        /// <param name="x"> La coordonnée 'x' de la case d'origine </param>
        /// <param name="y"> La coordonnée 'y' de la case d'origine </param>
        /// <param name="xDest"> La coordonnée 'x' de la case de destination </param>
        /// <param name="yDest"> La coordonnée 'y' de la case de destination </param>
        protected virtual void OnCaseChanged(int x, int y, int xDest, int yDest)
            => CaseChanged?.Invoke(this, new CaseChangedEventArgs(x, y, xDest, yDest));

        /// <summary>
        /// Change les occupants des cases spécifiées et déclenche l'événement <see cref="OnCaseChanged"/>
        /// </summary>
        /// <param name="x"> La coordonnée 'x' de la case d'origine </param>
        /// <param name="y"> La coordonnée 'y' de la case d'origine </param>
        /// <param name="xDest"> La coordonnée 'x' de la case de destination </param>
        /// <param name="yDest"> La coordonnée 'y' de la case de destination </param>
        public void ChangeCases(int x, int y, int xDest, int yDest)
        {
            Cases[xDest, yDest].Inhabitant = Cases[x, y].Inhabitant;
            Cases[xDest, yDest].IsOccuped = true;

            Cases[x, y].IsOccuped = false;

            OnCaseChanged(x, y, xDest, yDest);
        }

        /// <summary>
        /// Obtient les cases du plateau dans un tableau bidimensionnelle
        /// </summary>
        public Case[,] Cases { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de Plateau avec les 2 joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        public Plateau(Player player1, Player player2)
        {
            Cases = new Case[9, 7] {
                { new Case(Ground.GROUND, true, new Animal(player1, 7,true, false), 1), new Case(Ground.GROUND, false, 2), new Case(Ground.TRAP, false, player1, "#7a2c2c", 3), new Case(Ground.DEN, false, player1, "Yellow", 4), new Case(Ground.TRAP, false, player1, "#7a2c2c", 5), new Case(Ground.GROUND, false, 6), new Case(Ground.GROUND, true, new Animal(player1, 6,true, false), 7) },
                { new Case(Ground.GROUND, false, 8), new Case(Ground.GROUND, true, new Animal(player1, 4,false, false), 9), new Case(Ground.GROUND, false, 10), new Case(Ground.TRAP, false, player1, "#7a2c2c", 11), new Case(Ground.GROUND, false, 12), new Case(Ground.GROUND, true, new Animal(player1, 2,false, false), 13), new Case(Ground.GROUND, false, 14) },
                { new Case(Ground.GROUND, true, new Animal(player1, 1,false, true), player1, 15), new Case(Ground.GROUND, false, 16), new Case(Ground.GROUND, true, new Animal(player1, 5,false, false), player1, 17), new Case(Ground.GROUND, false, 18), new Case(Ground.GROUND, true, new Animal(player1, 3,false, false), player1, 19), new Case(Ground.GROUND, false, 20), new Case(Ground.GROUND, true, new Animal(player1, 8,false, false), player1, 21) },
                { new Case(Ground.GROUND, false, 22), new Case(Ground.RIVER, false, "#1061bb", 23), new Case(Ground.RIVER, false, "#1061bb", 24), new Case(Ground.GROUND, false, 25), new Case(Ground.RIVER, false, "#1061bb", 26), new Case(Ground.RIVER, false, "#1061bb", 27), new Case(Ground.GROUND, false, 28) },
                { new Case(Ground.GROUND, false, 29), new Case(Ground.RIVER, false, "#1061bb", 30), new Case(Ground.RIVER, false, "#1061bb", 31), new Case(Ground.GROUND, false, 32), new Case(Ground.RIVER, false, "#1061bb", 33), new Case(Ground.RIVER, false, "#1061bb", 34), new Case(Ground.GROUND, false, 35) },
                { new Case(Ground.GROUND, false, 36), new Case(Ground.RIVER, false, "#1061bb", 37), new Case(Ground.RIVER, false, "#1061bb", 38), new Case(Ground.GROUND, false, 39), new Case(Ground.RIVER, false, "#1061bb", 40), new Case(Ground.RIVER, false, "#1061bb", 41), new Case(Ground.GROUND, false, 42) },
                { new Case(Ground.GROUND, true, new Animal(player2, 8,false, false), 43), new Case(Ground.GROUND, false, 44), new Case(Ground.GROUND, true, new Animal(player2, 3,false, false), 45), new Case(Ground.GROUND, false, 46), new Case(Ground.GROUND, true, new Animal(player2, 5,false, false), 47), new Case(Ground.GROUND, false, 48), new Case(Ground.GROUND, true, new Animal(player2, 1,false, true), 49) },
                { new Case(Ground.GROUND, false, 50), new Case(Ground.GROUND, true, new Animal(player2, 2,false, false), 51), new Case(Ground.GROUND, false, 52), new Case(Ground.TRAP, false, player2, "#7a2c2c", 53), new Case(Ground.GROUND, false, 54), new Case(Ground.GROUND, true, new Animal(player2, 4,false, false), 55), new Case(Ground.GROUND, false, 56) },
                { new Case(Ground.GROUND, true, new Animal(player2, 6,true, false), 57), new Case(Ground.GROUND, false, 58), new Case(Ground.TRAP, false, player2, "#7a2c2c", 59), new Case(Ground.DEN, false, player2, "Yellow", 60), new Case(Ground.TRAP, false, player2, "#7a2c2c", 61), new Case(Ground.GROUND, false, 62), new Case(Ground.GROUND, true, new Animal(player2, 7,true, false), 63) }
            };
        }

        /// <summary>
        /// Ajoute un animal sur une case du plateau
        /// </summary>
        /// <param name="x"> Coordonnée 'x' </param>
        /// <param name="y"> Coordonnée 'y' </param>
        /// <param name="a"> Nom de l'animal </param>
        /// <returns> True : L'ajout est effectué, False : L'ajout est refusé </returns>
        protected bool AddAnimal(int x, int y, Animal a)
        {
            if (!Cases[x - 1, y - 1].IsOccuped)
            {
                Cases[x - 1, y - 1].IsOccuped = true;
                Cases[x - 1, y - 1].Inhabitant = a;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retire tous les animaux des cases du plateau
        /// </summary>
        protected void RemoveAllAnimals()
        {
            for (int row = 0; row < Cases.GetLength(0); row++)
            {
                for (int column = 0; column < Cases.GetLength(1); column++)
                {
                    if (Cases[row, column].IsOccuped)
                    {
                        Cases[row, column].Inhabitant = null;
                        Cases[row, column].IsOccuped = false;
                    }
                }
            }
        }

        protected bool AddRiver(int x, int y)
        {
            if (Cases[x - 1, y - 1].GroundType != Ground.RIVER)
            {
                Cases[x - 1, y - 1].GroundType = Ground.RIVER;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Lance une exception si les coordonnées rentrées sont en dehors des limites du plateau.
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau, doit être compris entre 1 et 9</param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau, doit être compris entre 1 et 7</param>
        /// <exception cref="CoordinatesOutOfRangeException"></exception>
        private void ThrowIfOutOfBoard(int x, int y)
        {
            if (x < 0 || y < 0 || x > Cases.GetLength(0) || y > Cases.GetLength(1))
            {
                throw new CoordinatesOutOfRangeException($"The coordinates are invalid | x : {x} , y : {y}", x, y);
            }
        }

        /// <summary>
        /// Renvoie si la case sélectionnée est adjacente à une rivière en testant si au moins l'une des cases autour en est une
        /// en faisant attention aux cas spéciaux pour éviter les exceptions (coins de plateau, bords de plateau, etc ...)
        /// <see cref="IsRiver(int, int)"/> <see cref="IsRiverFirstLine(int, int)"/> <see cref="IsRiverLastLine(int, int)"/>
        /// <see cref="IsRiverTopOrBottom(int, int)"/> <see cref="IsRiverLeftOrRight(int, int)"/> <see cref="IsRiverAround(int, int)"/>
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsNextRiver(int x, int y)
        {
            ThrowIfOutOfBoard(x, y);

            if (x == 0) // Première ligne en haut
            {
                return IsRiverFirstLine(x, y);
            }
            else if (x == 8) // Dernière ligne en bas
            {
                return IsRiverLastLine(x, y);
            }
            else if (y == 6) // Dernière colonne à droite
            {
                // On teste les cases en bas, en haut et à gauche
                return IsRiver(x, y - 1) || IsRiverTopOrBottom(x, y);
            }
            else if (y == 0) // Première colonne à gauche
            {
                // On teste les cases en bas, en haut et à droite
                return IsRiver(x, y + 1) || IsRiverTopOrBottom(x, y);
            }
            // Cases non en bordure de plateau
            return IsRiverAround(x, y);
        }

        /// <summary>
        /// Récupère l'information que la case se situe sur la première ligne du plateau <see cref="IsNextRiver(int, int)"/>
        /// et renvoie si l'une des cases adjacentes est une rivière selon la coordonnée 'y'
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsRiverFirstLine(int x, int y)
        {
            if (y == 0) // Coin en haut à gauche
            {
                // On teste les cases en bas et à droite
                return IsRiver(x, y + 1) || IsRiver(x + 1, y);
            }
            else if (y == 6) // Coin en haut à droite
            {
                // On teste les cases en haut et à droite
                return IsRiver(x + 1, y) || IsRiver(x, y - 1);
            }
            // On teste les cases à gauche, à droite et en bas
            return IsRiver(x + 1, y) || IsRiverLeftOrRight(x, y);
        }

        /// <summary>
        /// Récupère l'information que la case se situe sur la dernière ligne du plateau <see cref="IsNextRiver(int, int)"/>
        /// et renvoie si l'une des cases adjacentes est une rivière selon la coordonnée 'y'
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsRiverLastLine(int x, int y)
        {
            if (y == 0) // Coin en bas à gauche
            {
                // On teste les cases en haut et à gauche
                return IsRiver(x - 1, y) || IsRiver(x, y + 1);
            }
            if (y == 6) // Coin en bas à droite
            {
                // On teste les cases en haut et à gauche
                return IsRiver(x - 1, y) || IsRiver(x, y - 1);
            }
            // On teste les cases à gauche, à droite et en haut
            return IsRiver(x - 1, y) || IsRiverLeftOrRight(x, y);
        }

        /// <summary>
        /// Renvoie si la case du haut ou du bas est une rivière
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsRiverTopOrBottom(int x, int y)
        {
            return IsRiver(x + 1, y) || IsRiver(x - 1, y);
        }

        /// <summary>
        /// Renvoie si la case de gauche ou de droite est une rivière
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsRiverLeftOrRight(int x, int y)
        {
            return IsRiver(x, y - 1) || IsRiver(x, y + 1);
        }

        /// <summary>
        /// Renvoie si les cases autour de la case est une rivière
        /// </summary>
        /// <param name="x"> Coordonnée 'x' d'une case du plateau </param>
        /// <param name="y"> Coordonnée 'y' d'une case du plateau </param>
        /// <returns> True : La case est adjacente à une rivière, False : La case n'est pas adjacente à une rivière </returns>
        public bool IsRiverAround(int x, int y)
        {
            return IsRiver(x + 1, y) || IsRiver(x - 1, y) || IsRiver(x, y + 1) || IsRiver(x, y - 1);
        }

        /// <summary>
        /// Renvoie si la case sélectionnée est une rivière
        /// </summary>
        /// <param name="x"> Coordonnée 'x' </param>
        /// <param name="y"> Coordonnée 'y' </param>
        /// <returns> True : La case est une rivière, False : La case n'est pas une rivière </returns>
        public bool IsRiver(int x, int y)
        {
            ThrowIfOutOfBoard(x, y);
            // Vérification du type Rivière de la case[x, y]
            return Cases[x, y].GroundType == Ground.RIVER;
        }

        /// <summary>
        /// Renvoie si la case sélectionnée est un piège
        /// </summary>
        /// <param name="x"> Coordonnée 'x' </param>
        /// <param name="y"> Coordonnée 'y' </param>
        /// <returns> True : La case est un piège, False : La case n'est pas un piège </returns>
        public bool IsTrap(int x, int y)
        {
            ThrowIfOutOfBoard(x, y);

            return Cases[x, y].GroundType == Ground.TRAP;
        }

        /// <summary>
        /// Renvoie si la case sélectionnée est une tanière
        /// </summary>
        /// <param name="x"> Coordonnée 'x' </param>
        /// <param name="y"> Coordonnée 'y' </param>
        /// <returns> True : La case est une tanière, False : La case n'est pas une tanière </returns>
        public bool IsDen(int x, int y)
        {
            ThrowIfOutOfBoard(x, y);

            return Cases[x, y].GroundType == Ground.DEN;
        }

        /// <summary>
        /// Renvoie si les cases sélectionnées sont adjacentes
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <returns> True : Les cases sont adjacentes, False : Les cases ne sont pas adjacentes </returns>
        public bool IsAdjacentCase(int rowStart, int colStart, int rowDest, int colDest)
        {
            ThrowIfOutOfBoard(rowStart, colStart);

            ThrowIfOutOfBoard(rowDest, colDest);

            if ((Math.Abs(rowStart - rowDest) >= 1 && Math.Abs(colStart - colDest) >= 1) || Math.Abs(rowStart - rowDest) > 1 || Math.Abs(colStart - colDest) > 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Renvoie si le déplacement sur une rivière est diagonale
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <returns> True : Le déplacement est diagonale, False : Le déplacement n'est pas diagonale </returns>
        public bool IsDiagonalDeplacementOnRiver(int rowStart, int colStart, int rowDest, int colDest)
        {
            ThrowIfOutOfBoard(rowStart, colStart);

            ThrowIfOutOfBoard(rowDest, colDest);

            int diff1 = Math.Abs(rowStart - rowDest);
            int diff2 = Math.Abs(colStart - colDest);

            if (diff1 != 0 && diff2 != 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Permet de déterminer si une case est dans le plateau
        /// </summary>
        /// <param name="row"> Coordonnée en 'x' de la case à tester</param>
        /// <param name="col"> Coordonnée en 'y' de la case à tester</param>
        /// <returns> True : La case est dans le plateau, False : La case n'est pas dans le plateau</returns>
        public bool IsInBoard(int row, int col)
        {
            if(row > 9 || col > 7 || row < 1 || col < 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Renvoie s'il y a un rat sur la trajectoire de saut
        /// Renvoie s'il y a un rat sur la trajectoire de saut 
        /// <see cref="ThrowIfOutOfBoard(int, int)"/> Exception lancée si les coordonnées entrées sont en dehors du plateau
        /// </summary>
        /// <param name="rowStart"> Coordonnée 'x' de la case de départ </param>
        /// <param name="colStart"> Coordonnée 'y' de la case de départ </param>
        /// <param name="rowDest"> Coordonnée 'x' de la case d'arrivée </param>
        /// <param name="colDest"> Coordonnée 'y' de la case d'arrivée </param>
        /// <si
        /// <returns> True : Un rat se situe sur la trajectoire, False : Aucun rat ne se situe sur la trajectoire </returns>
        public bool IsRatOnPath(int rowStart, int colStart, int rowDest, int colDest)
        {
            ThrowIfOutOfBoard(rowStart, colStart);
            ThrowIfOutOfBoard(rowDest, colDest);

            if (rowStart == rowDest)
            {
                return IsRatOnHorizontalPath(rowStart, colStart, colDest);
            }
            else if (colStart == colDest)
            {
                return IsRatOnVerticalPath(rowStart, colStart, rowDest);
            }

            return false;
        }

        /// <summary>
        /// Détermine s'il y a un rat sur le chemin horizontal entre deux colonnes spécifiées
        /// </summary>
        /// <param name="row"> Rangée du chemin </param>
        /// <param name="colStart"> Colonne de départ du chemin </param>
        /// <param name="colEnd"> Colonne de fin du chemin </param>
        /// <returns> Booléen indiquant si une case occupée est trouvée sur le chemin </returns>
        public bool IsRatOnHorizontalPath(int row, int colStart, int colEnd)
        {
            // Détermine la direction du déplacement horizontal (vers la droite ou la gauche)
            int step = colEnd > colStart ? 1 : -1;
            // Parcourt les colonnes entre colStart et colEnd (non inclus)
            for (int col = colStart + step; col != colEnd; col += step)
            {
                // Vérifie si la case actuelle est occupée
                if (Cases[row - 1, col - 1].IsOccuped)
                {
                    // Retourne true si une case occupée est trouvée sur le chemin
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Détermine s'il y a un rat sur le chemin vertical entre deux rangées spécifiées
        /// </summary>
        /// <param name="rowStart"> Rangée de départ du chemin </param>
        /// <param name="col"> Colonne du chemin </param>
        /// <param name="rowEnd"> Rangée de fin du chemin </param>
        /// <returns> Booléen indiquant si une case occupée est trouvée sur le chemin </returns>
        public bool IsRatOnVerticalPath(int rowStart, int col, int rowEnd)
        {
            // Détermine la direction du déplacement vertical (vers le bas ou le haut)
            int step = rowEnd > rowStart ? 1 : -1;
            // Parcourt les rangées entre rowStart et rowEnd (non inclus)
            for (int row = rowStart + step; row != rowEnd; row += step)
            {
                // Vérifie si la case actuelle est occupée
                if (Cases[row - 1, col - 1].IsOccuped)
                {
                    // Retourne true si une case occupée est trouvée sur le chemin
                    return true;
                }
            }
            return false;
        }
    }
}
