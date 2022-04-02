namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a <see cref="Design"/> image on a 2D plane.
    /// </summary>
    public class Image : IEntity, I2DComponent
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Size Size { get; set; }
        public Colour Colour { get; set; } 
        /// <summary>
        /// The url of the image.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The <see cref="Models.Design"/> foreign key.
        /// </summary>
        public int DesignId { get; set; }
        /// <summary>
        /// The <see cref="Models.Design"/> this image belongs to.
        /// </summary>
        public Design Design { get; set; }
    }
}