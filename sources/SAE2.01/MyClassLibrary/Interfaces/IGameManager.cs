using MyClassLibrary.Essentials;
using MyClassLibrary.Events;

namespace MyClassLibrary.Interfaces
{
    /// <summary>
    /// Représente le type de contrat qui définit l'ensemble des membres utilisés par le maître du jeu
    /// </summary>
    public interface IGameManager
    {
        public IMoveManager MoveManager { get; }
        /// <summary>
        /// Initialise le joueur 1 de la partie
        /// </summary>
        public Player Player1 { get; }

        /// <summary>
        /// Initialise le joueur 2 de la partie
        /// </summary>
        public Player Player2 { get; }

        /// <summary>
        /// Initialise le joueur courant de la partie
        /// </summary>
        public Player CurrentPlayer { get; }

        /// <summary>
        /// Initialise le plateau de jeu sur lequel se déroulera la partie
        /// </summary>
        public Plateau Board { get; }

        /// <summary>
        /// Événement déclenché lorsqu'il y a un changement sur le plateau de jeu.
        /// </summary>
        public event EventHandler<BoardChangedEventArgs>? BoardChanged;

        /// <summary>
        /// Événement déclenché lorsqu'une sélection de mouvement échoue.
        /// </summary>
        public event EventHandler<SelectMoveFailedEventArgs>? SelectMoveFailed;

        /// <summary>
        /// Événement déclenché lorsqu'une valeur est en cours de sélection.
        /// </summary>
        public event EventHandler<ValueSelectingEventArgs>? ValueSelecting;

        /// <summary>
        /// Événement déclenché lorsqu'une sélection de joueurs échoue.
        /// </summary>
        public event EventHandler<PlayersSelectFailedEventArgs>? PlayersSelectFailed;

        /// <summary>
        /// Événement déclenché lorsqu'un changement de joueur actuel a lieu.
        /// </summary>
        public event EventHandler<CurrentPlayerChangedEventArgs>? CurrentPlayerChanged;

        /// <summary>
        /// Événement déclenché lorsqu'un déplacement échoue.
        /// </summary>
        public event EventHandler<MoveFailedEventArgs>? MoveFailed;

        /// <summary>
        /// Événement déclenché lorsqu'une partie est terminée.
        /// </summary>
        public event EventHandler<GameOverEventArgs>? GameOver;


        /// <summary>
        /// Crée une nouvelle partie avec les noms des joueurs
        /// </summary>
        /// <param name="namePlayer1"></param>
        /// <param name="namePlayer2"></param>
        public void CreateGame(string namePlayer1, string namePlayer2);

        /// <summary>
        /// Sélectionne les noms des joueurs
        /// </summary>
        /// <param name="namePlayer1"> Joueur 1 </param>
        /// <param name="namePlayer2"> Joueur 2 </param>
        public void SelectPlayer(ref string namePlayer1, ref string namePlayer2);

        /// <summary>
        /// Change le joueur courant pour le joueur suivant
        /// </summary>
        public void ChangeCurrentPlayer();

        /// <summary>
        /// Obtient le joueur en attente
        /// </summary>
        /// <returns>Le joueur en attente</returns>
        public Player GetWaitingPlayer();

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
        public bool CheckMove(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Plateau board, ref string errorMessage);

        /// <summary>
        /// Effectue le déplacement d'un animal sur le plateau de jeu
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        /// <param name="currentPlayer"> Joueur courant </param>
        /// <param name="board"> Plateau de jeu </param>
        /// <param name="errorMessage"> Message d'erreur en cas d'échec du déplacement </param>
        /// <returns> True : Le déplacement réussie, False : Le déplacement échoue </returns>
        public bool MoveAnimal(int rowStart, int colStart, int rowDest, int colDest, Player currentPlayer, Player waitingPlayer, Plateau board);

        /// <summary>
        /// Sélectionne le déplacement à effectuer
        /// </summary>
        /// <param name="rowStart"> Ligne de départ </param>
        /// <param name="colStart"> Colonne de départ </param>
        /// <param name="rowDest"> Ligne d'arrivée </param>
        /// <param name="colDest"> Colonne d'arrivée </param>
        public void SelectMove(string namePlayer, ref int rowStart, ref int colStart, ref int rowDest, ref int colDest);

        /// <summary>
        /// Vérifie si la partie est terminée
        /// </summary>
        /// <param name="player1"> Joueur 1 </param>
        /// <param name="player2"> Joueur 2 </param>
        /// <param name="board"> Plateau du jeu </param>
        /// <returns> True : La partie est terminée, False : La partie continue </returns>
        public bool IsGameOver(Player player1, Player player2, Plateau board, ref Player winnerPlayer);

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
        public void PlayTurn(int row, int col, int rowDest, int colDest);

        /// <summary>
        /// Ajoute dans la liste des mouvements possibles les cases adjacentes accessibles
        /// en utilisant la méthode CheckMove <see cref="CheckMove(int, int, int, int, Player, Plateau, ref string)"/>
        /// </summary>
        /// <param name="xStart"> Coordonnée X de départ </param>
        /// <param name="yStart"> Coordonnée Y de départ </param>
        /// <returns> Liste des mouvements possibles pour le joueur avec un animal sélectionné </returns>
        public List<(int x, int y)> GetValidMoves(int xStart, int yStart);
    }
}
