using ProductsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProductsProject.Controllers
{
    public class AdminController : Controller
    {
        private ProductsDBEntities db = new ProductsDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var products = (from product in db.Products select product).ToList();
            return View(products);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var productDetails = (from product in db.Products
                                  where product.ProductId == id
                                  select product).First();
            return View(productDetails);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Product product = new Product(); 
            return View(product);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(product);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var productEdit = (from product in db.Products
                                  where product.ProductId == id
                                  select product).First();
            return View(productEdit);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var productEdit = (from product in db.Products
                               where product.ProductId == id
                               select product).First();
            try
            {
                UpdateModel(productEdit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(productEdit);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var productDelete = (from product in db.Products
                               where product.ProductId == id
                               select product).First();
            return View(productDelete);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var productDelete = (from product in db.Products
                                 where product.ProductId == id
                                 select product).First();
            
                try
                {
                    db.Products.Remove(productDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(productDelete);
                }
        }
    }
}
