using Plugin.Maui.Audio;
namespace SAE2._01.Services
{
    using Plugin.Maui.Audio;

    public interface IAudioService
    {
        void PlayMusic();
        void SetVolumeMusic(float volume);
        bool IsMusicPlaying();
        float Volume { get; set; }
    }

    public class AudioService(IAudioManager audioManager) : IAudioService
    {
        private readonly IAudioManager _audioManager = audioManager;
        private IAudioPlayer? _player;

        public async void PlayMusic()
        {
            if (_player == null)
            {
                _player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ambiantsong.mp3"));
                _player.Loop = true;
            }

            if (!_player.IsPlaying)
            {
                _player.Play();
            }
        }

        public void SetVolumeMusic(float volume)
        {
            _player!.Volume = volume;
        }
        public bool IsMusicPlaying()
        {
            return _player?.IsPlaying ?? false;
        }

        public float Volume
        {
            get => (float)(_player?.Volume ?? 0);
            set
            {
                if (_player != null)
                {
                    _player.Volume = value;
                }
            }
        }
    }

}
