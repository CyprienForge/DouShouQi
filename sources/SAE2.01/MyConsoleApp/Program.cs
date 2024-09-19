using MyClassLibrary.Interfaces;
using MyClassLibrary.Implementations;
using DouShouQi.Persistance.XML;
using MyClassLibrary.Events;
using MyClassLibrary.Enum;
using MyClassLibrary.Essentials;

Console.SetWindowSize(Console.WindowWidth*2, Console.WindowHeight*2);

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("┌——————--—————————————————————————————————————————————————————————-————————————————————-————————————————————————————————--————--——┐");
Console.WriteLine("│                                                                                                                                 │");
Console.Write("│                                                ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("BIENVENUE SUR LE JEU DU DOU SHOU QI");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("                                              │");
Console.WriteLine("│                                                                                                                                 │");
Console.WriteLine("└—————————--——————————————————————————————————————-—————————————————————————————-——————————————————————————————————————————----———┘");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine();

IGameManager gameManager = new GameMaster();

void Game_BoardChanged(object? sender, BoardChangedEventArgs e)
{
    DisplayBoardTop();
    DisplayBoardCases();
    DisplayBoardBottom();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"┌- Tour de {e.NamePlayer}");
    Console.WriteLine($"└> Choix de votre animal \n");
}

void DisplayBoardTop()
{
    // Affichage du nom et de la bordure horizontale du haut
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("┌---------------------------------------------------------------------------------------------------------------------------------┐");
    Console.Write("│                                                     ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("LE PLATEAU DU DOU SHI QI");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("                                                    │");
    Console.WriteLine("+---------------------------------------------------------------------------------------------------------------------------------+");
    Console.WriteLine("│                1               2               3               4               5               6               7                │");
    Console.WriteLine("│     ┌---------------------------------------------------------------------------------------------------------------------┐     │");
}

void DisplayBoardCases()
{
    DisplayBoardRows();
}
void DisplayBoardRows()
{
    for (int row = 0; row < gameManager.Board.Cases.GetLength(0); row++)
    {
        // Affichage des bordures verticales
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("│     │\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t    │     │");
        Console.Write($"│  {row + 1}  │");

        DisplayBoardColumns(row);
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"     │  {row + 1}  │");
    }
}

void DisplayBoardColumns(int row)
{
    for (int column = 0; column < gameManager.Board.Cases.GetLength(1); column++)
    {

        Ground ground = gameManager.Board.Cases[row, column].GroundType;
        bool isOccuped = gameManager.Board.Cases[row, column].IsOccuped;

        if (!isOccuped)
        {
            WriteUnoccupiedCase(ground);
        }
        else
        {
            string playerName = gameManager.Board.Cases[row, column].Inhabitant!.PlayerOwner.Name;
            int animalStrength = gameManager.Board.Cases[row, column].Inhabitant!.Strength;

            WriteOccupiedCase(ground, playerName, animalStrength);
        }
    }
}

void WriteUnoccupiedCase(Ground type)
{
    // Affichage et colorie spécifique selon le type de case
    if (type == Ground.RIVER)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("     [   Eau   ]");
        Console.ResetColor();
    }
    else if (type == Ground.TRAP)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("     [  Piège  ]");
        Console.ResetColor();
    }
    else if (type == Ground.DEN)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("     [ Tanière ]");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("     [   Vide  ]");
        Console.ResetColor();
    }
}
void WriteOccupiedCase(Ground type, string playerName, int animalStrength)
{
    // Affichage et colorie si la case est occupée par un joueur
    if (type == Ground.RIVER)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"     [{animalStrength}:{playerName}]");
    }
    else if (type == Ground.TRAP)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"     [{animalStrength}:{playerName}]");
    }
    else if (type == Ground.DEN)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"     [{animalStrength}:{playerName}]");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"     [{animalStrength}:{playerName}]");
    }
}
void DisplayBoardBottom()
{
    // Affichage de la bordure horizontale du bas
    Console.WriteLine("│     │\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t    │     │");
    Console.WriteLine("│     └---------------------------------------------------------------------------------------------------------------------┘     │");
    Console.WriteLine("│                1               2               3               4               5               6               7                │");
    Console.WriteLine("└---------------------------------------------------------------------------------------------------------------------------------┘");
    Console.WriteLine();
    Console.ResetColor();
}

void Move_SelectMoveFailed(object? sender, SelectMoveFailedEventArgs e)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine($"\n└> {e.ErrorMessage}\n");
    Console.ForegroundColor = ConsoleColor.Yellow;
}

void Game_ValueSelecting(object? sender,ValueSelectingEventArgs e)
{
    Console.Write($"-> {e.Message}");
}

void Game_PlayersSelectFailed(object? sender, PlayersSelectFailedEventArgs e) 
{ 
    Console.WriteLine(e.ErrorMessage);
}

gameManager.BoardChanged += Game_BoardChanged;
gameManager.SelectMoveFailed += Move_SelectMoveFailed;
gameManager.ValueSelecting += Game_ValueSelecting;
gameManager.PlayersSelectFailed += Game_PlayersSelectFailed;

bool statusGame = false;
string namePlayer1 = "";
string namePlayer2 = "";
string errorMessage = "";
Player winnerPlayer = new Player(3, "");
bool statusMove = false;

Console.WriteLine("Saisir le nom des joueurs\n");

gameManager.SelectPlayer(ref namePlayer1, ref namePlayer2);

gameManager.CreateGame(namePlayer1, namePlayer2);

Console.WriteLine("\nLa partie va bientôt commencer ... ");
Thread.Sleep(3000);
Console.Clear();


Console.WriteLine("\n|  Désignation aléatoire du joueur courant :");
Thread.Sleep(1000);
Console.WriteLine($"└> {gameManager.CurrentPlayer.Name} \n");

while (!statusGame)
{
    int rowStart = 0;
    int colStart = 0;
    int rowDest = 0;
    int colDest = 0;
    

    Console.ForegroundColor = ConsoleColor.Yellow;
    gameManager.SelectMove(gameManager.CurrentPlayer.Name,ref rowStart, ref colStart, ref rowDest, ref colDest);

    statusMove = gameManager.CheckMove(rowStart, colStart, rowDest, colDest, gameManager.CurrentPlayer, gameManager.Board, ref errorMessage);

    while (!statusMove)
    {
        Console.Clear();
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine(errorMessage);
        Console.ForegroundColor = ConsoleColor.Yellow;
        gameManager.SelectMove(gameManager.CurrentPlayer.Name, ref rowStart, ref colStart, ref rowDest, ref colDest);

        statusMove = gameManager.CheckMove(rowStart, colStart, rowDest, colDest, gameManager.CurrentPlayer, gameManager.Board, ref errorMessage);
    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"|  L'animal s'est bien déplacé :");
    int strength = gameManager.Board.Cases[rowStart - 1, colStart - 1].Inhabitant!.Strength;
    string name = gameManager.CurrentPlayer.Name;
    Console.WriteLine($"└> Déplacement sur la case [{rowDest}, {colDest}] de l'animal {strength} de {name}\n");
    Console.ForegroundColor = ConsoleColor.Yellow;

    gameManager.MoveAnimal(rowStart, colStart, rowDest, colDest, gameManager.CurrentPlayer, gameManager.GetWaitingPlayer(), gameManager.Board);

    statusGame = gameManager.IsGameOver(gameManager.Player1, gameManager.Player2, gameManager.Board, ref winnerPlayer);

    gameManager.ChangeCurrentPlayer();
}

gameManager.ChangeCurrentPlayer();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"\t| Victoire du Joueur : {gameManager.CurrentPlayer.Name}");

Game game = new Game(1, gameManager.CurrentPlayer, gameManager.GetWaitingPlayer(), DateTime.Today); // Crée pour l'historique des parties, à ajouter dans un fichier .xml
GameList games = new GameList();

ISaveManager saveManager = new SaveManager();
games = saveManager.LoadGames(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Save\\game.xml"));
games.AddGame(game);
saveManager.SaveGames(games, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Save\\game.xml"));
