using ProductsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsProject.Controllers
{
    public class HomeController : Controller
    {
        private ProductsDBEntities db = new ProductsDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var products = (from product in db.Products select product).ToList();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            var productDetails = (from product in db.Products
                                  where product.ProductId == id
                                  select product).First();
            return View(productDetails);
        }
    }
}