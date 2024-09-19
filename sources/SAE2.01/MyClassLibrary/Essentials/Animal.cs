namespace MyClassLibrary.Essentials
{

    /// <summary>
    /// Représente un animal du jeu
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Obtient l'identifiant de l'animal
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Obtient le joueur propriétaire de l'animal
        /// </summary>
        public Player PlayerOwner { get; private set; }

        /// <summary>
        /// Obtient la force de l'animal
        /// </summary>
        public int Strength { get; private set; }

        /// <summary>
        /// Obtient la capacité ou non de l'animal à pouvoir sauter au-dessus de la rivière
        /// </summary>
        public bool JumpRiver { get; private set; }

        /// <summary>
        /// Obtient la capacité ou non de l'animal à pouvoir traverser une rivière
        /// </summary>
        public bool WalkRiver { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de Animal avec son joueur propriétaire, sa force, 
        /// sa capacité ou non de sauter au-dessus de la rivière et 
        /// sa capacité ou non à pouvoir traverser une rivière
        /// </summary>
        /// <param name="playerOwner"> Joueur propriétaire de l'animal </param>
        /// <param name="strength"> Force de l'animal </param>
        /// <param name="jumpRiver"> Capacité ou non de l'animal à pouvoir sauter au-dessus de la rivière </param>
        /// <param name="walkRiver"> Capacité ou non de l'animal à pouvoir traverser une rivière </param>
        public Animal(Player playerOwner, int strength, bool jumpRiver, bool walkRiver)
        {
            PlayerOwner = playerOwner;
            Strength = strength;
            JumpRiver = jumpRiver;
            WalkRiver = walkRiver;
        }

        /// <summary>
        /// Retourne une chaîne de caractères qui représente l'animal
        /// </summary>
        /// <returns> Une chaîne de caractères représentant l'animal </returns>
        public override string ToString()
        {
            return Strength.ToString() + " | " + PlayerOwner.Name;
        }
    }
}
