using System;
using System.Collections.Generic;

namespace KappaCreations.Models
{
    public class Order : IEntity
    {
        public Order()
        {
            SubmitDate = DateTime.Now;
            Items = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }

        public DateTime SubmitDate { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}