using MyClassLibrary.Essentials;
using MyClassLibrary.Events;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary.Implementations
{
    /// <summary>
    /// Implémentation des méthodes annoncées dans l'interface IMoveManager
    /// Représente les règles/contraintes de déplacement pour chaque joueur et ses animaux
    /// </summary>
    public class MoveMaster : IMoveManager
    {
        /// <summary>
        /// Vérifie que le déplacement demandé est autorisé par les règles/contraintes du jeu
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur en cas d'échec du déplacement </param>
        /// <returns> True : Le déplacement est autorisé, False : Le déplacement est refusé </returns>
        public bool CheckMove(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Plateau board, ref string errorMessage)
        {
            // Cas : Départ hors du plateau
            if (!board.IsInBoard(rowStart, colStart))
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> La case de départ choisie est en dehors du plateau ! Réessayez...\n";
                return false;
            }

            // Cas : Arrivée hors du plateau
            if (!board.IsInBoard(rowDest, colDest))
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> La case destination choisie est en dehors du plateau ! Réessayez...\n";
                return false;
            }

            Case caseStart = board.Cases[rowStart - 1, colStart - 1];
            Case caseEnd = board.Cases[rowDest - 1, colDest - 1];

            // Cas : Aucun animal sélectionné 
            if (!caseStart.IsOccuped)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Aucun animal n'a été sélectionné ! Réessayez...\n";
                return false;
            }

            if(!board.IsAdjacentCase(rowStart, colStart, rowDest, colDest) && caseStart.Inhabitant!.Strength != 6 && caseStart.Inhabitant.Strength != 7)
            {
                errorMessage = "! Vous ne pouvez pas sauter de cases !";
                return false;
            }

            // Cas où la case demandée est occupée par l'animal d'un autre joueur
            if (caseStart.Inhabitant is not null && !caseStart.Inhabitant.PlayerOwner.Equals(currentPlayer))
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Il n'est pas autorisé de sélectionner un animal adverse ! Réessayez...\n";
                return false;
            }

            // Cas de déplacement sur un piège
            if (board.IsTrap(rowDest - 1, colDest - 1) && caseEnd.Inhabitant is not null && caseEnd.Habitant is not null && caseEnd.Habitant.Equals(currentPlayer) && !caseEnd.Inhabitant.PlayerOwner.Equals(currentPlayer))
            {
                return true;
            }

            // Cas 1: Déplacement en diagonale
            if (!board.IsAdjacentCase(rowStart, colStart, rowDest, colDest) && !caseStart.Inhabitant!.JumpRiver)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Seul les lions et les tigres sont capables de sauter au dessus de la rivière ! Réessayez...\n";
                return false;
            }

            // Cas 2 : Déplacement nul
            if (rowStart == rowDest && colStart == colDest)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Aucun déplacement n'a été effectué ! Réessayez...\n";
                return false;
            }

            // Cas : Occupation de la case arrivée par un allié
            if (caseEnd.IsOccuped && caseEnd.Inhabitant!.PlayerOwner.Equals(currentPlayer))
            {
                errorMessage = $"\n|  L'animal n'a pas pu se déplacer :\n└> La case destination est déjà occupée par l'un de vos animaux ! Réessayez...\n";
                return false;
            }

            // Cas 3 : Attaque d'un rat sur un éléphant
            if (caseEnd.Inhabitant is not null && caseStart.Inhabitant!.Strength == 1 && caseEnd.IsOccuped && caseEnd.Inhabitant.Strength == 8)
            {
                if (!board.IsRiver(rowStart - 1, colStart - 1))
                {
                    return true;
                }
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Le rat est incapable d'attaquer l'éléphant quand il se trouve dans une rivière ! Réessayez...\n";
                return false;
            }

            // Cas 4 : Attaque d'un éléphant sur un rat
            if (caseEnd.Inhabitant is not null && caseStart.Inhabitant!.Strength == 8 && caseEnd.IsOccuped && caseEnd.Inhabitant.Strength == 1)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> L'éléphant est trop effrayé à l'idée de s'en prendre à un rat ! Réessayez...\n";
                return false;
            }

            // Cas où la case demandée est occupée par un animal adverse plus puissant
            if (caseEnd.Inhabitant is not null && caseEnd.Inhabitant.Strength > caseStart.Inhabitant!.Strength)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> La case destination est déjà occupée par un animal plus puissant ! Réessayez...\n";
                return false;
            }

            // Cas : Déplacement dans les rivières d'un animal 
            if (board.IsRiver(rowDest - 1, colDest - 1) && !caseStart.Inhabitant!.WalkRiver)
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Seul les rats peuvent se déplacer sur une rivière ! Réessayez...\n";
                return false;
            }

            // Cas où un tigre ou un lion souhaite sauter une rivière 
            if (!board.IsAdjacentCase(rowStart, colStart, rowDest, colDest) && caseStart.Inhabitant!.JumpRiver)
            {
                if (board.IsNextRiver(rowStart - 1, colStart - 1))
                {
                    if (board.IsNextRiver(rowDest - 1, colDest - 1))
                    {
                        if (!board.IsDiagonalDeplacementOnRiver(rowStart, colStart, rowDest, colDest))
                        {
                            if (!board.IsRatOnPath(rowStart, colStart, rowDest, colDest))
                            {
                                return true;
                            }
                            else
                            {
                                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Impossible de traverser la rivière tant qu'un rat se trouve sur votre trajectoire ! Réessayez...\n";
                                return false;
                            }
                        }
                        else
                        {
                            errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Impossible de traverser la rivière en diagonale ! Réessayez...\n";
                            return false;
                        }
                    }
                    else
                    {
                        errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Pour sauter à travers la rivière, l'animal doit attérir sur une case adjacente à celle-ci ! Réessayez...\n";
                        return false;
                    }
                }
                else
                {
                    errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Pour sauter à travers la rivière, l'animal doit se situer sur une case adjacente à celle-ci ! Réessayez...\n";
                    return false;
                }
            }

            // 9) Cas où la case demandée est la tanière du joueur courant
            if (board.IsDen(rowDest - 1, colDest - 1) && caseEnd.Habitant!.Equals(currentPlayer))
            {
                errorMessage = "\n|  L'animal n'a pas pu se déplacer :\n└> Il est interdit d'occuper sa propre tanière ! Réessayez...\n";
                return false;
            }
            return true;
     
        }

        /// <summary>
        /// Effectue le déplacement d'un animal sur le plateau de tests
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur en cas d'échec du déplacement </param>
        /// <returns> True : Le déplacement réussie, False : Le déplacement échoue </returns>
        public bool MoveAnimal(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Player waitingPlayer, Plateau board)
        {
            string errorMessage = "";
            bool resMove = CheckMove(rowStart, colStart, rowDest, colDest, currentPlayer, board, ref errorMessage);

            if (resMove)
            {
                Case caseStart = board.Cases[rowStart - 1, colStart - 1];
                Case caseEnd = board.Cases[rowDest - 1, colDest - 1];

                if(caseEnd.IsOccuped)
                {
                    int strength = caseStart.Inhabitant!.Strength; 
                    OnFighted(strength);
                    waitingPlayer.Animals.RemoveAt(0);
                }

                board.ChangeCases(rowStart - 1, colStart - 1, rowDest - 1, colDest - 1);
                OnMoved(rowDest, colDest);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Événement déclenché lorsqu'un combat a lieu entre deux animaux.
        /// </summary>
        public event EventHandler<FightedEventArgs>? Fighted;

        /// <summary>
        /// Déclenche l'événement Fighted.
        /// </summary>
        /// <param name="animalStrength">La force de l'animal impliqué dans le combat.</param>
        protected virtual void OnFighted(int animalStrength)
            => Fighted?.Invoke(this, new FightedEventArgs(animalStrength));

        /// <summary>
        /// Événement déclenché lorsqu'un animal est déplacé sur le plateau.
        /// </summary>
        public event EventHandler<MovedEventArgs>? Moved;

        /// <summary>
        /// Déclenche l'événement Moved.
        /// </summary>
        /// <param name="x">La coordonnée X du déplacement de l'animal.</param>
        /// <param name="y">La coordonnée Y du déplacement de l'animal.</param>
        protected virtual void OnMoved(int x, int y)
            => Moved?.Invoke(this, new MovedEventArgs(x, y));

    }
}
