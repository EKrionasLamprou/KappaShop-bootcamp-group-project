using KappaCreations.Database;
using KappaCreations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KappaCreations.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ShopContext _db;
        private readonly ProductRepository _repo;

        public GalleryController()
        {
            _db = new ShopContext();
            _repo = new ProductRepository(_db);
        }
        public GalleryController(ShopContext db)
        {
            _db = db;
            _repo = new ProductRepository(_db);
        }
        
        public async Task<ActionResult> Index()
        {
            var products = await _repo.GetAllAsync();
            return View();
        }


        public ActionResult Details()
        {
            return View();
        }
    }
}