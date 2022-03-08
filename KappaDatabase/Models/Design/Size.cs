namespace KappaDatabase.Models
{
    /// <summary>
    /// Represents the width and height of a 2D shape.
    /// </summary>
    class Size
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="size">The size for both the width and height of the 2D shape.</param>
        public Size(double size) => (Width, Height) = (size, size);
        /// <summary>
        /// Initializes a new <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The size of the width and height of the 2D shape.</param>
        /// <param name="height">The size of the height and height of the 2D shape.</param>
        public Size(double width, double height) => (Width, Height) = (width, height);

        /// <summary>
        /// The size of the width and height of the 2D shape.
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// The size of the height and height of the 2D shape.
        /// </summary>
        public double Height { get; set; }
    }
}