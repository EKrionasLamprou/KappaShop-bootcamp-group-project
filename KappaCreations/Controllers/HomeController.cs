using KappaCreations.Database;
using KappaCreations.Models;
using KappaCreations.Repositories;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KappaCreations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _db;

        public HomeController()
        {
            _db = new ShopContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            
            var user = GetCurrentUser();

            ViewBag.Message = "Your contact page.";

            ViewBag.UserId = user;

            return View();
        }

        private string GetCurrentUser()
        {
            string username = User.Identity.Name;
            var user = _db.Users.First(u => u.UserName == username);
            string id = user.Id;
            return id;
        }




    }
}