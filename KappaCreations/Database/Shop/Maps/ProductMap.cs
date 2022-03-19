using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasRequired(e => e.ProductCategory)
                .WithMany(e => e.Products);

            HasRequired(e => e.Design);

            HasOptional(e => e.BackDesign);

         /* Saves the id of the ApplicationUser who made the product.
            Can't make it a navigation property, because users are
            stored in a different DbContext. */
            Property(e => e.DesignerId);
        }
    }
}