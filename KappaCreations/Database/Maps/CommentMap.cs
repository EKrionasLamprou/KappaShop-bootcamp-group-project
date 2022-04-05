using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            Property(e => e.Content)
            .HasMaxLength(600)
            .HasColumnName("Content")
            .IsRequired();

            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            HasRequired(e => e.Product)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ProductId);
        }
    }
}