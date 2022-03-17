//using KappaDatabase.Models;
//using System.Data.Entity.ModelConfiguration;

//namespace KappaDatabase.Database.Maps
//{
//    public class DesignMap : EntityTypeConfiguration<Design>
//    {
//        public DesignMap()
//        {
//            HasMany(e => e.Images)
//                .WithRequired(d => d.Design)
//                .HasForeignKey(d => d.Design.Id);

//            HasMany(e => e.Texts)
//               .WithRequired(d => d.Design)
//               .HasForeignKey(d => d.Design.Id);

//            HasRequired(f => f.FinalProduct)
//                .WithRequiredPrincipal(d => d.Design);
//        }
//    }
//}
