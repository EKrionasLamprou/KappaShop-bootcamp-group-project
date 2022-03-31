using KappaCreations.Database;
using KappaCreations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KappaCreations.Controllers
{
    public class ShoppingCartController : Controller
    {
        readonly ShopContext _db;
        

        public ShoppingCartController()
        {
            _db = new ShopContext();
        }


        public ShoppingCartController(ShopContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int? id)
        {
            
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = _db.Products.ToList().Single(x=> x.Id == id), Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = _db.Products.ToList().Single(x => x.Id == id), Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public int isExist(int? id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count(); i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
                    
            }
                
            return -1;
        }

    }
}