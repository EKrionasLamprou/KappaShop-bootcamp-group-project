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
using static KappaCreations.Controllers.Utilities;

namespace KappaCreations.Controllers.Api
{
    public class DesignApiController : ApiController
    {
        readonly ShopContext _db;
        readonly DesignRepository _repo;

        public DesignApiController()
        {
            _db = new ShopContext();
            _repo = new DesignRepository(_db);
        }
        public DesignApiController(ShopContext db)
        {
            _db = db;
            _repo = new DesignRepository(_db);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<DesignDTO>))]
        public async Task<IHttpActionResult> GetAsync()
        {
            var designs = await _repo.GetAllAsync();
            return Ok(designs.Select(design => DesignDTO.MapFrom(design)));
        }

        [HttpGet]
        [ResponseType(typeof(DesignDTO))]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var design = await _repo.GetAsync(id);
            if (design == null)
            {
                return NotFound();
            }
            return Ok(DesignDTO.MapFrom(design));
        }

        [HttpPost]
        [ResponseType(typeof(DesignDTO))]
        public async Task<IHttpActionResult> PostAsync(DesignDTO data)
        {
            Design design;
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(DesignDTO.MapFrom(design));
        }

        [HttpPut]
        [ResponseType(typeof(DesignDTO))]
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(data);
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