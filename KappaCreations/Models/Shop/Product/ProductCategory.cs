using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a category that products belong to.
    /// </summary>
    public class ProductCategory : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategory"/> class.
        /// </summary>
        public ProductCategory()
        {
            SubCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The price of the category products.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The image url of the base product.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The super category foreign key.
        /// </summary>
        public int? SuperCategoryId { get; set; }
        /// <summary>
        /// The category this category belongs to.
        /// </summary>
        public ProductCategory SuperCategory { get; set; }
        /// <summary>
        /// The categories that belong to this category.
        /// </summary>
        public ICollection<ProductCategory> SubCategories { get; set; }
        /// <summary>
        /// The products that belong to this category.
        /// </summary>
        public ICollection<Product> Products { get; set; }

        public override string ToString() => Title;
    }
}