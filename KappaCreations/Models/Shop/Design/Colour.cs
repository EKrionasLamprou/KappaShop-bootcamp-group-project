using System.Globalization;

namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a colour that can be expressed as an integer, a hexadecimal or RGB
    /// and includes an alpha value.
    /// </summary>
    public class Colour
    {
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
        /// Represents a colour as an integer.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Represents the opacity of the colour.
        /// 1.0 represents full opacity, while 0.0 full transparency.
        /// </summary>
        public double Alpha { get; set; }
        /// <summary>
        /// Represents a colour with RGB values.
        /// </summary>
        public (byte Red, byte Green, byte Blue) RGB
        {
            get => (byte.Parse(ToString().Substring(0, 2), NumberStyles.AllowHexSpecifier),
                    byte.Parse(ToString().Substring(2, 2), NumberStyles.AllowHexSpecifier),
                    byte.Parse(ToString().Substring(4, 2), NumberStyles.AllowHexSpecifier));
        }
        /// <summary>
        /// Represents a colour with RGBA values.
        /// </summary>
        public (byte Red, byte Green, byte Blue, double Alpha) RGBA
        {
            get
            {
                var (Red, Green, Blue) = RGB;
                return (Red, Green, Blue, Alpha);
            }
        }

        /// <summary>
        /// Gets a new Colour by converting a hexadecimal value.
        /// </summary>
        /// <param name="hex">The hexadecimal value that represents a colour.</param>
        public static Colour GetByHex(string hex)
            => new Colour(int.Parse(hex.TrimStart('#'), NumberStyles.AllowHexSpecifier));

        /// <summary>
        /// A string that represents the current colour.
        /// </summary>
        /// <returns>The hexadecimal value of the colour as a string.</returns>
        public override string ToString() => '#' + Value.ToString("X2");
    }
}