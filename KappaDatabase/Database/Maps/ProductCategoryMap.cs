using KappaDatabase.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaDatabase.Database.Maps
{
    class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Property(e => e.Title)
                .IsRequired();
        }
    }
}