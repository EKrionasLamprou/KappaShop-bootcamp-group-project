using KappaShop.Models;
using System.Data.Entity;

namespace KappaShop.Database
{
    partial class ShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                        .Property(e => e.Title)
                        .IsRequired();
        }
    }
}