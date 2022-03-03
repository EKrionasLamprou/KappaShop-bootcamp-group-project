using KappaShop.Models;
using System.Data.Entity;

namespace KappaShop.Database
{
    partial class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopContext() : base("ShopConnection")
        {
            string a = new string('A',)
        }
    }
}