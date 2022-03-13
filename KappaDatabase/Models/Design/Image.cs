namespace KappaDatabase.Models
{
    /// <summary>
    /// Represents a <see cref="Design"/> image on a 2D plane.
    /// </summary>
    class Image : IEntity, IPlaneComponent
    {
        /// <summary>
        /// The entity's primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The url of the image.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The position of the <see cref="Image"/> on the x and y axes.
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// The width and height of the <see cref="Image"/>.
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The colour of the <see cref="Image"/> represented with RGBA values.
        /// </summary>
        public Colour Colour { get; set; }
    }
}