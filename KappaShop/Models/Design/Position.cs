namespace KappaShop.Models
{
    /// <summary>
    /// Represents a point on the x and y axes on a 2D space.
    /// </summary>
    class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">Represents the position on the x axis on a 2D space.</param>
        /// <param name="y">Represents the position on the y axis on a 2D space.</param>
        public Position(double x, double y) => (X, Y) = (x, y);

        /// <summary>
        /// Represents the position on the x axis on a 2D space.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Represents the position on the y axis on a 2D space.
        /// </summary>
        public double Y { get; set; }
    }
}