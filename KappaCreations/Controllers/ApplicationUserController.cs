using KappaCreations.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KappaCreations.Controllers
{
    [Authorize(Roles = "User")]
    public class ApplicationUserController : Controller
    {
        private readonly ShopContext _db;

        public ApplicationUserController()
        {
            _db = new ShopContext();
        }

        // GET: ApplicationUser
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            var user = _db.Users.First(u => u.UserName == username);

            return View(user);
        }
    }
}