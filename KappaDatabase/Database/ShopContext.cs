﻿using KappaDatabase.Models;
using System.Data.Entity;

namespace KappaDatabase.Database
{
    public partial class ShopContext : DbContext
    {
        public ShopContext() : base("KappaShop")
        {
            System.Data.Entity.Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<ShopContext>());
        }

        public DbSet<Design> Designs { get; set; }
        public DbSet<Font> Fonts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}