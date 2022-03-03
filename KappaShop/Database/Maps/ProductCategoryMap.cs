using KappaShop.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaShop.Database.Maps
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