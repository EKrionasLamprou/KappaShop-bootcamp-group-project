using System.ComponentModel.DataAnnotations.Schema;

namespace KappaCreations.Models
{
    public class BillingAddress : IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
    }
}