using Plugin.Maui.Audio;

namespace SAE2._01.Views.Pages;

public partial class HomePage : ContentPage
{
    private readonly AudioManager audioManager;
    public HomePage()
    {
        InitializeComponent();
        audioManager = new AudioManager();
        InitializeAudioAsync().ConfigureAwait(false);
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

    private IAudioPlayer? ButtonSound;

    private async Task InitializeAudioAsync()
    {
        ButtonSound = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("buttonsound.wav"));
    }       

    private async Task RotateRound()
    {
        await Task.WhenAll
        (
            round1.RotateTo(-90, 500, Easing.Linear),
            round2.RotateTo(90, 500, Easing.Linear)
        );
    }

    private async Task RotateBackButton()
    {
        await Task.WhenAll
        (
            round1.RotateTo(90, 500),
            round2.RotateTo(-90, 500)
        );
    }

    private async void OnPageButton(Image button, Image image, string route)
    {
        ButtonSound?.Play();

        await Task.WhenAll
        (
            button.ScaleTo(settingsButton.Scale * .95, 200, Easing.CubicIn),
            image.ScaleTo(settingsInk.Scale * .95, 200, Easing.CubicIn),
            RotateRound()
        );

        await this.FadeTo(0, 500, Easing.CubicInOut);

        await Task.WhenAll
        (
            Shell.Current.GoToAsync(route),
            button.ScaleTo(1, 200),
            image.ScaleTo(1, 200),
            RotateBackButton()
        );

        await this.FadeTo(1, 500, Easing.CubicInOut);
    }

    private void OnPregameButtonClicked(object _, EventArgs __)
    {
        OnPageButton(playInk, playButton, "PregamePage");
    }

    private void OnHistoryButtonClicked(object _, EventArgs __)
    {
        OnPageButton(historyInk, historyButton, "HistoryPage");
    }

    private void OnRulesButtonClicked(object _, EventArgs __)
    {
        OnPageButton(rulesInk, rulesButton, "RulesPage");
    }

    private void OnCreditsButtonClicked(object _, EventArgs __)
    {
        OnPageButton(creditsInk, creditsButton, "CreditsPage");
    }

    private void OnSettingsButtonClicked(object _, EventArgs __)
    {
        OnPageButton(settingsInk, settingsButton, "ParametersPage");
    }

    private async void OnExitButtonClicked(object _, EventArgs __)
    {
        await exit.ScaleTo(settingsButton.Scale * .95, 200, Easing.CubicIn);
        await Task.Delay(1000);
        Application.Current!.Quit();
    }
}