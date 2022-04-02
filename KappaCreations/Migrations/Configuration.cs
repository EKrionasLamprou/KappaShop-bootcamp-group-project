using KappaCreations.Database;
using System.Data.Entity.Migrations;

namespace KappaCreations.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}