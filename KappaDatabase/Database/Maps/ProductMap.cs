using KappaDatabase.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaDatabase.Database.Maps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasRequired(e => e.ProductCategory)
                .WithMany(e => e.Products);

            HasRequired(e => e.Design);

            HasOptional(e => e.BackDesign);
        }
    }
}