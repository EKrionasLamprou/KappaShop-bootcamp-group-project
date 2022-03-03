namespace KappaShop.Models
{
    /// <summary>
    /// Represents a point on the x and y axes on a 2D space.
    /// </summary>
    struct Position
    {
        /// <summary>
        /// Initializes a new <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">Represents the position on the x axis on a 2D space.</param>
        /// <param name="y">Represents the position on the y axis on a 2D space.</param>
        public Position(float x, float y) => (X, Y) = (x, y);

        /// <summary>
        /// Represents the position on the x axis on a 2D space.
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Represents the position on the y axis on a 2D space.
        /// </summary>
        public float Y { get; set; }
    }
}