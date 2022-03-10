using Microsoft.AspNet.Identity.EntityFramework;

namespace KappaCreations.Identity
{
    public class UsersContext : IdentityDbContext<ApplicationUser>
    {
        public UsersContext() : base("KappaUsers", throwIfV1Schema: false)
        {
        }

        public static UsersContext Create() => new UsersContext();
    }
}