using KappaCreations.Database;
using KappaCreations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using KappaCreations.Models.ViewModels;
using KappaCreations.Models;

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

        public async Task<ActionResult> Index(int? page, int? pSize, int categoryId = 0)
        {
            var products = await _repo.GetAllAsync();

            // Filter by category
            if (categoryId > 0)
            {
                products = products.Where(x => x.CategoryId == categoryId).ToList();
            }

            int pageSize = pSize ?? 12;
            int pageNumber = page ?? 1;
            ViewBag.GalleryProducts = products.ToPagedList(pageNumber, pageSize);
            ViewBag.LoggedUser = GetCurrentUser();
            return View(products.ToPagedList(pageNumber, pageSize));
        }


        public async Task<ActionResult> Details(int Id)
        {
            var product = await _repo.GetAsync(Id);
            return View(product);
        }

        public  async Task Vote(int Id)
        {
            var product = await _repo.GetAsync(Id);
            var user = GetCurrentUser();
            bool isUpvoted = product.UsersUpvoted.Contains(user);
            if (isUpvoted)
            {
                product.UsersUpvoted.Remove(user);
            }
            else
            {
                product.UsersUpvoted.Add(user);
            }
            await _db.SaveChangesAsync();
            
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentViewModel viewModel)
        {
            var commentRepository = new Repository<Comment>(_db);
            var user = GetCurrentUser();
            var comment = new Comment
            {
                Content = viewModel.Text,
                ProductId = viewModel.ProductId,
                User = user,
            };
            commentRepository.Add(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "Gallery", new { Id = viewModel.ProductId });
        }

        private ApplicationUser GetCurrentUser()
        {
            string userName = User.Identity.Name;
            var user = _db.Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }
    }
}