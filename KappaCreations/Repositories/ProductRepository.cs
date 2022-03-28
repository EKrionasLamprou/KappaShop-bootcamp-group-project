using KappaCreations.Database;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KappaCreations.Repositories
{
    /// <summary>
    /// Used for handling CRUD operations for the <see cref="Product"/> to the database.
    /// </summary>
    public class ProductRepository : Repository<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public ProductRepository() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public ProductRepository(ShopContext db) : base(db) { }

        public override DbSet<Product> Set { get => db.Products; }

        public override Product Get(int id)
           => Set.Where(e => e.Id == id)
                 .Include(e => e.Design)
                 .Include(e=> e.BackDesign)
                 .FirstOrDefault();
        public override async Task<Product> GetAsync(int id)
            => await Set.Where(e => e.Id == id)
                        .Include(e => e.Design)
                        .Include(e => e.BackDesign)
                        .FirstOrDefaultAsync();

        public override async Task<IEnumerable<Product>> GetAllAsync()
             => await Set.Include(e => e.Design)
                         .Include(e => e.BackDesign)
                         .ToListAsync();
    }
}