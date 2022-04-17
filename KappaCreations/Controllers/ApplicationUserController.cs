using KappaCreations.Database;
using KappaCreations.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Birthdate,PhotoUrl,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUserManager applicationUser)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(applicationUser).State = EntityState.Modified;
               _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
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