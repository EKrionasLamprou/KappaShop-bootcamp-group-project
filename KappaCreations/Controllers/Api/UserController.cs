using KappaCreations.Database;
using KappaCreations.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace KappaCreations.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly ShopContext _db;
        private readonly ApplicationUserManager _manager;
        private const string _baseUrl = "api/user";

        public UserController()
        {
            _db = ShopContext.Create();
            _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
        }

        public UserController(
            ShopContext db = null,
            ApplicationUserManager manager = null)
        {
            _db = db ?? new ShopContext();
            _manager = manager ??
                new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }

        [HttpGet]
        [Route(_baseUrl + "/getCurrentUser")]
        public IHttpActionResult GetCurrentUserAsync()
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var user = _manager.FindById(userId);
                
                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}