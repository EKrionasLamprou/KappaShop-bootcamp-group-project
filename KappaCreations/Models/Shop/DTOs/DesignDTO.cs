using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class DesignDTO : IDataTransferObject<Design>
    {
        public int? Id { get; set; }

        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<TextDTO> Texts { get; set; }

        public Design Map() => new Design
        {
            Images = Images.Select(image => image.Map()).ToList(),
            Texts = Texts.Select(text => text.Map()).ToList(),
        };

        public static DesignDTO MapFrom(Design design) => new DesignDTO
        {
            Id = design.Id,
            Images = design.Images.Select(image => ImageDTO.MapFrom(image)).ToList(),
            Texts = design.Texts.Select(text => TextDTO.MapFrom(text)).ToList(),
        };
    }
}