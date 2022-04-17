using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KappaCreations.Database;
using KappaCreations.Models;

namespace KappaCreations.Controllers
{
    public class ApplicationUsersController : Controller
    {

        private readonly ShopContext db;

        public ApplicationUsersController()
        {
            db = new ShopContext();
        }


        // GET: ApplicationUsers
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            var user = db.Users.First(u => u.UserName == username);
            return View(user);
        }
 

      
    }
}
