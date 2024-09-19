namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour un combat
    /// </summary>
    public class FightedEventArgs
    {
        /// <summary>
        /// Obtient la force de l'animal à l'origine du combat
        /// </summary>
        public int Animal { get; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe FightedEventArgs avec la force de l'animal
        /// </summary>
        /// <param name="animal"> Force de l'animal à l'origine du combat</param>
        public FightedEventArgs(int animal)
        {
            Animal = animal;
        }
    }
}
