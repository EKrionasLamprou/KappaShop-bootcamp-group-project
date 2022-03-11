namespace KappaDatabase.Models
{
    public interface IProduct
    {
        /// <summary>
        /// The product's title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The category the product belongs to.
        /// </summary>
        ProductCategory Category { get; set; }
    }
}