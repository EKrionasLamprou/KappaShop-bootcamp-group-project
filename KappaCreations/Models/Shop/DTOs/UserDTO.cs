//using System.Collections.Generic;
//using System.Linq;

//namespace KappaCreations.Models.Shop.DTOs
//{
//    public class UserDTO : IDataTransferObject<ApplicationUser>
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="OrderItemDTO"/> class.
//        /// </summary>
//        public UserDTO() { }
//        /// <summary>
//        /// Initializes a new instance of the <see cref="OrderItemDTO"/> class.
//        /// </summary>
//        /// <param name="cartItem">A <see cref="OrderItem"/> object to be mapped to DTO.</param>
//        public UserDTO(ApplicationUser cartItem)
//        {
            
//        }

//        public string Id { get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 

//        public bool HasId => !string.IsNullOrWhiteSpace(Id);

//        public OrderItem Map() => new OrderItem
//        {
//            Quantity = Quantity,
//            ProductId = ProductId,
//            OrderId = OrderId,
//        };

//        /// <summary>
//        /// Maps a <see cref="OrderItem"/> instance to an object that matches the properties of a
//        /// <see cref="OrderItemDTO"/> using the camelCase style.
//        /// </summary>
//        /// <param name="cartItem">The object to be mapped to camelCase DTO.</param>
//        /// <returns>An object with camelCase properties that match a <see cref="OrderItemDTO"/>.</returns>
//        public static object MapToCamelCase(OrderItem cartItem) => new
//        {
//            id = cartItem.Id,
//            quantity = cartItem.Quantity,
//            productId = cartItem.ProductId,
//            orderId = cartItem.OrderId,
//        };
//        /// <summary>
//        /// Maps a collection of <see cref="OrderItem"/> instances to objects that matche the properties of
//        /// <see cref="OrderItemDTO"/> using the camelCase style.
//        /// </summary>
//        /// <param name="cartItem">The collection of objects to be mapped to camelCase DTO.</param>
//        /// <returns>A collection of objects with camelCase properties that match <see cref="OrderItemDTO"/>.</returns>
//        public static object MapToCamelCase(IEnumerable<OrderItem> cartItems)
//            => cartItems.Select(cartItem => MapToCamelCase(cartItem));
//    }
//}