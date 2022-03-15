using KappaDatabase.Models.MainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KappaDatabase.Database.Maps
{
    public class FinalProductMap : EntityTypeConfiguration<FinalProduct>
    {
        public FinalProductMap()
        {

            HasRequired(d => d.Design)
                .WithRequiredPrincipal(f => f.FinalProduct);


            HasRequired(p => p.ProductCategory)
                 .WithRequiredPrincipal(f => f.FinalProduct);




        }
    }
}
