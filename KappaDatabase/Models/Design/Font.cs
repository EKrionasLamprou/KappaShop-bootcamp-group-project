namespace KappaDatabase.Models
{
    /// <summary>
    /// Represents a text font.
    /// </summary>
    public class Font : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The name of the font (for example: Aria).
        /// </summary>
        public string Name { get; set; }
    }
}