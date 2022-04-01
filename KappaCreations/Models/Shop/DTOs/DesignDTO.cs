using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class DesignDTO : IDataTransferObject<Design>
    {
        public int? Id { get; set; }

        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<TextDTO> Texts { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Design Map() => new Design
        {
            Images = Images.Select(image => image.Map()).ToList(),
            Texts = Texts.Select(text => text.Map()).ToList(),
        };

        #region MapFrom
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="DesignDTO"/>.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Design"/> entity.</param>
        /// <param name="camelCase"><see langword="true"/> for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>An object with <see cref="DesignDTO"/> properties.</returns>
        public static object MapFrom(Design design, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(design)
                         : MapFromWithPascalCase(design);
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="DesignDTO"/>.
        /// </summary>
        /// <param name="comments">A collection of <see cref="Text"/> entities.</param>
        /// <param name="camelCase">for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>A collection of objects with <see cref="DesignDTO"/> properties.</returns>
        public static object MapFrom(IEnumerable<Design> designs, bool camelCase = false)
            => camelCase ? designs.Select(design => MapFromWithCamelCase(design))
                         : designs.Select(design => MapFromWithPascalCase(design));

        private static object MapFromWithPascalCase(Design design)
            => new
            {
                Id = design.Id,
                Images = ImageDTO.MapFrom(design.Images),
                Texts = TextDTO.MapFrom(design.Texts),
            };

        private static object MapFromWithCamelCase(Design design)
            => new
            {
                id = design.Id,
                images = ImageDTO.MapFrom(design.Images, true),
                texts = TextDTO.MapFrom(design.Texts, true),
            };
        #endregion
    }
}