using KappaCreations.Models;
using System.Data.Entity;

namespace KappaCreations.Database
{
    public class ShopDbInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            db.ProductCategories.AddRange(new ProductCategory[]
            {
                new ProductCategory { Title = "Ashtrays", Price = 8 },
                new ProductCategory { Title = "Bags", Price = 10 },
                new ProductCategory { Title = "Bed Sheets", Price = 30 },
                new ProductCategory { Title = "Canvas", Price = 20 },
                new ProductCategory { Title = "Door Mats", Price = 10 },
                new ProductCategory { Title = "Hoodies", Price = 30 },
                new ProductCategory { Title = "Magnets", Price = 5 },
                new ProductCategory { Title = "Mousepads", Price = 7 },
                new ProductCategory { Title = "Mugs", Price = 7 },
                new ProductCategory { Title = "Phone Cases", Price = 20 },
                new ProductCategory { Title = "Pillows", Price = 20 },
                new ProductCategory { Title = "Plates", Price = 10 },
                new ProductCategory { Title = "T-Shirts", Price = 15 },
                new ProductCategory { Title = "Thermos Bottles", Price = 10 },
                new ProductCategory { Title = "Tissues", Price = 3 },
            });

            base.Seed(db);
        }
    }
}