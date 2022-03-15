using KappaDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KappaDatabase.Database.Maps
{
    public class DesignMap : EntityTypeConfiguration<Design>
    {
        public DesignMap()
        {
            HasMany(e => e.Images)
                .WithRequired(d => d.Design)
                .HasForeignKey(d => d.Design.Id);

            HasMany(e => e.Texts)
               .WithRequired(d => d.Design)
               .HasForeignKey(d => d.Design.Id);

            HasRequired(f => f.FinalProduct)
                .WithRequiredPrincipal(d => d.Design);

        }
    }
}
