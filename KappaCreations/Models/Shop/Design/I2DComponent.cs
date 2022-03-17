namespace KappaCreations.Models
{
    public interface I2DComponent
    {
        /// <summary>
        /// The position of the <see cref="I2DComponent"/> on the x and y axes.
        /// </summary>
        Position Position { get; set; }
        /// <summary>
        /// The width and height of the <see cref="I2DComponent"/>.
        /// </summary>
        Size Size { get; set; }
        /// <summary>
        /// The colour of the <see cref="I2DComponent"/> represented with RGBA values.
        /// </summary>
        Colour Colour { get; set; }
    }
}