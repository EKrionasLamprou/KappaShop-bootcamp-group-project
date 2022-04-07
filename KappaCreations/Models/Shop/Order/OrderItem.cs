namespace KappaCreations.Models
{
    /// <summary>
    /// Represents a single cart item of a certain product and quantity.
    /// </summary>
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The quantity of this product in the order.
        /// </summary>
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// The <see cref="Product"/> foreign key.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// The product that was ordered.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The <see cref="OrderId"/> foreign key.
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// The order this cart item belongs to.
        /// </summary>
        public Order Order { get; set; }
    }
}