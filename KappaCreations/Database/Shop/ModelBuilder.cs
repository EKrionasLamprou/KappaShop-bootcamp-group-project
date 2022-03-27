using KappaCreations.Database.Maps;
using System.Data.Entity;

namespace KappaCreations.Database
{
    public partial class ShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                        .Add(new ImageMap())
                        .Add(new TextMap())
                        .Add(new ProductMap());
        }
    }
}