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

            /* Saves the id of the ApplicationUser who made the comment.
            Can't make it a navigation property, because users are
            stored in a different DbContext. */
            Property(e => e.UserId);

            HasRequired(e => e.Product)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ProductId);
        }
    }
}