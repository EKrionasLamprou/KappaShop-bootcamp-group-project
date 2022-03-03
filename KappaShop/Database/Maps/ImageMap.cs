using KappaShop.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaShop.Database.Maps
{
    class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            Ignore(e => e.Position);

            Property(e => e.Position.X)
                .HasColumnName("PositionX")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Position.Y)
                .HasColumnName("PositionY")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Size.Width)
                .HasColumnName("Width")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Size.Height)
                .HasColumnName("Height")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Colour.R)
                .HasColumnName("ColourR")
                .HasColumnType("TinyInt")
                .IsRequired();

            Property(e => e.Colour.G)
                .HasColumnName("ColourG")
                .HasColumnType("TinyInt")
                .IsRequired();

            Property(e => e.Colour.B)
                .HasColumnName("ColourB")
                .HasColumnType("TinyInt")
                .IsRequired();

            Property(e => e.Colour.A)
                .HasColumnName("ColourA")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Data)
                .IsRequired();
        }
    }
}