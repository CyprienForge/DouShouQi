using MyClassLibrary.Essentials;
using MyClassLibrary.Implementations;
using Plugin.Maui.Audio;

namespace SAE2._01.Views.Pages;
public partial class Pregame : ContentPage
{
    private readonly AudioManager audioManager;
    public Player Player1 { get; private set; } = new Player(1, "");
    public Player Player2 { get; private set; } = new Player(2, "");
    public Player ? CurrentPlayer { get; private set; }

    public string ErrorMessage
    { 
        get => errorMessage!; 
        private set
        {
            if (value == null) return;
            if (value == errorMessage) return;

            errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));   
        }
    }
    private string? errorMessage;

    public Pregame()
    {
        InitializeComponent();
        BindingContext = this;
        audioManager = new AudioManager();
        Shell.SetNavBarIsVisible(this, false);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await FadeInPageAsync();
    }

    private async Task FadeInPageAsync()
    {
        Opacity = 0;

        await this.FadeTo(1, 500, Easing.Linear);
    }

    private async void OnStartButtonClicked(Object _, EventArgs __)
    {
        string errorMessage = "";
        if (String.IsNullOrWhiteSpace(Entry1.Text)) return;
        Player1.Name = Entry1.Text;

        if (String.IsNullOrWhiteSpace(Entry2.Text)) return;
        Player2.Name = Entry2.Text;

        if (Player1.Name == Player2.Name)
        {
            ErrorMessage = "Les 2 joueurs possedent le même nom";
            return;
        }

        if (!GameMaster.IsNameValid(Entry1.Text, Entry2.Text, ref errorMessage))
        {
            ErrorMessage = errorMessage;
            return;
        }

        audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("startsound.wav")).Play();

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

        circle.IsVisible = true;

        await Task.WhenAll
        (
            circle.FadeTo(1, 200, Easing.Linear),
            circle.ScaleTo(circle.Scale * 50, 500, Easing.Linear)
        );

        var parameters = new Dictionary<string, object>()
        {
            { "player1" , Player1 },
            { "player2" , Player2 },
            { "currentPlayer" , CurrentPlayer }
        };

        await Shell.Current.GoToAsync($"BoardPage", parameters);

        await Task.WhenAll
        (
            circle.FadeTo(0, 1000, Easing.Linear),
            circle.ScaleTo(1, 1000, Easing.Linear)
        );

        circle.IsVisible = false;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await backbutton.ScaleTo(.9, 200, Easing.CubicIn);

        audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("buttonsound.wav")).Play();

        await this.FadeTo(0, 500, Easing.CubicInOut);

        await Task.WhenAll
        (
            Shell.Current.GoToAsync(".."),
            backbutton.ScaleTo(1, 200)
        );

        await this.FadeTo(1, 500, Easing.CubicInOut);
    }
}