using KappaDatabase.Database;
using System.Data.Entity.Migrations;

namespace KappaDatabase.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopContext context) { }
    }
}
