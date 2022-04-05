using System.Collections.Generic;

namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a user-made design to be printed on a product.
    /// </summary>
    public class Design : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Design"/> class.
        /// </summary>
        public Design()
        {
            Texts = new HashSet<Text>();
            Images = new HashSet<Image>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        /// <summary>
        /// The <see cref="Text"/> objects that the design contains.
        /// </summary>
        public ICollection<Text> Texts { get; set; }
        /// <summary>
        /// The <see cref="Image"/> objects that the design contains.
        /// </summary>
        public ICollection<Image> Images { get; set; }
        /// <summary>
        /// A collection of the products that use this design.
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}