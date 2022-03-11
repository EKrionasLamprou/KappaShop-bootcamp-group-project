using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KappaDatabase.Models.Products
{
    public class Canva : IEntity, IProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProductCategory Category { get; set; }
    }
}
