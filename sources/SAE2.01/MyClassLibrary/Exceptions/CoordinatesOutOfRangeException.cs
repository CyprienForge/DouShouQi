namespace MyClassLibrary.Exceptions
{
    /// <summary>
    /// Exception lancée lorsqu'un déplacement vers des coordonnées hors du plateau est effectuée.
    /// </summary>
    public class CoordinatesOutOfRangeException : Exception
    {
        /// <summary>
        /// Obtient la valeur des abscisses
        /// soit la coordonnée 'x'
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// Obtient la valeur des ordonnées
        /// soit la coordonnée 'y'
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe CoordinatesOutOfRange 
        /// avec le message d'erreur et les coordonnées
        /// </summary>
        /// <param name="message"> Message d'erreur lié aux coordonnées inaccessibles </param>
        /// <param name="x"> Coordonnée 'x' </param>
        /// <param name="y"> Coordonnée 'y' </param>
        public CoordinatesOutOfRangeException(string message, int x, int y)
        : base(message)
        {
            this.x = x;
            this.y = y;
        }
    }
}
