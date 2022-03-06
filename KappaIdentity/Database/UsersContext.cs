using KappaIdentity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KappaIdentity.Database
{
    class UsersContext : IdentityDbContext<User>
    {
        private UsersContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UsersContext Create() => new UsersContext();
    }
}