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
    public class DesignRepository : Repository<Design>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignRepository" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public DesignRepository() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignRepository" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public DesignRepository(ShopContext db) : base(db) { }

        public override DbSet<Design> Set { get => db.Designs; }

        public override Design Get(int id)
            => Set.Where(e => e.Id == id)
                  .Include(e => e.Texts)
                  .Include(e => e.Images)
                  .FirstOrDefault();
        public override async Task<Design> GetAsync(int id)
            => await Set.Where(e => e.Id == id)
                        .Include(e => e.Texts)
                        .Include(e => e.Images)
                        .FirstOrDefaultAsync();

        public override IEnumerable<Design> GetAll()
            => Set.Include(e => e.Texts)
                  .Include(e => e.Images)
                  .ToList();
        public override async Task<IEnumerable<Design>> GetAllAsync()
            => await Set.Include(e => e.Texts)
                        .Include(e => e.Images)
                        .ToListAsync();
    }
}