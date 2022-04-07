using KappaCreations.Database;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using KappaCreations.Models;
using System.Data.Entity.Validation;
using static KappaCreations.Utilities;
using System.Data.Entity.Infrastructure;

namespace KappaCreations.Controllers.Api
{
    public class DesignController : ApiController
    {
        readonly ShopContext _db;
        readonly DesignRepository _repo;

        public DesignController()
        {
            _db = new ShopContext();
            _repo = new DesignRepository(_db);
        }
        public DesignController(ShopContext db)
        {
            _db = db;
            _repo = new DesignRepository(_db);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var designs = await _repo.GetAllAsync();
            var response = DesignDTO.MapToCamelCase(designs);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var design = await _repo.GetAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            var response = DesignDTO.MapToCamelCase(design);

            return Ok(response);
        }

        [HttpGet]
        [Route("api/design/count")]
        public async Task<IHttpActionResult> GetCountAsync()
        {
            int count = await _repo.CountAsync();
            return Ok(new { count });
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(DesignDTO data)
        {
            Design design;
            object response;

            try
            {
                design = data.Map();
                _repo.Add(design);
                await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(FormatDbUpdateException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            response = DesignDTO.MapToCamelCase(design);
            return Ok(response);
        }

        [Obsolete]
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(DesignDTO data)
        {
            try
            {
                var design = data.Map();
                bool result = await _repo.UpdateAsync(design);
                if (!result)
                {
                    return NotFound();
                }
                await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(FormatDbUpdateException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete]
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
            catch (DbEntityValidationException ex)
            {
                return BadRequest(FormatDbEntityValidationException(ex));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(FormatDbUpdateException(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok($"Design with id {id} was deleted.");
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