namespace KappaShop.Models
{
    interface IPlaneComponent
    {
        /// <summary>
        /// The position of the <see cref="IPlaneComponent"/> on the x and y axes.
        /// </summary>
        Position Position { get; set; }
        /// <summary>
        /// The width and height of the <see cref="IPlaneComponent"/>.
        /// </summary>
        Size Size { get; set; }
        /// <summary>
        /// The colour of the <see cref="IPlaneComponent"/> represented with RGBA values.
        /// </summary>
        Colour Colour { get; set; }
    }
}