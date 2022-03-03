namespace KappaShop.Models
{
    /// <summary>
    /// Represents a colour with RGBA values.
    /// </summary>
    struct Colour
    {
        /// <summary>
        /// Initializes a new <see cref="Colour"/> struct.
        /// </summary>
        /// <param name="r">The red colour value.</param>
        /// <param name="g">The green colour value.</param>
        /// <param name="b">The blue colour value.</param>
        /// <param name="a">The blue colour value.</param>
        public Colour(byte r, byte g, byte b, double a = 1)
            => (R, G, B, A) = (r, g, b, a);
        /// <summary>
        /// Represents the intensity of the red colour.
        /// </summary>
        public byte R { get; set; }
        /// <summary>
        /// Represents the intensity of the green colour.
        /// </summary>
        public byte G { get; set; }
        /// <summary>
        /// Represents the intensity of the blue colour.
        /// </summary>
        public byte B { get; set; }
        /// <summary>
        /// Represents The alpha channel of the colour as a number between 0.0 
        /// (fully transparent) and 1.0 (full opacity).
        /// </summary>
        public double A { get; set; }
    }
}