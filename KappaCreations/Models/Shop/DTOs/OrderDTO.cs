using System;
using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class OrderDTO : IDataTransferObject<Order>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDTO"/> class.
        /// </summary>
        public OrderDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDTO"/> class.
        /// </summary>
        /// <param name="order">An <see cref="Order"/> object to be mapped to DTO.</param>
        public OrderDTO(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            BillingAddressId = order.BillingAddressId;
            SubmitDate = order.SubmitDate.ToString(Constants.DateFormat);
            Items = order.Items.Select(item => new OrderItemDTO(item));
        }

        public int? Id { get; set; }
        public string UserId { get; set; }
        public int BillingAddressId { get; set; }
        public string SubmitDate { get; set; }
        public IEnumerable<OrderItemDTO> Items { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Order Map() => new Order
        {
            Id = Id ?? 0,
            UserId = UserId,
            BillingAddressId = BillingAddressId,
            SubmitDate = DateTime.Parse(SubmitDate),
            Items = Items.Select(item => item.Map()).ToList(),
        };

        /// <summary>
        /// Maps a <see cref="Order"/> instance to an object that matches the properties of a
        /// <see cref="OrderDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="item">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="OrderDTO"/>.</returns>
        public static object MapToCamelCase(Order order) => new
        {
            id = order.Id,
            userId = order.UserId,
            billingAddressId = order.BillingAddressId,
            submitDate = order.SubmitDate.ToString(Constants.DateFormat),
            items = OrderItemDTO.MapToCamelCase(order.Items),
        };
        /// <summary>
        /// Maps a collection of <see cref="Order"/> instances to objects that matche the properties of
        /// <see cref="OrderDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="items">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="OrderDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Order> orders)
            => orders.Select(order => MapToCamelCase(order));
    }
}