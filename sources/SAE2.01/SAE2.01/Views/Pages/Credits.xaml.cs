using Plugin.Maui.Audio;

namespace SAE2._01.Views.Pages;

public partial class Credits : ContentPage
{
    private readonly AudioManager audioManager;
    public Credits()
    {
        InitializeComponent();
        audioManager = new AudioManager();
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