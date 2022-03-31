using KappaCreations.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace KappaCreations.Database
{
    public partial class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext() : base("KappaShop", throwIfV1Schema: false)
        {
            System.Data.Entity.Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<ShopContext>());
        }

        public DbSet<Design> Designs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BillingAddress> BillingAddresses { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }

        public static ShopContext Create() => new ShopContext();
    }
}