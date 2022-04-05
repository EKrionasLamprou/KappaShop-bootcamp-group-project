using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class ProductDTO : IDataTransferObject<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDTO"/> class.
        /// </summary>
        public ProductDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDTO"/> class.
        /// </summary>
        /// <param name="product">A <see cref="Product"/> object to be mapped to DTO.</param>
        public ProductDTO(Product product)
        {
            Id = product.Id;
            Design = new DesignDTO(product.Design);
            BackDesign = product.BackDesign is null ?
                            null : new DesignDTO(product.BackDesign);
            DesignerId = product.DesignerId;
            Category = product.CategoryId;
            Upvotes = product.Upvotes;
            Reports = product.Reports;
        }

        public int? Id { get; set; }
        public DesignDTO Design { get; set; }
        public DesignDTO BackDesign { get; set; }
        public int Category { get; set; }
        public string DesignerId { get; set; }
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
        /// Maps a <see cref="Product"/> instance to an object that matches the properties of a
        /// <see cref="ProductDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="product">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="ProductDTO"/>.</returns>
        public static object MapToCamelCase(Product product) => new
        {
            id = product.Id,
            design = DesignDTO.MapToCamelCase(product.Design),
            backDesign = product.BackDesign is null ? null
                            : DesignDTO.MapToCamelCase(product.BackDesign),
            designerId = product.CategoryId,
            categoryId = product.CategoryId,
            upvotes = product.Upvotes,
            reports = product.Reports,
        };
        /// <summary>
        /// Maps a collection of <see cref="Product"/> instances to objects that matche the properties of
        /// <see cref="ProductDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="products">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="ProductDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Product> products)
            => products.Select(product => MapToCamelCase(product));
    }
}