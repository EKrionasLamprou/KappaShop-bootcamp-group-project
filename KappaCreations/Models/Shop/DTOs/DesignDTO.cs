using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class DesignDTO : IDataTransferObject<Design>
    {
        public int? Id { get; set; }

        public ICollection<ImageDTO> Images { get; set; }
        public ICollection<TextDTO> Texts { get; set; }

        public Design Parse() => new Design
        {
            Images = (ICollection<Image>)Images.Select(image => image.Parse()),
            Texts = (ICollection<Text>)Texts.Select(text => text.Parse()),
        };
    }
}