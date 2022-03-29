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

        /// <summary>
        /// Returns a <see cref="DesignDTO"/> object, by mapping the properties of
        /// a <see cref="Design"/> object.
        /// </summary>
        /// <param name="design">An instance of a <see cref="Design"/> entity.</param>
        /// <returns>An instance of a <see cref="DesignDTO"/> object.</returns>
        public static DesignDTO MapFrom(Design design) => new DesignDTO
        {
            Id = design.Id,
            Images = design.Images.Select(image => ImageDTO.MapFrom(image)).ToList(),
            Texts = design.Texts.Select(text => TextDTO.MapFrom(text)).ToList(),
        };
    }
}