namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a point on the x and y axes on a 2D space.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position() => (X, Y, Z) = (0, 0, 0); 
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">Represents the position on the x axis on a 2D space.</param>
        /// <param name="y">Represents the position on the y axis on a 2D space.</param>
        public Position(double x, double y, int z) => (X, Y, Z) = (x, y, z);

        /// <summary>
        /// Represents the position on the x axis on a 2D space.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Represents the position on the y axis on a 2D space.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Represents the z-index on a 2D space.
        /// </summary>
        public int Z { get; set; }
    }
}