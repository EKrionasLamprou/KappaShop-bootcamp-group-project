using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class DesignDTO : IDataTransferObject<Design>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDTO"/> class.
        /// </summary>
        public DesignDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignDTO"/> class.
        /// </summary>
        /// <param name="design">A <see cref="Design"/> object to be mapped to DTO.</param>
        public DesignDTO(Design design)
        {
            Id = design.Id;
            Images = design.Images.Select(image => new ImageDTO(image));
            Texts = design.Texts.Select(text => new TextDTO(text));
        }

        public int? Id { get; set; }

        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<TextDTO> Texts { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Design Map() => new Design
        {
            Images = Images.Select(image => image.Map()).ToList(),
            Texts = Texts.Select(text => text.Map()).ToList(),
        };

        /// <summary>
        /// Maps a <see cref="Design"/> instance to an object that matches the properties of a
        /// <see cref="DesignDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="design">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="DesignDTO"/>.</returns>
        public static object MapToCamelCase(Design design) => new
        {
            id = design.Id,
            images = ImageDTO.MapToCamelCase(design.Images),
            texts = TextDTO.MapToCamelCase(design.Texts),
        };
        /// <summary>
        /// Maps a collection of <see cref="Design"/> instances to objects that matche the properties of
        /// <see cref="DesignDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="designs">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="DesignDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Design> designs)
            => designs.Select(design => MapToCamelCase(design));
    }
}