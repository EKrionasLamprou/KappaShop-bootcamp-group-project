using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KappaDatabase.Models.Product
{
    public class Hoodie : IEntity, IProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductCategory Category { get; set; }
    }
}
