using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a category that products belong to.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategory"/> class.
        /// </summary>
        public ProductCategory(string title, double price, ProductCategory supercategory = null)
        {
            Title = title;
            Price = price;
            SuperCategory = supercategory;
        }

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
        /// The category this category belongs to.
        /// </summary>
        public ProductCategory SuperCategory { get; set; }
        /// <summary>
        /// The categories that belong to this category.
        /// </summary>
        public ICollection<ProductCategory> SubCategories
        {
            get => Consonants.PRODUCT_CATEGORIES
                             .Where(c => c.SuperCategory == this)
                             .ToList();
        }

        /// <summary>
        /// A string that represents the category's title.
        /// </summary>
        /// <returns>The category title.</returns>
        public override string ToString() => Title;
    }
}