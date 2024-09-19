using SAE2._01.Services;

namespace SAE2._01
{
    public partial class App : Application
    {
        private readonly IAudioService _audioService;

        public App(IAudioService audioService)
        {
            InitializeComponent();

            _audioService = audioService;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();
            _audioService.PlayMusic();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (!_audioService.IsMusicPlaying())
            {
                _audioService.PlayMusic();
            }
        }
    }
}
