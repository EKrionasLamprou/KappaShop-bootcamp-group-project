namespace KappaDatabase.Models
{
    /// <summary>
    /// Represents a <see cref="Design"/> text on a 2D plane.
    /// </summary>
    class Text : IEntity, IPlaneComponent
    {
        /// <summary>
        /// The entity's primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The position of the <see cref="Text"/> on the x and y axes.
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// The width and height of the <see cref="Text"/>.
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The colour of the <see cref="Text"/> represented with RGBA values.
        /// </summary>
        public Colour Colour { get; set; }

        /// <summary>
        /// Represents the <see cref="Font"/> of the <see cref="Text"/>.
        /// </summary>
        public Font Font { get; set; }
    }
}