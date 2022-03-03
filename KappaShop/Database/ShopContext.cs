using KappaShop.Models;
using System.Data.Entity;

namespace KappaShop.Database
{
    partial class ShopContext : DbContext
    {
        public ShopContext() : base("ShopConnection") { }

        public DbSet<Design> Designs { get; set; }
        public DbSet<Font> Fonts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Text> Texts { get; set; }
    }
}