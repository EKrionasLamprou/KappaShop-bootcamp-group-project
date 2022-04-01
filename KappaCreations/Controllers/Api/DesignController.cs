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
            var response = DesignDTO.MapFrom(designs, camelCase: true);

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
            var response = DesignDTO.MapFrom(design, camelCase: true);

            return Ok(response);
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

            response = DesignDTO.MapFrom(design, camelCase: true);
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