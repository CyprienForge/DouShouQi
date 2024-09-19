namespace MyClassLibrary.Events
{
    /// <summary>
    /// Représente les arguments d'événement pour le changement de case
    /// </summary>
    public class CaseChangedEventArgs
    {
        /// <summary>
        /// Obtient la coordonnée X de la case avant le changement
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Obtient la coordonnée Y de la case avant le changement
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Obtient la coordonnée X de la destination de la case après le changement
        /// </summary>
        public int XDest { get; set; }

        /// <summary>
        /// Obtient la coordonnée Y de la destination de la case après le changement
        /// </summary>
        public int YDest { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe CaseChangedEventArgs.
        /// </summary>
        /// <param name="x">La coordonnée X de la case avant le changement.</param>
        /// <param name="y">La coordonnée Y de la case avant le changement.</param>
        /// <param name="xDest">La coordonnée X de la destination de la case après le changement</param>
        /// <param name="yDest">La coordonnée Y de la destination de la case après le changement</param>
        public CaseChangedEventArgs(int x, int y, int xDest, int yDest)
        {
            X = x;
            Y = y;
            XDest = xDest;
            YDest = yDest;
        }
    }
}
