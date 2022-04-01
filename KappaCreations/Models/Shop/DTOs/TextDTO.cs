using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class TextDTO : IDataTransferObject<Text>
    {
        public int? Id { get; set; }

        // Position
        public double PosX { get; set; } = 0;
        public double PosY { get; set; } = 0;
        public int ZIndex { get; set; }

        // Size
        public double SizeWidth { get; set; } = 100;
        public double SizeHeight { get; set; } = 100;

        // Colour
        public string ColourHex { get; set; } = "FFFFFF";
        public double ColourAlpha { get; set; } = 1;

        public string Content { get; set; } = string.Empty;
        public int Font { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Text Map() => new Text
        {
            Position = new Position(PosX, PosY, ZIndex),
            Size = new Size(SizeWidth, SizeHeight),
            Colour = Colour.GetByHex(ColourHex),
            Content = Content,
            Font = (Font)Font,
        };

        #region MapFrom
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="TextDTO"/>.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Text"/> entity.</param>
        /// <param name="camelCase"><see langword="true"/> for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>An object with <see cref="TextDTO"/> properties.</returns>
        public static object MapFrom(Text comment, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(comment)
                         : MapFromWithPascalCase(comment);
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="TextDTO"/>.
        /// </summary>
        /// <param name="comments">A collection of <see cref="Text"/> entities.</param>
        /// <param name="camelCase">for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>A collection of objects with <see cref="TextDTO"/> properties.</returns>
        public static object MapFrom(IEnumerable<Text> comments, bool camelCase = false)
            => camelCase ? comments.Select(comment => MapFromWithCamelCase(comment))
                         : comments.Select(comment => MapFromWithPascalCase(comment));

        private static object MapFromWithPascalCase(Text text)
            => new
            {
                Id = text.Id,
                PosX = text.Position.X,
                PosY = text.Position.Y,
                ZIndex = text.Position.Z,
                SizeWidth = text.Size.Width,
                SizeHeight = text.Size.Height,
                ColourHex = text.Colour.ToString(),
                Content = text.Content,
                Font = (int)text.Font,
            };

        private static object MapFromWithCamelCase(Text text)
            => new
            {
                id = text.Id,
                posX = text.Position.X,
                posY = text.Position.Y,
                zIndex = text.Position.Z,
                sizeWidth = text.Size.Width,
                sizeHeight = text.Size.Height,
                colourHex = text.Colour.ToString(),
                content = text.Content,
                font = (int)text.Font,
            };
        #endregion
    }
}