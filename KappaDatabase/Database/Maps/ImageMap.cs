using KappaDatabase.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaDatabase.Database.Maps
{
    class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
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

            Property(e => e.Colour.Value)
                .HasColumnName("Colour")
                .HasColumnType("int")
                .IsRequired();

            Property(e => e.Colour.Alpha)
                .HasColumnName("Alpha")
                .HasColumnType("float")
                .IsRequired();

            Property(e => e.Url)
                .HasMaxLength(3000)
                .IsRequired();
        }
    }
}