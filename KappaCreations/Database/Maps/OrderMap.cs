using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            HasRequired(e => e.BillingAddress)
                .WithMany()
                .HasForeignKey(e => e.BillingAddressId);

            Property(e => e.OrderStatus)
                .HasColumnName("Status")
                .HasColumnType("int")
                .IsRequired();

            HasMany(e => e.Items);

            Ignore(e => e.ItemsCount);

            Ignore(e => e.TotalCost);
        }
    }
}