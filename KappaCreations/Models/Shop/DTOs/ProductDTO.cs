using System.Collections.Generic;
using System.Linq;

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

        #region MapFrom
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Product"/> entity.</param>
        /// <param name="camelCase"><see langword="true"/> for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>An object with <see cref="ProductDTO"/> properties.</returns>
        public static object MapFrom(Product product, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(product)
                         : MapFromWithPascalCase(product);
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="comments">A collection of <see cref="Text"/> entities.</param>
        /// <param name="camelCase">for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>A collection of objects with <see cref="ProductDTO"/> properties.</returns>
        public static object MapFrom(IEnumerable<Product> products, bool camelCase = false)
            => camelCase ? products.Select(product => MapFromWithCamelCase(product))
                         : products.Select(product => MapFromWithPascalCase(product));

        private static object MapFromWithPascalCase(Product product)
            => new
            {
                Id = product.Id,
                Design = DesignDTO.MapFrom(product.Design),
                BackDesign = product.BackDesign is null ?
                            null : DesignDTO.MapFrom(product.BackDesign),
                DesignerId = product.CategoryId,
                Upvotes = product.Upvotes,
                Reports = product.Reports,
            };

        private static object MapFromWithCamelCase(Product product)
            => new
            {
                id = product.Id,
                design = DesignDTO.MapFrom(product.Design, true),
                backDesign = product.BackDesign is null ?
                            null : DesignDTO.MapFrom(product.BackDesign, true),
                designerId = product.CategoryId,
                upvotes = product.Upvotes,
                reports = product.Reports,
            };
        #endregion
    }
}