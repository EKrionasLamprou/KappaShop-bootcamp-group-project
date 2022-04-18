using KappaCreations.Database;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KappaCreations.Repositories
{
    /// <summary>
    /// Used for handling CRUD operations for the <see cref="Order"/> to the database.
    /// </summary>
    public class OrderRepository : Repository<Order>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public OrderRepository() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public OrderRepository(ShopContext db) : base(db) { }

        public override DbSet<Order> Set { get => db.Orders; }

        public override Order Get(int id)
           => Set.Where(e => e.Id == id)
                 .Include(e => e.User)
                 .Include(e => e.BillingAddress)
                 .Include(e => e.Items)
                 .Include(e => e.Items.Select(p => p.Product))
                 .Include(e => e.Items.Select(p => p.Product.Category))
                 .FirstOrDefault();
        public override async Task<Order> GetAsync(int id)
            => await Set.Where(e => e.Id == id)
                        .Include(e => e.User)
                        .Include(e => e.BillingAddress)
                        .Include(e => e.Items)
                        .Include(e => e.Items.Select(p => p.Product))
                        .Include(e => e.Items.Select(p => p.Product.Category))
                        .FirstOrDefaultAsync();

        public override async Task<IEnumerable<Order>> GetManyAsync(int i, int n)
            => await Set.Skip(i)
                        .Take(n)
                        .Include(e => e.User)
                        .Include(e => e.BillingAddress)
                        .Include(e => e.Items)
                        .Include(e => e.Items.Select(p => p.Product))
                        .Include(e => e.Items.Select(p => p.Product.Category))
                        .ToListAsync();

        public override async Task<IEnumerable<Order>> GetAllAsync()
            => await Set.Include(e => e.User)
                        .Include(e => e.BillingAddress)
                        .Include(e => e.Items)
                        .Include(e => e.Items.Select(p => p.Product))
                        .Include(e => e.Items.Select(p => p.Product.Category))
                        .ToListAsync();
    }
}