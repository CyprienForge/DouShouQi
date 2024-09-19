namespace MyClassLibrary.Enum
{   
    /// <summary>
    /// Enumération représentant les différents types de terrain
    /// </summary>
    public enum Ground
    {
        /// <summary>
        /// Type : Standard
        /// Aucune particularité
        /// </summary>
        GROUND = 0,

        /// <summary>
        /// Type : Rivière
        /// Terrain uniquement accessible par les rats
        /// </summary>
        RIVER = 1,

        /// <summary>
        /// Type : Piège
        /// Terrain ayant la particularité de réduire les défenses
        /// </summary>
        TRAP = 2,

        /// <summary>
        /// Type : Tanière
        /// Terrain représentant la clé de la victoire
        /// </summary>
        DEN = 3
    }
}
