using KappaShop.Models;
using System.Data.Entity;

namespace KappaShop.Database
{
    partial class ShopContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Font
            modelBuilder.Entity<Font>()
                        .Property(e => e.Name)
                        .IsRequired();
            #endregion
            #region Image
            modelBuilder.Entity<Image>()
                        .Property(e => e.Position.X)
                        .HasColumnName("PositionX")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Position.Y)
                        .HasColumnName("PositionY")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Size.Width)
                        .HasColumnName("Width")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Size.Height)
                        .HasColumnName("Height")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Colour.R)
                        .HasColumnName("ColourR")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Colour.G)
                        .HasColumnName("ColourG")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Colour.B)
                        .HasColumnName("ColourB")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Colour.A)
                        .HasColumnName("ColourA")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Image>()
                        .Property(e => e.Data)
                        .IsRequired();
            #endregion
            #region ProductCategory
            modelBuilder.Entity<ProductCategory>()
                        .Property(e => e.Title)
                        .IsRequired();
            #endregion
            #region Text
            modelBuilder.Entity<Text>()
                        .Property(e => e.Position.X)
                        .HasColumnName("PositionX")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Position.Y)
                        .HasColumnName("PositionY")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Size.Width)
                        .HasColumnName("Width")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Size.Height)
                        .HasColumnName("Height")
                        .HasColumnType("float")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Colour.R)
                        .HasColumnName("ColourR")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Colour.G)
                        .HasColumnName("ColourG")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Colour.B)
                        .HasColumnName("ColourB")
                        .HasColumnType("TinyInt")
                        .IsRequired();
            modelBuilder.Entity<Text>()
                        .Property(e => e.Colour.A)
                        .HasColumnName("ColourA")
                        .HasColumnType("float")
                        .IsRequired();
            #endregion
        }
    }
}