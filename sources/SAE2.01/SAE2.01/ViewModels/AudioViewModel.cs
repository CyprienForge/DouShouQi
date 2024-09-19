using System.ComponentModel;
using System.Runtime.CompilerServices;
using SAE2._01.Services;

namespace SAE2._01.ViewModels
{
    public class AudioViewModel : INotifyPropertyChanged
    {
        private readonly IAudioService _audioService;
        private float _volume;
        public AudioViewModel()
        {
        }

        public AudioViewModel(IAudioService audioService)
        {
            _audioService = audioService;
            _volume = _audioService.Volume;
        }

        public float Volume
        {
            get => _volume;
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    _audioService.Volume = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }
}
