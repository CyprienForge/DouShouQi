using System.ComponentModel;
using MyClassLibrary.Enum;

namespace MyClassLibrary.Essentials
{
    /// <summary>
    /// Représente une case sur plateau du jeu
    /// </summary>
    public class Case : INotifyPropertyChanged
    {
        /// <summary>
        /// Obtient l'état de la case
        /// True : Occupée, False : Inoccupée
        /// </summary>
        public bool IsOccuped 
        { 
            get => isOccuped;
            set
            {
                if (value == null) return;
                if (value == isOccuped) return;

                isOccuped = value;
                OnPropertyChanged(nameof(IsOccuped));
            }
        }
        private bool isOccuped;

        /// <summary>
        /// Obtient ou  le type de terrain issu de Enum Ground
        /// Type : Standard, Rivière, Piège ou Tanière
        /// </summary>
        public Ground GroundType { get; internal set; }

        public Animal? Inhabitant 
        { 
            get => inhabitant; 
            set
            {
                if(value == inhabitant) return;

                inhabitant = value;
                OnPropertyChanged(nameof(Inhabitant));
            }
        }
        private Animal? inhabitant;

        /// <summary>
        /// Obtient ou non le joueur qui occupe la case
        /// </summary>
        public Player? Habitant { get; private set; }

        public string Color 
        { 
            get => color; 
            set
            {
                if (value == null) return;
                if (value == color) return;

                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private string color;
        public int Id { get; private set; }

        /// <summary>
        /// Initialise une case du plateau du jeu avec le type de terrain
        /// et l'état de celle-ci
        /// </summary>
        /// <param name="type"> Type de terrain </param>
        /// <param name="isOccuped"> Etat de la case </param>
        public Case(Ground type, bool isOccuped, int id)
        {
            GroundType = type;
            IsOccuped = isOccuped;
            Id = id;
        }

        public Case(Ground type, bool isOccuped, string color, int id)
        {
            GroundType = type;
            IsOccuped = isOccuped;
            Color = color;
            Id = id;
        }

        /// <summary>
        /// Initialise une case du plateau du jeu avec le type de terrain,
        /// l'état de celle-ci et le joueur occupant
        /// </summary>
        /// <param name="type"> Type de terrain </param>
        /// <param name="isOccuped"> Etat de la case </param>
        /// <param name="owner"> Joueur occupant </param>
        /// <param name="color"> Joueur occupant </param>
        /// <param name="id"> Joueur occupant </param>
        public Case(Ground type, bool isOccuped, Player owner, string color, int id)
        {
            GroundType = type;
            IsOccuped = isOccuped;
            Habitant = owner;
            Color = color;
            Id = id;
        }

        /// <summary>
        /// Initialise une case du plateau du jeu avec le type de terrain,
        /// l'état de celle-ci, l'animal et le joueur occupant
        /// </summary>
        /// <param name="type"> Type de terrain </param>
        /// <param name="isOccuped"> Etat de la case </param>
        /// <param name="inhabitant"> Animal occupant </param>
        /// <param name="owner"> Joueur occupant </param>
        public Case(Ground type, bool isOccuped, Animal inhabitant, Player owner, int id)
        {
            GroundType = type;
            IsOccuped = isOccuped;
            Inhabitant = inhabitant;
            Habitant = owner;
            Id = id;
        }

        /// <summary>
        /// Initialise une case du plateau du jeu avec le type de terrain,
        /// l'état de celle-ci et l'animal occupant
        /// </summary>
        /// <param name="type"> Type de terrain </param>
        /// <param name="isOccuped"> Etat de la case </param>
        /// <param name="inhabitant"> Animal occupant </param>
        public Case(Ground type, bool isOccuped, Animal inhabitant, int id)
        {
            GroundType = type;
            IsOccuped = isOccuped;
            Inhabitant = inhabitant;
            Id = id;
        }

        /// <summary>
        /// Événement déclenché lorsqu'une propriété de l'objet change
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Méthode appelée lorsqu'une propriété de l'objet change
        /// </summary>
        /// <param name="propertyName"> Nom de la propriété qui a changé </param>
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Retourne une chaîne de caractères qui représente l'objet
        /// </summary>
        /// <returns> Chaîne de caractères représentant l'objet </returns>
        public override string? ToString()
        {
            if (Inhabitant != null)
            {
                return Inhabitant.ToString();
            }
            return string.Empty;
        }

    }
}
