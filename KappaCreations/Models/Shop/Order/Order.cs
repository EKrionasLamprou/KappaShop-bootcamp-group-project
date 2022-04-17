using System;
using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models
{
    public class Order : IEntity
    {
        public Order()
        {
            SubmitDate = DateTime.Now;
            Items = new HashSet<OrderItem>();
            OrderStatus = OrderStatus.Pending;
        }

        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime SubmitDate { get; set; }
        public int ItemsCount
        {
            get => Items.Select(item => item.Quantity).Sum();
        }
        public double TotalCost
        {
            get => Items.Select(item => item.Cost).Sum();
        }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        
        public ICollection<OrderItem> Items { get; set; }
    }
}