using KappaCreations.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KappaCreations.Database
{
    public class UsersContext : IdentityDbContext<ApplicationUser>
    {
        public UsersContext() : base("KappaUsers", throwIfV1Schema: false)
        {
        }

        public static UsersContext Create() => new UsersContext();
    }
}