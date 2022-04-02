using System.ComponentModel.DataAnnotations.Schema;

namespace KappaCreations.Models
{
    public class PaymentInfo : IEntity
    {
        public int Id { get; set; }
        public long NameOnCard { get; set; }
        public byte ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public short CVV { get; set; }
    }
}