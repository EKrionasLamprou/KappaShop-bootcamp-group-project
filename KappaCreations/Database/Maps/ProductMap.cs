using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasRequired(e => e.Design)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.DesignId);

            HasOptional(e => e.BackDesign);

            HasRequired(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            HasRequired(e => e.Designer)
               .WithMany(e => e.Products)
               .HasForeignKey(e => e.DesignerId)
               .WillCascadeOnDelete(false);

            HasMany(e => e.UsersUpvoted)
                .WithMany(e => e.UpvotedProducts)
                .Map(e =>
                {
                    e.ToTable("UserProductUpvotes");
                });

            Ignore(e => e.Upvotes);
        }
    }
}