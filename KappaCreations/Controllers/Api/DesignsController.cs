using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KappaCreations.Database;
using KappaCreations.Models;

namespace KappaCreations.Controllers.Api
{
    public class DesignsController : ApiController
    {
        private ShopContext db = new ShopContext();

        // GET: api/Designs
        public IQueryable<Design> GetDesigns()
        {
            return db.Designs;
        }

        // GET: api/Designs/5
        [ResponseType(typeof(Design))]
        public IHttpActionResult GetDesign(int id)
        {
            Design design = db.Designs.Find(id);
            if (design == null)
            {
                return NotFound();
            }

            return Ok(design);
        }

        // PUT: api/Designs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDesign(int id, Design design)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != design.Id)
            {
                return BadRequest();
            }

            db.Entry(design).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Designs
        [ResponseType(typeof(Design))]
        public IHttpActionResult PostDesign(Design design)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Designs.Add(design);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = design.Id }, design);
        }

        // DELETE: api/Designs/5
        [ResponseType(typeof(Design))]
        public IHttpActionResult DeleteDesign(int id)
        {
            Design design = db.Designs.Find(id);
            if (design == null)
            {
                return NotFound();
            }

            db.Designs.Remove(design);
            db.SaveChanges();

            return Ok(design);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DesignExists(int id)
        {
            return db.Designs.Count(e => e.Id == id) > 0;
        }
    }
}