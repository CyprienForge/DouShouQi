namespace SAE2._01.Views.Pages;

[QueryProperty(nameof(WinnerPlayer), "winnerPlayer")]
public partial class VictoryPage : ContentPage
{
    public string WinnerPlayer 
    { 
        get => winnerPlayer!;
        set
        {
            if (value == null) return;
            if (value == winnerPlayer) return;

            winnerPlayer = value;
            OnPropertyChanged(nameof(WinnerPlayer));    
        }
    }
    private string? winnerPlayer;
	public VictoryPage()
	{
		InitializeComponent();
        BindingContext = this;
        Shell.SetNavBarIsVisible(this, false);
    }

    private async void BackHomeOnClicked(object sender, EventArgs e)
    {
        await backButton.ScaleTo(.9, 200, Easing.CubicIn);

        await this.FadeTo(0, 500, Easing.CubicInOut);

        await Task.WhenAll
        (
            Shell.Current.GoToAsync("///HomePage"),
            backButton.ScaleTo(1, 200)
        );
        await this.FadeTo(1, 500, Easing.CubicInOut);
    }
}