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

        public Product Map() => new Product
        {
            Design = Design.Map(),
            BackDesign = BackDesign?.Map() ?? null,
            DesignerId = DesignerId,
            CategoryId = Category,
            Upvotes = Upvotes ?? 0,
            Reports = Reports ?? 0,
        };

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