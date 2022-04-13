using System.Globalization;

namespace KappaCreations.Models
{
    public class Colour : IColour
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        public Colour() => (Value, Alpha) = (0, 0);
        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="hex">A hexadecimal value that represents a colour.
        /// A hash at the beginning of the string is not required.</param>
        /// <param name="alpha">The opacity of the colour.
        /// 1.0 represents full opacity, while 0.0 full transparency.</param>
        public Colour(string hex, double alpha = 1.0)
        {
            Value = int.Parse(hex.TrimStart('#'), NumberStyles.AllowHexSpecifier);
            Alpha = alpha;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="value">An integer that represents a colour.</param>
        /// <param name="alpha">The opacity of the colour.
        /// 1.0 represents full opacity, while 0.0 full transparency.</param>
        public Colour(int value, double alpha = 1.0)
            => (Value, Alpha) = (value, alpha);
        /// <summary>
        /// Initializes a new instance of the <see cref="Colour"/> class.
        /// </summary>
        /// <param name="red">The value of red, represented as a byte.</param>
        /// <param name="green">The value of green, represented as a byte.</param>
        /// <param name="blue">The value of blue, represented as a byte.</param>
        /// <param name="alpha">Represents the opacity of the colour.
        /// 1.0 represents full opacity, while 0.0 full transparency.</param>
        public Colour(byte red, byte green, byte blue, double alpha = 1.0)
        {
            Value = 65536 * red + 256 * green + blue;
            Alpha = alpha;
        }
        #endregion

        public int Value { get; set; }
        public double Alpha { get; set; }
        public byte Red
        {
            get => (byte)(Value / 256 / 256 % 256);
        }
        public byte Green
        {
            get => (byte)(Value / 256 % 256);
        }
        public byte Blue
        {
            get => (byte)(Value % 256);
        }
        public (byte Red, byte Green, byte Blue) RGB
        {
            get => (Red, Green, Blue);
        }
        public (byte Red, byte Green, byte Blue, double Alpha) RGBA
        {
            get
            {
                var (Red, Green, Blue) = RGB;
                return (Red, Green, Blue, Alpha);
            }
        }

        public string Hex { get => Value.ToString("X2"); }

        /// <summary>
        /// Gets a new colour by converting a hexadecimal value.
        /// </summary>
        /// <param name="hex">The hexadecimal value that represents a colour.</param>
        public static Colour GetByHex(string hex)
            => new Colour(int.Parse(hex.TrimStart('#'), NumberStyles.AllowHexSpecifier));

        /// <summary>
        /// A string that represents the current colour.
        /// </summary>
        /// <returns>The hexadecimal value of the colour as a string.</returns>
        public override string ToString() => '#' + Hex;
    }
}