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
        private string strCart = "Cart";

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

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> isCart = new List<Cart>
                {
                    new Cart(_db.Products.Find(id),1)
                };

                Session[strCart] = isCart;
            }
            else
            {
                List<Cart> isCart = (List<Cart>)Session[strCart];
                int check = isExistingCheck(id);
                if (check == -1)
                {
                    isCart.Add(new Cart(_db.Products.Find(id), 1));
                }
                else
                {
                    isCart[check].Quantity++;
                }
                Session[strCart] = isCart;
            }

            return View("~/Views/Home/ShoppingCart.cshtml");
        }

        private int isExistingCheck(int? id)
        {
            List<Cart> isCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < isCart.Count; i++)
            {
                if (isCart[i].Product.Id == id)
                {
                    return i;
                }
            }

            return -1;

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Cart> isCart = (List<Cart>)Session[strCart];
            isCart.RemoveAt(check);
            return View("~/Views/Home/ShoppingCart.cshtml");
        }

    }
}