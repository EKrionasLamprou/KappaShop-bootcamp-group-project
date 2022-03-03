using KappaShop.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaShop.Database.Maps
{
    class FontMap : EntityTypeConfiguration<Font>
    {
        public FontMap()
        {
            Property(e => e.Name)
                .IsRequired();
        }
    }
}