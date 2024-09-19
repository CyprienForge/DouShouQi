using SAE2._01.ViewModels;
namespace SAE2._01.Views.Pages;
using Plugin.Maui.Audio;

public partial class ParametersPage : ContentPage
{
    private readonly AudioManager audioManager;
    public ParametersPage()
    {
        InitializeComponent();
        audioManager = new AudioManager();
        BindingContext = MauiProgram.Services?.GetRequiredService<AudioViewModel>();
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