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

        public object MapToCamelCase() => new
        {
            id = Id ?? 0,
            posX = PosX,
            posY = PosY,
            zIndex = ZIndex,
            sizeWidth = SizeWidth,
            sizeHeight = SizeHeight,
            colourHex = ColourHex,
            colourAlpha = ColourAlpha,
            url = Url,
        };

        /// <summary>
        /// Returns a <see cref="ImageDTO"/> object, by mapping the properties of
        /// a <see cref="Image"/> object.
        /// </summary>
        /// <param name="image">An instance of a <see cref="Image"/> entity.</param>
        /// <returns>An instance of a <see cref="ImageDTO"/> object.</returns>
        public static ImageDTO MapFrom(Image image) => new ImageDTO
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
    }
}