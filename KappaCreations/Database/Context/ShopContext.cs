using KappaCreations.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KappaCreations.Database
{
    public partial class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext() : base("KappaShop", throwIfV1Schema: false)
        {
            System.Data.Entity.Database.SetInitializer(new ShopDbInitializer());
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }

        public static ShopContext Create() => new ShopContext();
    }
}