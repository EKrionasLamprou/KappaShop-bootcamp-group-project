using System.Collections.Generic;

namespace KappaDatabase.Models
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

        /// <summary>
        /// A string that represents the category's title.
        /// </summary>
        /// <returns>The category title.</returns>
        public override string ToString() => Title;
    }
}