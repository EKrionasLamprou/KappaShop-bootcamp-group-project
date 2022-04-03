using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KappaCreations.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Products = new HashSet<Product>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }

        public BillingAddress BillingAddress { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public ICollection<Product> Products { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            => await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    }
}