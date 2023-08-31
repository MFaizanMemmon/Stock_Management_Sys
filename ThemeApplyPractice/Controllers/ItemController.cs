using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class ItemController : Controller
    {
        public readonly myDbContext db;
        public ItemController(myDbContext db)
        {
            this.db = db;
        }

        public IActionResult Display()
        {
            List<Product> products = db.products.OrderByDescending(x=>x.ProductId).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product modal)
        {
            if (modal != null)
            {
                db.products.Add(modal);
                db.SaveChanges();
                return RedirectToAction("display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = db.products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product modal)
        {
            Product _modal = db.products.Where(x => x.ProductId == modal.ProductId).SingleOrDefault();
            _modal.ProductName= modal.ProductName;
            _modal.Status = modal.Status;
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = db.products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product modal)
        {
            Product _modal = db.products.Where(x => x.ProductId == modal.ProductId).SingleOrDefault();
            db.products.Remove(_modal);
            db.SaveChanges();
            return RedirectToAction("Display");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Product product = db.products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(product);
        }
    }
}
