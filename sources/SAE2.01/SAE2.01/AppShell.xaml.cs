namespace SAE2._01;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("PregamePage", typeof(Views.Pages.Pregame));
        Routing.RegisterRoute("BoardPage", typeof(Views.Pages.BoardPage));
        Routing.RegisterRoute("HistoryPage", typeof(Views.Pages.HistoryPage));
        Routing.RegisterRoute("BoardPage/RulesPage", typeof(Views.Pages.RulesPage));
        Routing.RegisterRoute("BoardPage/ParametersPage", typeof(Views.Pages.ParametersPage));
        Routing.RegisterRoute("CreditsPage", typeof(Views.Pages.Credits));
        Routing.RegisterRoute("HomeRulesPage", typeof(Views.Pages.RulesPage));
        Routing.RegisterRoute("HomeParametersPage", typeof(Views.Pages.ParametersPage));
    }
}
