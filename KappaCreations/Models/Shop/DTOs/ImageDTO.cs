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

        public Image Parse() => new Image
        {
            Position = new Position(PosX, PosY, ZIndex),
            Size = new Size(SizeWidth, SizeHeight),
            Colour = Colour.GetByHex(ColourHex),
            Url = Url,
        };
    }
}