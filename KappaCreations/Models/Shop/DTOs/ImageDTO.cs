using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class ImageDTO : IDataTransferObject<Image>
    {
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
            Colour = Colour.GetByHex(ColourHex),
            Url = Url,
        };

        #region MapFrom
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="ImageDTO"/>.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Image"/> entity.</param>
        /// <param name="camelCase"><see langword="true"/> for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>An object with <see cref="ImageDTO"/> properties.</returns>
        public static object MapFrom(Image comment, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(comment)
                         : MapFromWithPascalCase(comment);
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="ImageDTO"/>.
        /// </summary>
        /// <param name="comments">A collection of <see cref="Image"/> entities.</param>
        /// <param name="camelCase">for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>A collection of objects with <see cref="ImageDTO"/> properties.</returns>
        public static object MapFrom(IEnumerable<Image> comments, bool camelCase = false)
            => camelCase ? comments.Select(comment => MapFromWithCamelCase(comment))
                         : comments.Select(comment => MapFromWithPascalCase(comment));

        private static object MapFromWithPascalCase(Image image)
            => new
            {
                Id = image.Id,
                PosX = image.Position.X,
                PosY = image.Position.Y,
                ZIndex = image.Position.Z,
                SizeWidth = image.Size.Width,
                SizeHeight = image.Size.Height,
                ColourHex = image.Colour.ToString(),
                Url = image.Url,
            };

        private static object MapFromWithCamelCase(Image image)
            => new
            {
                id = image.Id,
                posX = image.Position.X,
                posY = image.Position.Y,
                zIndex = image.Position.Z,
                sizeWidth = image.Size.Width,
                sizeHeight = image.Size.Height,
                colourHex = image.Colour.ToString(),
                url = image.Url,
            };
        #endregion
    }
}