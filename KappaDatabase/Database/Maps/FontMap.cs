using KappaDatabase.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaDatabase.Database.Maps
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