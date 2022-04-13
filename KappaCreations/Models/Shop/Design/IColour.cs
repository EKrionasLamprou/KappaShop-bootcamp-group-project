using System.Globalization;

namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a colour that can be expressed as an integer, a hexadecimal or RGB
    /// and includes an alpha value.
    /// </summary>
    interface IColour
    {
        /// <summary>
        /// Represents a colour as an integer.
        /// </summary>
        int Value { get; set; }

        /// <summary>
        /// Represents the opacity of the colour.
        /// 1.0 represents full opacity, while 0.0 full transparency.
        /// </summary>
        double Alpha { get; set; }

        /// <summary>
        /// The value of red, represented as a byte.
        /// </summary>
        byte Red { get; }

        /// <summary>
        /// The value of green, represented as a byte.
        /// </summary>
        byte Green { get; }

        /// <summary>
        /// The value of blue, represented as a byte.
        /// </summary>
        byte Blue { get; }

        /// <summary>
        /// Represents a colour with RGB values.
        /// </summary>
        (byte Red, byte Green, byte Blue) RGB { get; }

        /// <summary>
        /// Represents a colour with RGBA values.
        /// </summary>
        (byte Red, byte Green, byte Blue, double Alpha) RGBA { get; }

        /// <summary>
        /// Represents a colour as hexadecimal.
        /// </summary>
        string Hex { get; }
    }
}