using System.Collections.Generic;

namespace KappaShop.Models
{
    /// <summary>
    /// Represents a user-made design to be printed on a product.
    /// </summary>
    class Design : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Design"/> class.
        /// </summary>
        public Design()
        {
            Texts = new HashSet<Text>();
            Images = new HashSet<Image>();
        }

        /// <summary>
        /// The entity's primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The <see cref="Text"/> objects that the design contains.
        /// </summary>
        public IEnumerable<Text> Texts { get; set; }
        /// <summary>
        /// The <see cref="Image"/> objects that the design contains.
        /// </summary>
        public IEnumerable<Image> Images { get; set; }
    }
}