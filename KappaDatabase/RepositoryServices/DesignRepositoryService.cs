using KappaDatabase.Database;
using KappaDatabase.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KappaDatabase.RepositoryServices
{
    public class DesignRepositoryService : RepositoryService<Design>
    {
        public DesignRepositoryService() { }
        public DesignRepositoryService(ShopContext db) : base(db) { }

        public override Design Get(int id) => db.Designs.Where(e => e.Id == id)
                                                        .Include(e => e.Texts)
                                                        .Include(e => e.Images)
                                                        .FirstOrDefault();
        public override IEnumerable<Design> GetAll() => db.Designs.Include(e => e.Texts)
                                                                  .Include(e => e.Images)
                                                                  .ToList();
    }
}
