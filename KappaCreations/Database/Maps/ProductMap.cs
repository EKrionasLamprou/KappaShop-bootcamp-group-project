using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasRequired(e => e.Design);

            HasOptional(e => e.BackDesign);

            HasRequired(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}