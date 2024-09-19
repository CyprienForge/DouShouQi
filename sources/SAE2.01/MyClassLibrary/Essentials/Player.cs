using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyClassLibrary.Essentials
{
    /// <summary>
    /// Représente un joueur du jeu
    /// </summary>
    [DataContract]
    public class Player : IEquatable<Player>, INotifyPropertyChanged
    {
        /// <summary>
        /// Obtient l'identifiant du joueur
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Liste des animaux du joueur <see cref="Animal"/>
        /// </summary>
        public List<Animal> Animals { get; private set; }   

        /// <summary>
        /// Obtient le nom du joueur
        /// </summary>
        [DataMember]
        public string Name { 
            get => name; 
            set
            {
                if (string.Equals(value, name)) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Récupère le nom du joueur
        /// </summary>
        private string name;

        /// <summary>
        /// Initialise une nouvelle instance de Joueur avec un identifiant et un nom
        /// en lui fournissant sa liste d'animal <see cref="Animal"/>
        /// </summary>
        /// <param name="id"> Identifiant du joueur </param>
        /// <param name="nom"> Nom du joueur </param>
        public Player(int id, string nom)
        {
            Id = id;
            Name = nom;
            Animals = new List<Animal>() { new Animal(this, 1, false, true), 
                                           new Animal(this, 2, false, false),
                                           new Animal(this, 3, false, false),
                                           new Animal(this, 4, false, false),
                                           new Animal(this, 5, false, false),
                                           new Animal(this, 6, true, false),
                                           new Animal(this, 7, true, false),
                                           new Animal(this, 8, false, false),
            };
        }

        /// <summary>
        /// Événement déclenché lorsqu'une propriété de l'objet change
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Déclenche l'événement PropertyChanged
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
        /// Implémente le protocole d'égalité entre 2 joueurs
        /// </summary>
        /// <param name="other"> Autre joueur </param>
        /// <returns> True : Il s'agit du même joueur, False : Il ne s'agit pas du même joueur </returns>
        public bool Equals(Player? other)
        {
            if(other == null) return false;
            if(ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return Id == other.Id;
        }

        /// <summary>
        /// Retourne le nom du joueur
        /// </summary>
        /// <returns> Nom du joueur </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
