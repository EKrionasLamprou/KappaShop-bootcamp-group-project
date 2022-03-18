using KappaCreations.Database;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KappaCreations.RepositoryServices
{
    /// <summary>
    /// Used for handling CRUD operations for the <see cref="Design"/> to the database.
    /// </summary>
    public class DesignRepositoryService : RepositoryService<Design>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignRepositoryService" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public DesignRepositoryService() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignRepositoryService" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public DesignRepositoryService(ShopContext db) : base(db) { }

        public override Design Get(int id)
            => db.Designs.Where(e => e.Id == id)
                         .Include(e => e.Texts)
                         .Include(e => e.Images)
                         .FirstOrDefault();
        public override async Task<Design> GetAsync(int id)
            => await db.Designs.Where(e => e.Id == id)
                               .Include(e => e.Texts)
                               .Include(e => e.Images)
                               .FirstOrDefaultAsync();

        public override IEnumerable<Design> GetAll()
            => db.Designs.Include(e => e.Texts)
                         .Include(e => e.Images)
                         .ToList();
        public override async Task<IEnumerable<Design>> GetAllAsync()
            => await db.Designs.Include(e => e.Texts)
                               .Include(e => e.Images)
                               .ToListAsync();
    }
}