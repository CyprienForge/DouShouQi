using Plugin.Maui.Audio;
using Microsoft.Extensions.Logging;
using SAE2._01.Services;
using SAE2._01.ViewModels;

namespace SAE2._01
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<IAudioManager, AudioManager>();
            builder.Services.AddSingleton<IAudioService, AudioService>();

            builder.Services.AddTransient<AudioViewModel>(serviceProvider =>
            {
                var audioService = serviceProvider.GetRequiredService<IAudioService>();
                return new AudioViewModel(audioService);
            });
            var app = builder.Build();
            Services = app.Services;
            return app;
        }
        public static IServiceProvider? Services { get; private set; }
    }
}
