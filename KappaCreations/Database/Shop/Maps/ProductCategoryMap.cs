using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();

            HasOptional(e => e.SuperCategory)
                .WithMany(e => e.SubCategories);

            HasMany(e => e.Products);

            HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory);
        }
    }
}