using KappaCreations.Database;
using KappaCreations.Models;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace KappaCreations.Controllers.Api
{
    public class ProductApiController : ApiController
    {
        readonly ShopContext _db;
        readonly Repository<Product> _repo;

        public ProductApiController()
        {
            _db = new ShopContext();
            _repo = new Repository<Product>(_db);
        }
        public ProductApiController(ShopContext db)
        {
            _db = db;
            _repo = new Repository<Product>(_db);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductDTO>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var products = await _repo.GetAllAsync();
            return Ok(products.Select(product => ProductDTO.MapFrom(product)));
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductDTO>))]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var product = await _repo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ProductDTO.MapFrom(product));
        }
    }
}
