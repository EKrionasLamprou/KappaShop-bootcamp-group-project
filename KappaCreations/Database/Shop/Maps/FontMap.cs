using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
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