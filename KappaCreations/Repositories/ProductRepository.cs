using KappaCreations.Database;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KappaCreations.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository() { }
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