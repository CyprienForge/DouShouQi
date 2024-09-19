namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour un déplacement
    /// </summary>
    public class MovedEventArgs
    {
        /// <summary>
        /// Obtient la coordonnée X du déplacement
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Obtient la coordonnée Y du déplacement
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe MovedEventArgs avec les coordonnées du déplacement
        /// </summary>
        /// <param name="x">La coordonnée X du déplacement</param>
        /// <param name="y">La coordonnée Y du déplacement</param>
        public MovedEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
