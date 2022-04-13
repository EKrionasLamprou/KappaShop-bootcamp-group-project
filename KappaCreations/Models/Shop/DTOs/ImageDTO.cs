using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class ImageDTO : IDataTransferObject<Image>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDTO"/> class.
        /// </summary>
        public ImageDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDTO"/> class.
        /// </summary>
        /// <param name="image">A <see cref="Image"/> object to be mapped to DTO.</param>
        public ImageDTO(Image image)
        {
            Id = image.Id;
            PosX = image.Position.X;
            PosY = image.Position.Y;
            ZIndex = image.Position.Z;
            SizeWidth = image.Size.Width;
            SizeHeight = image.Size.Height;
            ColourHex = image.Colour.Hex;
            ColourAlpha = image.Colour.Alpha;
            Url = image.Url;
        }

        public int? Id { get; set; }

        // Position
        public double PosX { get; set; }
        public double PosY { get; set; }
        public int ZIndex { get; set; }

        // Size
        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }

        // Colour
        public string ColourHex { get; set; }
        public double ColourAlpha { get; set; }

        public string Url { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Image Map() => new Image
        {
            Position = new Position(PosX, PosY, ZIndex),
            Size = new Size(SizeWidth, SizeHeight),
            Colour = new Colour(ColourHex, ColourAlpha),
            Url = Url,
        };

        /// <summary>
        /// Maps a <see cref="Image"/> instance to an object that matches the properties of a
        /// <see cref="ImageDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="image">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="ImageDTO"/>.</returns>
        public static object MapToCamelCase(Image image) => new
        {
            id = image.Id,
            posX = image.Position.X,
            posY = image.Position.Y,
            zIndex = image.Position.Z,
            sizeWidth = image.Size.Width,
            sizeHeight = image.Size.Height,
            colourHex = image.Colour.Hex,
            colourAlpha = image.Colour.Alpha,
            url = image.Url,
        };
        /// <summary>
        /// Maps a collection of <see cref="Image"/> instances to objects that matche the properties of
        /// <see cref="ImageDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="images">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="ImageDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Image> images)
            => images.Select(image => MapToCamelCase(image));
    }
}