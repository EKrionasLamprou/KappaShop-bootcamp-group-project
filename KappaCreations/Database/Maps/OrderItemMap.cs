using KappaCreations.Models;
using System.Data.Entity.ModelConfiguration;

namespace KappaCreations.Database.Maps
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            HasRequired(e => e.Product);

            HasRequired(e => e.Order);

            Ignore(e => e.Cost);
        }
    }
}