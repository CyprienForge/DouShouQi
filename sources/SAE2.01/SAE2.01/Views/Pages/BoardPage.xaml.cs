namespace SAE2._01.Views.Pages;
using ex_BindingToA2dArray_context;
using Microsoft.Maui.Controls;
using MyClassLibrary.Essentials;
using MyClassLibrary.Implementations;
using MyClassLibrary.Interfaces;
using DouShouQi.Persistance.XML;
using System.ComponentModel;
using System.Collections.Generic;
using SAE2._01.Layouts;
using Plugin.Maui.Audio;

public partial class BoardPage : ContentPage, INotifyPropertyChanged, IQueryAttributable
{
    private readonly AudioManager audioManager;
    public Player? Player1 
    { 
        get;
        private set;
    }
    public Player? Player2
    {
        get;
        private set;
    }
    public Player? CurrentPlayer
    {
        get;
        private set;
    }
    public Matrix2d? Matrix
    {
        get => matrix;
        private set
        {
            if (value == null) return;
            if (value == matrix) return;
            matrix = value;
            OnPropertyChanged();
        }
    }
    private Matrix2d? matrix;
    public IGameManager? GameManager { get; private set; }

    private int[]? coordStart;
    private int[]? coordEnd;

    private IAudioPlayer? pawnMoveGround;
    private IAudioPlayer? pawnMoveRiver;
    private IAudioPlayer? pawnMoveTrap;
    private IAudioPlayer? pawnMoveDen;
    private IAudioPlayer? pawnMove8Eat;
    private IAudioPlayer? pawnMove7654Eat;
    private IAudioPlayer? pawnMove321Eat;
    private IAudioPlayer? gameOver;

    /// <summary>
    /// Initialise les ressources audio de manière asynchrone.
    /// </summary>
    private async Task InitializeAudioAsync()
    {
        pawnMoveGround = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmoveground.wav"));
        pawnMoveRiver = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmoveriver.wav"));
        pawnMoveTrap = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmovetrap.wav"));
        pawnMoveDen = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmoveden.wav"));

        pawnMove8Eat = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmove8eat.wav"));
        pawnMove7654Eat = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmove7654eat.wav"));
        pawnMove321Eat = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("pawnmove321eat.wav"));

        gameOver = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("applause.wav"));
    }

    /// <summary>
    /// Applique les attributs de requête à la page du plateau de jeu.
    /// </summary>
    /// <param name="query">Les attributs de requête à appliquer.</param>
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Player1 = query["player1"] as Player;
        OnPropertyChanged(nameof(Player1));

        Player2 = query["player2"] as Player;
        OnPropertyChanged(nameof(Player2));

        CurrentPlayer = query["currentPlayer"] as Player;
        OnPropertyChanged(nameof(CurrentPlayer));

        GameManager = new GameMaster(Player1!, Player2!, CurrentPlayer!);
        await DisplayCurrentPlayer(GameManager);
        Matrix = new Matrix2d(GameManager.Board);
        GameManager.CurrentPlayerChanged += GameManager_CurrentPlayerChanged;
        GameManager.MoveFailed += GameManager_MoveFailed;
        GameManager.GameOver += GameManager_GameOver;
        GameManager.MoveManager.Fighted += MoveManager_Fighted;
        GameManager.MoveManager.Moved += MoveManager_Moved;
    }

    /// <summary>
    /// Gère l'événement du déplacement.
    /// </summary>
    private void MoveManager_Moved(object? sender, MyClassLibrary.Events.MovedEventArgs e)
    {
        OnPawnMove(e.X, e.Y);
    }

    /// <summary>
    /// Gère l'événement du combat.
    /// </summary>
    private void MoveManager_Fighted(object? sender, MyClassLibrary.Events.FightedEventArgs e)
    {
        OnPawnEatingClicked(e.Animal);
    }

    /// <summary>
    /// Récupère les déplacements possible pour un pion donné
    /// <see cref="IGameManager.GetValidMoves(int, int)"/>
    /// </summary>
    private List<(int x, int y)> ValidMoves = [];

    /// <summary>
    /// Récupère les bouttons pour les différencier du premier (choix du pion)
    /// et du deuxième click (déplacement du pion)
    /// <see cref="ButtonMove(object, EventArgs)"/>
    /// </summary>
    private readonly List<Button> ButtonCases = [];

    public BoardPage()
    {
        InitializeComponent();
        audioManager = new AudioManager();
        InitializeAudioAsync().ConfigureAwait(false);
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        TransitionCircle();
    }

    private async void TransitionCircle()
    {
        circle.IsVisible = true;

        await circle.ScaleTo(circle.Scale * 75, 0, Easing.Linear);

        await circle.ScaleTo(1, 1500, Easing.Linear);

        circle.IsVisible = false;
    }

    /// <summary>
    /// Affiche le joueur actuel sur le plateau de jeu.
    /// </summary>
    /// <param name="gameManager">L'instance du gestionnaire de jeu.</param>
    private async Task DisplayCurrentPlayer(IGameManager gameManager)
    {
        if (gameManager.CurrentPlayer.Id == 1)
        {
            await Task.WhenAll
            (
                encreop1.FadeTo(1, 100, Easing.Linear),
                nameplayer1.FadeTo(1, 100, Easing.Linear),
                encreop2.FadeTo(.3, 100, Easing.Linear),
                nameplayer2.FadeTo(.3, 100, Easing.Linear)
            );
        }
        else
        {
            await Task.WhenAll
            (
                encreop1.FadeTo(.3, 100, Easing.Linear),
                nameplayer1.FadeTo(.3, 100, Easing.Linear),
                encreop2.FadeTo(1, 100, Easing.Linear),
                nameplayer2.FadeTo(1, 100, Easing.Linear)
            );
        }
    }

    /// <summary>
    /// Gère l'événement de fin de jeu.
    /// </summary>
    private async void GameManager_GameOver(object? sender, MyClassLibrary.Events.GameOverEventArgs e)
    {
        pawnMoveDen!.Play();
        gameOver!.Play();
        SaveManager saveManager = new();
        GameList games = saveManager.LoadGames(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\..\\Save\\game.xml"));
        games.AddGame(e.Game);
        saveManager.SaveGames(games, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\..\\Save\\game.xml"));

        await Shell.Current.GoToAsync($"//VictoryPage?winnerPlayer={e.Game.Winner.Name}");
    }

    /// <summary>
    /// Gère l'événement d'un déplacement raté
    /// </summary>
    private async void GameManager_MoveFailed(object? sender, MyClassLibrary.Events.MoveFailedEventArgs e)
    {
        await DisplayAlert("MOUVEMENT RATÉ", $"Raté {e.ErrorMessage}!", "OK");
    }

    /// <summary>
    /// Gère l'événement du changement du joueur courant
    /// </summary>
    private async void GameManager_CurrentPlayerChanged(object? sender, MyClassLibrary.Events.CurrentPlayerChangedEventArgs e)
    {
        await DisplayCurrentPlayer(GameManager!);
    }

    /// <summary>
    /// Récupère dans un premier temps la case de départ et affiche les cases valides
    /// Récupère dans un second temps la case de destination et effectue le tour
    /// À la fin du tour, les coordonnées et la liste des boutons sont remises à 0
    /// <see cref="IGameManager.PlayTurn(int, int, int, int)"/>
    /// <see cref="coordStart"/> <see cref="coordEnd"/> <see cref="ButtonCases"/>
    /// <see cref="IGameManager.GetValidMoves(int, int)"/> <see cref="DisplayValidMoves(List{ValueTuple{int, int}}, string)"/>
    /// </summary>
    /// <param name="sender"> Bouton cliqué </param>
    /// <param name="_"></param>
    private async void ButtonMove(object sender, EventArgs _)
    {
        Button? button = (Button)sender;
         
        // Récupérer l'id du bouton
        int id = int.Parse(button.AutomationId);

        // Récupérer la position du bouton
        int row = (id - 1) / Matrix!.NbRows;
        int col = (id - 1) % Matrix.NbRows;

        if (ButtonCases.Count == 0)
        {
            ButtonCases.Add(button);

            if (!GameManager!.Board.Cases[row, col].IsOccuped)
            {
                ButtonCases.Clear();
                return;
            }
            if (GameManager.Board.Cases[row, col].Inhabitant!.PlayerOwner.Id != GameManager.CurrentPlayer!.Id) // Appel au GameManager pour gérer l'affichage
            {
                ButtonCases.Clear();
                return;
            }

            ButtonCases[0].Background = Color.FromArgb("#80FFFFFF");

            coordStart = [row + 1, col + 1];

            if (coordStart != null)
            {
                ValidMoves = GameManager!.GetValidMoves(coordStart[0], coordStart[1]);  // Appel au GameManager pour gérer l'affichage
                DisplayValidMoves(ValidMoves, "#bfecb3");
            }

            await Task.WhenAll(
                choosepawn.FadeTo(0, 100, Easing.Linear),
                choosemovement.FadeTo(1, 100, Easing.Linear)
            );

            return;
        }

        ButtonCases.Add(button);

        await Task.WhenAll(
            choosepawn.FadeTo(1, 100, Easing.Linear),
            choosemovement.FadeTo(0, 100, Easing.Linear)
        );

        coordEnd = [row + 1, col + 1];

        GameManager!.PlayTurn(coordStart[0], coordStart[1], coordEnd[0], coordEnd[1]); // Appel au GameManager (métier) pour gérer les déplacements

        coordStart = null;
        coordEnd = null;

        DisplayValidMoves(ValidMoves, "#00FFFFFF");

        ButtonCases[0].Background = Color.FromArgb("#00FFFFFF");
        ButtonCases.Clear();               
    }

    /// <summary>
    /// Recherche le bouton associé à l'ID donné
    /// Joue le son selon le type de case de destination :
    /// - Son Standard
    /// - Son Aquatique
    /// - Son Piège
    /// - Son Victorieux
    /// Utilise la biblioth�que Plugin.MAUI.Audio
    /// </summary>
    /// <param name="board"> Plateau de jeu </param>
    /// <param name="id"> ID du bouton </param>
    /// <returns> Bouton associé à l'ID </returns>
    private static Button? FindButtonById(BoardLayout boardLayout, string id)
    {
        foreach (var child in boardLayout.Children)
        {
            if (child is Border border)
            {
                if (border.Content is Grid grid)
                {
                    foreach (var gridChild in grid.Children)
                    {
                        if (gridChild is Button button && button.AutomationId == id)
                        {
                            return button;
                        }
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Calcule l'ID du bouton selon les coordonnées X et Y
    /// Change le fond du bouton à l'affichage
    /// </summary>
    /// <param name="validMoves"> Liste des mouvements possibles </param>
    private void DisplayValidMoves(List<(int x, int y)> validMoves, string color)
    {
        foreach (var possibleMove in validMoves)
        {
            int x = possibleMove.x - 1;
            int y = possibleMove.y - 1;

            string id = ((x * Matrix!.NbRows) + y + 1).ToString();

            var validButton = FindButtonById(board, id);
            
            validButton!.Background = Color.FromArgb(color);
        }
    }

    /// <summary>
    /// Joue le son selon le type de case de destination :
    /// - Son Standard
    /// - Son Aquatique
    /// - Son Piégé
    /// - Son Victorieux
    /// Utilise la bibliothèque Plugin.MAUI.Audio
    /// </summary>
    /// <param name="x"> Coordonnée X </param>
    /// <param name="y"> Coordonnée Y </param>
    private void OnPawnMove(int x, int y)
    {
        if (GameManager!.Board.IsRiver(x - 1, y - 1)) pawnMoveRiver?.Play();
        else if (GameManager.Board.IsTrap(x - 1, y - 1)) pawnMoveTrap?.Play();
        else if (GameManager.Board.IsDen(x - 1, y - 1)) pawnMoveDen?.Play();
        else pawnMoveGround?.Play();
    }

    /// <summary>
    /// Joue le son de succès de la bataille selon l'animal vainqueur :
    /// - Son de terrassement (Éléphant)
    /// - Son sauvage (Lion, Tigre, Panthère et Loup)
    /// - Son de croc (Chien, Chat et Rat)
    /// </summary>
    /// <param name="animal"> Puissance de l'animal vainqueur </param>
    private void OnPawnEatingClicked(int animal)
    {
        if (animal >= 4 && animal < 8) pawnMove7654Eat?.Play();
        else if (animal <= 3) pawnMove321Eat?.Play();
        else pawnMove8Eat?.Play();
    }

}