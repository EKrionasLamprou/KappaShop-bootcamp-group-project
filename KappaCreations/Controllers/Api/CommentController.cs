using KappaCreations.Database;
using KappaCreations.Models;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Web.Http;
using static KappaCreations.Utilities;

namespace KappaCreations.Controllers.Api
{
    public class CommentController : ApiController
    {
        readonly ShopContext _db;
        readonly Repository<Comment> _repo;

        public CommentController()
        {
            _db = new ShopContext();
            _repo = new Repository<Comment>(_db);
        }
        public CommentController(ShopContext db)
        {
            _db = db;
            _repo = new Repository<Comment>(_db);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            var comments = await _repo.GetAllAsync();
            var response = CommentDTO.MapToCamelCase(comments);
            
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var comment = await _repo.GetAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var response = CommentDTO.MapToCamelCase(comment);

            return Ok(response);
        }

        [HttpGet]
        [Route("api/comment/count")]
        public async Task<IHttpActionResult> GetCountAsync()
        {
            int count = await _repo.CountAsync();
            return Ok(new { count });
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync(CommentDTO data)
        {
            Comment comment;
            object response;

            try
            {
                comment = data.Map();
                _repo.Add(comment);
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

            response = CommentDTO.MapToCamelCase(comment);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(CommentDTO data)
        {
            if (data is null || !data.HasId)
            {
                return NotFound();
            }
            try
            {
                var comment = data.Map();
                bool result = await _repo.UpdateAsync(comment);
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

        [HttpPatch]
        [Route("api/comment/vote")]
        public async Task<IHttpActionResult> PatchVoteAsync(int id, bool downvote = false)
        {
            var comment = await _repo.GetAsync(id);
            object response;
            
            if (comment == null)
            {
                return NotFound();
            }

            comment.Upvotes += downvote ? -1 : 1;
           
            try
            {
                bool result = await _repo.UpdateAsync(comment);
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

            response = CommentDTO.MapToCamelCase(comment);
            return Ok(response);
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
            return Ok($"Comment with id {id} was deleted.");
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