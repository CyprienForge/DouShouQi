namespace SAE2._01.Views.Pages;
using Plugin.Maui.Audio;
public partial class RulesPage : ContentPage
{
    private readonly AudioManager audioManager;
    public RulesPage()
    {
        audioManager = new AudioManager();
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
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