using KappaCreations.Database;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using System.Web.Http.Description;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using static KappaCreations.Utilities;

namespace KappaCreations.Controllers.Api
{
    public class ProductApiController : ApiController
    {
        readonly ShopContext _db;
        readonly ProductRepository _repo;

        public ProductApiController()
        {
            _db = new ShopContext();
            _repo = new ProductRepository(_db);
        }
        public ProductApiController(ShopContext db)
        {
            _db = db;
            _repo = new ProductRepository(_db);
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

        [HttpPost]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostAsync(ProductDTO data)
        {
            Product product;
            try
            {
                product = data.Map();
                _repo.Add(product);
                await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ProductDTO.MapFrom(product));
        }

        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            try
            {
                bool result = await _repo.DeleteAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok($"Product with id {id} was deleted.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
