namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a <see cref="Design"/> text on a 2D plane.
    /// </summary>
    public class Text : IEntity, I2DComponent
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Size Size { get; set; }
        public Colour Colour { get; set; }
        /// <summary>
        /// The text content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Represents the <see cref="Font"/> of the <see cref="Text"/>.
        /// </summary>
        public Font Font { get; set; }
        
    }
}