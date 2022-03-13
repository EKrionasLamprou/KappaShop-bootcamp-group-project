using KappaDatabase.Database.Maps;
using System.Data.Entity;

namespace KappaDatabase.Database
{
    public partial class ShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                        .Add(new FontMap())
                        .Add(new ImageMap())
                        .Add(new ProductCategoryMap())
                        .Add(new TextMap());
        }
    }
}