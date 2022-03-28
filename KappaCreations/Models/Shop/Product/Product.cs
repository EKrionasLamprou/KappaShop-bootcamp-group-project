using System.Collections.Generic;

namespace KappaCreations.Models
{
    public class Product : IEntity
    {
        /// <summary>
        /// Initiates a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product() 
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }
        /// <summary>
        /// The category the <see cref="Product"/> belongs to.
        /// </summary>
        public ProductCategory Category
        {
            get => Utilities.GetProductCategory(CategoryId);
        }

        /// <summary>
        /// Represents a user-made design, printed on the product.
        /// </summary>
        public Design Design { get; set; }
        /// <summary>
        /// Represents a user-made design, printed on the back side of the product. 
        /// <see langword="null"/> by default.
        /// </summary>
        public Design BackDesign { get; set; }

        /// <summary>
        /// Represents the id of the <see cref="ApplicationUser"/> who made the design.
        /// </summary>
        public int DesignerId { get; set; }

        /// <summary>
        /// Represents the number of upvotes the product has received from users.
        /// </summary>
        public int Upvotes { get; set; }

        /// <summary>
        /// Represents the number of reports the product has received from users.
        /// </summary>
        public int Reports { get; set; }

        public ICollection<Comment> Comments { get; set; }

        // To add:
        // Size for clothes
    }
}