using KappaCreations.Database;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using System;

namespace KappaCreations.Controllers.Api
{
    public class DesignApiController : ApiController
    {
        readonly ShopContext db;
        readonly DesignRepository repo;

        public DesignApiController(ShopContext db)
        {
            this.db = db;
            repo = new DesignRepository(db);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var design = await repo.GetAsync(id);
            if (design == null)
                return NotFound();
            return Ok(design);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(DesignDTO data)
        {
            try
            {
                var design = data.Parse();
                repo.Add(design);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(DesignDTO data)
        {
            try
            {
                var design = data.Parse();
                bool result = await repo.UpdateAsync(design);
                if (!result)
                {
                    return NotFound();
                }
                await db.SaveChangesAsync();
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
                bool result = await repo.DeleteAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}