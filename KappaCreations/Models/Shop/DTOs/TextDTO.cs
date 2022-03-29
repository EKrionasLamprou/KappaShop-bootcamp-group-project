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

        /// <summary>
        /// Returns a <see cref="TextDTO"/> object, by mapping the properties of
        /// a <see cref="Text"/> object.
        /// </summary>
        /// <param name="text">An instance of a <see cref="Text"/> entity.</param>
        /// <returns>An instance of a <see cref="TextDTO"/> object.</returns>
        public static TextDTO MapFrom(Text text) => new TextDTO
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
    }
}