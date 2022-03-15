using KappaCreations.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KappaDatabase.Models.MainClass
{
    public class FinalProduct
    {
        public int Id { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Design Design { get; set; }
        //public ApplicationUser User { get; set; }

    }
}
