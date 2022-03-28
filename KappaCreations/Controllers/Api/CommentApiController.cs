using KappaCreations.Database;
using KappaCreations.Models;
using KappaCreations.Models.Shop.DTOs;
using KappaCreations.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace KappaCreations.Controllers.Api
{
    public class CommentApiController : ApiController
    {
        readonly ShopContext _db;
        readonly Repository<Comment> _repo;

        public CommentApiController()
        {
            _db = new ShopContext();
            _repo = new Repository<Comment>(_db);
        }
        public CommentApiController(ShopContext db)
        {
            _db = db;
            _repo = new Repository<Comment>(_db);
        }

        //[HttpGet]
        //[ResponseType(typeof(IEnumerable<CommentDTO>))]
        //public async Task<IHttpActionResult> GetAsync()
        //{
        //    var comments = await _repo.GetAllAsync();
        //    return Ok(comments.Select(comment => CommentDTO.MapFrom(comment)));
        //}
        //
        //[HttpGet]
        //[ResponseType(typeof(CommentDTO))]
        //public async Task<IHttpActionResult> GetAsync(int id)
        //{
        //    var comment = await _repo.GetAsync(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(CommentDTO.MapFrom(comment));
        //}

        [HttpGet]
        [ResponseType(typeof(int))]
        [ActionName("Count")]
        public async Task<IHttpActionResult> GetCountAsync()
        {
            string connectionString = System.Configuration
                                            .ConfigurationManager
                                            .ConnectionStrings["KappaShop"]
                                            .ConnectionString;
            int count;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Comments";
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        count = (int)await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { CommentCount = count });
        }
    }
}
