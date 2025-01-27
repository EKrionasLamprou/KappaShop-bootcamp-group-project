﻿using KappaCreations.Database;
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
        enum Sorting
        {
            PriceAsc = 1,
            PriceDesc,
            DateAsc,
            DateDesc,
        }

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

        public async Task<ActionResult> Index(int? page, int? pSize, int categoryId = 0, int order = 0)
        {
            var products = await _repo.GetAllAsync();

            // Filter by category
            if (categoryId > 0)
            {
                products = products.Where(x => x.CategoryId == categoryId).ToList();
            }
            products = Sort(order, products);

            int pageSize = pSize ?? 12;
            int pageNumber = page ?? 1;
            ViewBag.CategoryId = categoryId;
            ViewBag.GalleryProducts = products.ToPagedList(pageNumber, pageSize);
            ViewBag.LoggedUser = GetCurrentUser();
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        private IEnumerable<Product> Sort(int order, IEnumerable<Product> products)
        {
            switch (order)
            {
                case (int)Sorting.PriceAsc:
                    return products.OrderBy(p => p.Category.Price).ToList();
                case (int)Sorting.PriceDesc:
                    return products.OrderByDescending(p => p.Category.Price).ToList();
                case (int)Sorting.DateAsc:
                    return products.OrderBy(p => p.SubmitDate).ToList();
                case (int)Sorting.DateDesc:
                    return products.OrderByDescending(p => p.SubmitDate).ToList();
                default: return products;
            }
        }

        public async Task<ActionResult> Details(int Id)
        {
            var product = await _repo.GetAsync(Id);
            return View(product);
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