namespace KappaCreations.Models.Shop.DTOs
{
    public class ProductDTO : IDataTransferObject<Product>
    {
        public int? Id { get; set; }
        public DesignDTO Design { get; set; }
        public DesignDTO BackDesign { get; set; }
        public int Category { get; set; }
        public int DesignerId { get; set; }
        public int? Upvotes { get; set; }
        public int? Reports { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Product Map() => new Product
        {
            Design = Design.Map(),
            BackDesign = BackDesign?.Map() ?? null,
            DesignerId = DesignerId,
            CategoryId = Category,
            Upvotes = Upvotes ?? 0,
            Reports = Reports ?? 0,
        };

        /// <summary>
        /// Returns a <see cref="ProductDTO"/> object, by mapping the properties of
        /// a <see cref="Product"/> object.
        /// </summary>
        /// <param name="product">An instance of a <see cref="Product"/> entity.</param>
        /// <returns>An instance of a <see cref="ProductDTO"/> object.</returns>
        public static ProductDTO MapFrom(Product product) => new ProductDTO
        {
            Id = product.Id,
            Design = DesignDTO.MapFrom(product.Design),
            BackDesign = product.BackDesign is null ?
                            null : DesignDTO.MapFrom(product.BackDesign),
            DesignerId = product.CategoryId,
            Upvotes = product.Upvotes,
            Reports = product.Reports,
        };
    }
}