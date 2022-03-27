using KappaCreations.Models;
using System.Data.Entity;

namespace KappaCreations.Database
{
    public partial class ShopContext : DbContext
    {
        public ShopContext() : base("KappaShop")
        {
            System.Data.Entity.Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<ShopContext>());
        }

        public DbSet<Design> Designs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}