using MyClassLibrary.Interfaces;
using MyClassLibrary.Events;
using MyClassLibrary.Essentials;
using System.ComponentModel;

namespace MyClassLibrary.Implementations
{
    /// <summary>
    /// Implémentation des méthodes annoncées dans l'interface IGameManager
    /// Représente le maître du jeu qui gère le déroulement du jeu
    /// </summary>
    public class GameMaster : IGameManager , INotifyPropertyChanged
    {
        /// <summary>
        /// Représente les règles/contraintes de déplacement
        /// </summary>
        public IMoveManager MoveManager { get; }

        /// <summary>
        /// Représente les règles/conditions de victoire
        /// </summary>
        private IVictoryManager VictoryManager { get; }

        /// <summary>
        /// Initialise le joueur 1 de la partie
        /// </summary>
        public Player Player1
        {
            get; private set;
        }

        /// <summary>
        /// Initialise le joueur 2 de la partie
        /// </summary>
        public Player Player2
        {
            get; private set;
        }

        /// <summary>
        /// Initialise le joueur courant de la partie
        /// </summary>
        public Player CurrentPlayer
        {
            get => currentPlayer; 
            private set
            {
                if (value == null) return;
                if (value == currentPlayer) return;

                currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        /// <summary>
        /// Récupère le joueur courant de la partie
        /// </summary>
        private Player currentPlayer;

        /// <summary>
        /// Initialise le plateau de jeu sur lequel se déroulera la partie
        /// </summary>
        public Plateau Board
        {
            get; private set;
        }

        /// <summary>
        /// Initialise une partie avec des valeurs par défaut
        /// </summary>
        public GameMaster()
        {
            MoveManager = new MoveMaster();
            VictoryManager = new VictoryConditions();
            Player1 = new Player(0, "player1");
            Player2 = new Player(0, "player2");
            CurrentPlayer = Player1;
            Board = new Plateau(Player1, Player2);
        }

        /// <summary>
        /// Initialise une partie avec des joueurs
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="currentPlayer"> Joueur courrant </param>
        public GameMaster(Player player1, Player player2, Player currentPlayer)
        {
            MoveManager = new MoveMaster();
            VictoryManager = new VictoryConditions();
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = currentPlayer;
            Board = new Plateau(Player1, Player2);
        }

        /// <summary>
        /// Crée une nouvelle partie avec les noms des joueurs
        /// </summary>
        /// <param name="namePlayer1"></param>
        /// <param name="namePlayer2"></param>
        public void CreateGame(string namePlayer1, string namePlayer2)
        {

            Player1 = new Player(1, namePlayer1);
            Player2 = new Player(2, namePlayer2);

            Random rdm = new Random();

            int res = rdm.Next(2);

            if (res == 0)
            {
                CurrentPlayer = Player1;
            }
            else
            {
                CurrentPlayer = Player2;
            }

            Board = new Plateau(Player1, Player2);
        }

        /// <summary>
        /// Change le joueur courant pour le joueur suivant en comparant le joueur courant et les 2 joueurs
        /// </summary>
        public void ChangeCurrentPlayer()
        {
            if (CurrentPlayer.Equals(Player1))
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
            OnCurrentPlayerChanged(CurrentPlayer, Player1, Player2);
        }

        /// <summary>
        /// Obtient le joueur en attente
        /// </summary>
        /// <returns>Le joueur en attente</returns>
        public Player GetWaitingPlayer()
        {
            if (CurrentPlayer.Equals(Player1)) return Player2;
            return Player1;
        }

        /// <summary>
        /// Sélectionne les noms des joueurs avec la fonctionnalité <see cref="OnValueSelecting"/>
        /// de saisie controllée <see cref="OnPlayersSelectFailed"/> en passant par une entrée de l'utilisateur
        /// </summary>
        /// <param name="namePlayer1"> Nom du joueur 1 </param>
        /// <param name="namePlayer2"> Nom du joueur 2 </param>
        public void SelectPlayer(ref string namePlayer1, ref string namePlayer2)
        {
            string fillName = "";
            while (namePlayer1.Length < 3 || namePlayer1.Length > 7 || string.IsNullOrWhiteSpace(namePlayer1))
            {
                OnValueSelecting("Entrez le nom du joueur 1 : ");
                namePlayer1 = Console.ReadLine() ?? "Player1";
                while (namePlayer1.Length < 3 || namePlayer1.Length > 7 || string.IsNullOrWhiteSpace(namePlayer1))
                {
                    OnPlayersSelectFailed("Le nom doit être compris entre 3 et 7 caractères !");
                    OnValueSelecting("Entrez le nom du joueur 1 : ");
                    namePlayer1 = Console.ReadLine() ?? "Player1";
                }
                fillName = namePlayer1;
                while (fillName.Length != 7)
                {
                    fillName = fillName + " ";
                }
                namePlayer1 = fillName;
            }

            while (namePlayer2.Length < 3 || namePlayer2.Length > 7 || string.IsNullOrWhiteSpace(namePlayer2))
            {
                OnValueSelecting("Entrez le nom du joueur 2 : ");
                namePlayer2 = Console.ReadLine() ?? "Player2";
                while (namePlayer2.Length < 3 || namePlayer2.Length > 7 || string.IsNullOrWhiteSpace(namePlayer2))
                {
                    OnPlayersSelectFailed("Le nom doit être compris entre 3 et 7 caractères !");
                    OnValueSelecting("Entrez le nom du joueur 2 : ");
                    namePlayer2 = Console.ReadLine() ?? "Player2";
                }
                fillName = namePlayer2;
                while (fillName.Length != 7)
                {                  
                    fillName = fillName + " ";
                }
                namePlayer2 = fillName;
            }
        }

        /// <summary>
        /// Vérifie si les noms des joueurs sont valides
        /// </summary>
        /// <param name="namePlayer1">Le nom du joueur 1.</param>
        /// <param name="namePlayer2">Le nom du joueur 2.</param>
        /// <param name="errorMessage">Message d'erreur en cas de nom invalide.</param>
        /// <returns>True si les noms sont valides, sinon False.</returns>
        public static bool IsNameValid(string namePlayer1, string namePlayer2, ref string errorMessage)
        {
            if(namePlayer1.Length < 3 || namePlayer1.Length > 13 || string.IsNullOrWhiteSpace(namePlayer1))
            {
                errorMessage = "Nom joueur 1 nom compris entre 3 et 13 caractères";
                return false;
            }
            if (namePlayer2.Length < 3 || namePlayer2.Length > 13 || string.IsNullOrWhiteSpace(namePlayer2))
            {
                errorMessage = "Nom joueur 2 nom compris entre 3 et 13 caractères";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Vérifie la validité du déplacement donnée
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur </param>
        /// <returns> True : Le déplacement réussie, False : Le déplacement échoue </returns>
        public bool CheckMove(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Plateau board, ref string errorMessage)
        {
            return MoveManager.CheckMove(rowStart, colStart, rowDest, colDest, currentPlayer, board, ref errorMessage);
        }

        /// <summary>
        /// Effectue le déplacement d'un animal sur le plateau de jeu
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <returns> True : Le déplacement réussie, False : Le déplacement échoue </returns>
        public bool MoveAnimal(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Player waitingPlayer, Plateau board)
        {
            return MoveManager.MoveAnimal(rowStart, colStart, rowDest, colDest, currentPlayer, waitingPlayer, board);
        }

        /// <summary>
        /// Vérifie si la partie est terminée
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="board"> Plateau du jeu </param>
        /// <returns> True : La partie est terminée, False : La partie continue </returns>
        public bool IsGameOver(Player player1, Player player2, Plateau board, ref Player winnerPlayer)
        {
            return VictoryManager.GameOver(player1, player2, board, ref winnerPlayer);
        }

        /// <summary>
        /// Obtient un déplacement valide du joueur courant en passant par des évènements de sélection de valeur 
        /// <see cref="OnValueSelecting(string)"/> <see cref="OnSelectMoveFailed(int, int, string)"/>  
        /// </summary>
        /// <param name="prompt"> Intitulé du déplacement demandé au joueur courant </param>
        /// <param name="xMin"> Valeur minimale valide de X c'est à dire 1</param>
        /// <param name="xMax"> Valeur maximale valide de X c'est à dire 9</param>
        /// <param name="yMin"> Valeur minimale valide de Y c'est à dire 1</param>
        /// <param name="yMax"> Valeur maximale valide de Y c'est à dire 7</param>
        /// <returns> Valeur valide entrée par le joueur courant </returns>
        public (int x, int y) GetValidMoveInput(string prompt, int xMin, int xMax, int yMin, int yMax)
        {
            string input;
            bool isValidInput;
            int x = 0, y = 0;

            do
            {
                OnValueSelecting(prompt);
                input = Console.ReadLine() ?? "";
                string[] parts = input.Split(' ');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out x) &&
                    int.TryParse(parts[1], out y))
                {
                    isValidInput = true;

                    if (x < xMin || x > xMax)
                    {
                        OnSelectMoveFailed(xMin, xMax, $"La coordonnée X doit être compris entre {xMin} et {xMax} !");
                        isValidInput = false;
                    }
                    if (y < yMin || y > yMax)
                    {
                        OnSelectMoveFailed(yMin, yMax, $"La coordonnée Y doit être compris entre {yMin} et {yMax} !");
                        isValidInput = false;
                    }
                }
                else
                {
                    isValidInput = false;
                    OnSelectMoveFailed(x, y, "Il faut rentrer deux coordonnés valides séparées par un espace !");
                }
            } while (!isValidInput);

            return (x, y);
        }


        /// <summary>
        /// Ajoute dans la liste des mouvements possibles les cases adjacentes accessibles
        /// en utilisant la méthode CheckMove <see cref="CheckMove(int, int, int, int, Player, Plateau, ref string)"/>
        /// </summary>
        /// <param name="xStart"> Coordonnée X de départ </param>
        /// <param name="yStart"> Coordonnée Y de départ </param>
        /// <returns> Liste des mouvements possibles pour le joueur avec un animal sélectionné </returns>
        public List<(int x, int y)> GetValidMoves(int xStart, int yStart)
        {
            string message = "";
            List<(int x, int y)> validMoves = [];

            /* Test des cases adjacentes */
            if (CheckMove(xStart, yStart, xStart + 1, yStart, CurrentPlayer, Board, ref message)) validMoves.Add((xStart + 1, yStart));
            if (CheckMove(xStart, yStart, xStart - 1, yStart, CurrentPlayer, Board, ref message)) validMoves.Add((xStart - 1, yStart));
            if (CheckMove(xStart, yStart, xStart, yStart + 1, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart + 1));
            if (CheckMove(xStart, yStart, xStart, yStart - 1, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart - 1));

            if (Board.Cases[xStart - 1, yStart - 1].Inhabitant!.Strength is 6 or 7) /* Cas particuliers : Lion et Tigre */
            {
                if (yStart == 1 && xStart is 4 or 5 or 6) /* Première colonne */
                {
                    if (CheckMove(xStart, yStart, xStart, yStart + 3, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart + 3));
                }
                if (yStart == 4 && xStart is 4 or 5 or 6) /* Colonne du milieu */
                {
                    if (CheckMove(xStart, yStart, xStart, yStart + 3, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart + 3));
                    if (CheckMove(xStart, yStart, xStart, yStart - 3, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart - 3));
                }
                if (yStart == 7 && xStart is 4 or 5 or 6) /* Dernière colonne */
                {
                    if (CheckMove(xStart, yStart, xStart, yStart - 3, CurrentPlayer, Board, ref message)) validMoves.Add((xStart, yStart - 3));
                }
                if (xStart == 3 && yStart is 2 or 3 or 5 or 6) /* Ligne haute */
                {
                    if (CheckMove(xStart, yStart, xStart + 4, yStart, CurrentPlayer, Board, ref message)) validMoves.Add((xStart + 4, yStart));
                }
                if (xStart == 7 && yStart is 2 or 3 or 5 or 6) /* Ligne basse */
                {
                    if (CheckMove(xStart, yStart, xStart - 4, yStart, CurrentPlayer, Board, ref message)) validMoves.Add((xStart - 4, yStart));
                }
            }

            return validMoves;
        }


        /// <summary>
        /// Sélectionne le déplacement à effectuer, en affichant plus tôt le plateau de jeu <see cref="OnBoardChanged(Plateau, string)"/>,
        /// par le biais d'un évènement de vérification de la validité des coordonnées saisies <see cref="GetValidMoveInput(string, int, int, int, int)"/>
        /// </summary>
        /// <param name="rowStart"> Abscisse de la case de départ du déplacement</param>
        /// <param name="colStart"> Ordonnée de la case de départ du déplacement </param>
        /// <param name="rowDest"> Abscisse de la case destination du déplacement </param>
        /// <param name="colDest"> Ordonnée de la case destination du déplacement </param>
        public void SelectMove(string namePlayer, ref int rowStart, ref int colStart, ref int rowDest, ref int colDest)
        {
            OnBoardChanged(Board, namePlayer);
            Console.ForegroundColor = ConsoleColor.Yellow;
            (rowStart, colStart) = GetValidMoveInput($"Rentrer les coordonnées de l'animal (en séparant par un espace) : ", 1, 9, 1, 7);
            (rowDest, colDest) = GetValidMoveInput($"Rentrer les coordonnées de la destination (en séparant par un espace) : ", 1, 9, 1, 7);
        }

        /// <summary>
        /// Evènement déclenché lorsqu'une saisie de valeur est demandé à un joueur
        /// </summary>
        public event EventHandler<ValueSelectingEventArgs>? ValueSelecting;

        /// <summary>
        /// Déclenche l'évènement ValueSelectingEventArgs avec le message
        /// </summary>
        /// <param name="message"> Message </param>
        protected virtual void OnValueSelecting(string message)
            => ValueSelecting?.Invoke(this, new ValueSelectingEventArgs(message));

        /// <summary>
        /// Evènement déclenché lorsqu'un déplacement échoue 
        /// pour des raisons de coordonnées invalides
        /// </summary>
        public event EventHandler<SelectMoveFailedEventArgs>? SelectMoveFailed;

        /// <summary>
        /// Déclenche l'évènement SelectMoveFailedEventArgs avec 
        /// les valeurs minimale et maximale ainsi que le message
        /// </summary>
        /// <param name="min"> Valeur minamale </param>
        /// <param name="max"> Valeur maximale </param>
        /// <param name="message"> Message </param>
        protected virtual void OnSelectMoveFailed(int min, int max, string message)
            => SelectMoveFailed?.Invoke(this, new SelectMoveFailedEventArgs(min, max, message));

        /// <summary>
        /// Evénement déclenché lorsque le plateau recensie un déplacement
        /// </summary>
        public event EventHandler<BoardChangedEventArgs>? BoardChanged;

        /// <summary>
        /// Déclenche l'évènement BoardChangedEventArgs avec le plateau de jeu
        /// </summary>
        /// <param name="board"> Plateau de jeu </param>
        protected virtual void OnBoardChanged(Plateau board, string namePlayer)
            => BoardChanged?.Invoke(this, new BoardChangedEventArgs(Board, namePlayer));

        /// <summary>
        /// Evénement déclenché lorsqu'un joueur échoue la saisie d'un mouvement
        /// </summary>
        public event EventHandler<PlayersSelectFailedEventArgs>? PlayersSelectFailed;
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Déclenche l'évènement PlayersSelectFailedEventArgs avec le message
        /// </summary>
        /// <param name="message"> Message </param>
        protected virtual void OnPlayersSelectFailed(string message)
            => PlayersSelectFailed?.Invoke(this, new PlayersSelectFailedEventArgs(message));


        /// <summary>
        /// Événement déclenché lorsqu'un joueur actuel est changé.
        /// </summary>
        public event EventHandler<CurrentPlayerChangedEventArgs>? CurrentPlayerChanged;

        /// <summary>
        /// Déclenche l'événement CurrentPlayerChanged.
        /// </summary>
        /// <param name="currentPlayer">Le joueur actuel.</param>
        /// <param name="player1">Le joueur 1.</param>
        /// <param name="player2">Le joueur 2.</param>
        protected virtual void OnCurrentPlayerChanged(Player currentPlayer, Player player1, Player player2)
            => CurrentPlayerChanged?.Invoke(this, new CurrentPlayerChangedEventArgs(currentPlayer, player1, player2));

        /// <summary>
        /// Événement déclenché lorsqu'un déplacement échoue.
        /// </summary>
        public event EventHandler<MoveFailedEventArgs>? MoveFailed;

        /// <summary>
        /// Déclenche l'événement MoveFailed.
        /// </summary>
        /// <param name="errorMessage">Le message d'erreur associé à l'échec du déplacement.</param>
        protected virtual void OnMoveFailed(string errorMessage)
            => MoveFailed?.Invoke(this, new MoveFailedEventArgs(errorMessage));

        /// <summary>
        /// Événement déclenché lorsqu'une partie est terminée.
        /// </summary>
        public event EventHandler<GameOverEventArgs>? GameOver;

        /// <summary>
        /// Déclenche l'événement GameOver.
        /// </summary>
        /// <param name="game">La partie terminée.</param>
        protected virtual void OnGameOver(Game game)
            => GameOver?.Invoke(this, new GameOverEventArgs(game));

        /// <summary>
        /// Effectue un tour de jeu
        /// Les méthodes du MoveManager :
        /// <see cref="CheckMove(int, int, int, int, Player, Plateau, ref string)"/> 
        /// <see cref="MoveAnimal(int, int, int, int, Player, Player, Plateau)"/>
        /// Les méthodes et évènements du GameManager :
        /// <see cref="ChangeCurrentPlayer"> <see cref="OnMoveFailed(string)"/>
        /// <see cref="IsGameOver(Player, Player, Plateau, ref Player)"/> <see cref="OnGameOver(Game)"/>
        /// </summary>
        /// <param name="row">La ligne de départ de l'animal.</param>
        /// <param name="col">La colonne de départ de l'animal.</param>
        /// <param name="rowDest">La ligne de destination de l'animal.</param>
        /// <param name="colDest">La colonne de destination de l'animal.</param>
        public void PlayTurn(int row, int col, int rowDest, int colDest)
        {
            string errorMessage = "";
            if (CheckMove(row, col, rowDest, colDest, currentPlayer, Board, ref errorMessage))
            {
                MoveAnimal(row, col, rowDest, colDest, CurrentPlayer, GetWaitingPlayer(), Board); // Evenement plateau changé
                ChangeCurrentPlayer(); // Evenement changement de joueur
            }
            else
            {
                OnMoveFailed(errorMessage);
            }

            Player winnerPlayer = new Player(3, "");

            if (IsGameOver(Player1, Player2, Board, ref winnerPlayer))
            {
                Game game = new Game(1, winnerPlayer, CurrentPlayer, DateTime.Today);
                OnGameOver(game); // Evenement fin de partie qui enregister dans le fichier .xml + renvoie sur VictoryPage
            }
        }

    }
}