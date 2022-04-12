//using KappaCreations.Database;
//using KappaCreations.Models.Shop.DTOs;
//using KappaCreations.Repositories;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System;
//using KappaCreations.Models;
//using System.Data.Entity.Validation;
//using static KappaCreations.Utilities;
//using System.Data.Entity.Infrastructure;

//namespace KappaCreations.Controllers.Api
//{
//    public class UserController : ApiController
//    {
//        readonly ShopContext _db;

//        public UserController()
//        {
//            _db = new ShopContext();
//            _repo = new ProductRepository(_db);
//        }
//        public UserController(ShopContext db)
//        {
//            _db = db;
//            _repo = new ProductRepository(_db);
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> GetAsync()
//        {
//            var products = await _repo.GetAllAsync();
//            var response = ProductDTO.MapToCamelCase(products);

//            return Ok(response);
//        }

//        [HttpGet]
//        public async Task<IHttpActionResult> GetAsync(int id)
//        {
//            var product = await _repo.GetAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            var response = ProductDTO.MapToCamelCase(product);

//            return Ok(response);
//        }

//        [HttpPost]
//        public async Task<IHttpActionResult> PostAsync(ProductDTO data)
//        {
//            Product product;
//            object response;

//            try
//            {
//                product = data.Map();
//                _repo.Add(product);
//                await _db.SaveChangesAsync();
//            }
//            catch (DbEntityValidationException ex)
//            {
//                return BadRequest(FormatDbEntityValidationException(ex));
//            }
//            catch (DbUpdateException ex)
//            {
//                return BadRequest(FormatDbUpdateException(ex));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//            response = ProductDTO.MapToCamelCase(product);
//            return Ok(response);
//        }

//        [HttpDelete]
//        public async Task<IHttpActionResult> DeleteAsync(int id)
//        {
//            try
//            {
//                bool result = await _repo.DeleteAsync(id);
//                if (!result)
//                {
//                    return NotFound();
//                }
//                await _db.SaveChangesAsync();
//            }
//            catch (DbEntityValidationException ex)
//            {
//                return BadRequest(FormatDbEntityValidationException(ex));
//            }
//            catch (DbUpdateException ex)
//            {
//                return BadRequest(FormatDbUpdateException(ex));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//            return Ok($"Product with id {id} was deleted.");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}