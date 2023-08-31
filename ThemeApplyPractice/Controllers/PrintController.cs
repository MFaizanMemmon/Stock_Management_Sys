using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class PrintController : Controller
    {
        private readonly myDbContext db;
        public IList<Product> product;

        public IList<Purchase> purchase;
        public IList<Issuance> issuance { get; set; }
        public PrintController(myDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductData()
        {
            product = db.products.OrderBy(x => x.ProductId).ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult AllProductData()
        {
            return new Rotativa.AspNetCore.ViewAsPdf(db.products.OrderBy(x =>x.ProductId).ToList());
        }
        [HttpPost]
        public IActionResult ProductData(string Data)
        {
            DataClass data = new DataClass(db);
            product = data.getProduct(Data);
            TempData["Data"] = db;
            return View(data);
        }

        [HttpGet]
        public IActionResult ProductReport()
        {
            DataClass data = new DataClass(db);
            var mydata = TempData["Data"];
            IList<Product> ProductItem = data.getProduct(mydata.ToString());
            return new Rotativa.AspNetCore.ViewAsPdf(ProductItem);
        }
        

    }
}
