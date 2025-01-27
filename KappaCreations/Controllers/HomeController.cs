﻿using KappaCreations.Database;
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
            if (user == null)
            {
                return RedirectToAction("Home/Index");
            }
            else
            {
                ViewBag.UserId = user;

                return View();
            }

           
        }

        private string GetCurrentUser()
        {
            string id = "";
            string username = User.Identity.Name;
           if(username == "")
            {
                id = "0";
            }
            else
            {
                var user = _db.Users.First(u => u.UserName == username);
                id = user.Id;
                return id;
            }
            return id;
        }




    }
}