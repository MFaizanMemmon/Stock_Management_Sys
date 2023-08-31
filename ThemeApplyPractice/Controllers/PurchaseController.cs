using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly myDbContext db;
        public PurchaseController(myDbContext db) 
        { 
            this.db = db;
        }
        public IActionResult Display()
        {
            List<Purchase> li = db.purchases.OrderByDescending(x => x.PurchaseId).ToList();
            var PurchaseDetail = from pur in db.purchases
                                 join pro in db.products on pur.ProductId equals pro.ProductId into data
                                 from pro in data.DefaultIfEmpty()
                                 join ven in db.vendors on pur.VendorId equals ven.VendorId into venData
                                 from ven in venData.DefaultIfEmpty()
                                 select new Purchase { PurchaseId = pur.PurchaseId, PurDate = pur.PurDate, ProductName = pro.ProductName, Qty = pur.Qty, Price = pur.Price,Vendor = ven.VendorName };

            return View(PurchaseDetail);
        }
        [HttpGet]
        public IActionResult Create() 
        {

            var ProductList = (from c in db.products select new SelectListItem { Value=c.ProductId.ToString(),Text=c.ProductName }).ToList();
            var VendorList = (from c in db.vendors select new SelectListItem { Value = c.VendorId.ToString(), Text = c.VendorName }).ToList();
            ViewBag.ProductList = ProductList;
            ViewBag.VendorList = VendorList;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Purchase modal)
        {
            if (modal != null)
            {
                db.purchases.Add(modal);
                db.SaveChanges();
                return RedirectToAction("display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ProductList = (from c in db.products select new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName }).ToList();
            var VendorList = (from c in db.vendors select new SelectListItem { Value = c.VendorId.ToString(), Text = c.VendorName }).ToList();
            ViewBag.ProductList = ProductList;
            ViewBag.VendorList = VendorList;
            Purchase modal = db.purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            
            return View(modal);
        }
        [HttpPost]
        public IActionResult Edit(Purchase modal)
        {
            Purchase _modal=db.purchases.Where(x=>x.PurchaseId== modal.PurchaseId).SingleOrDefault();
            _modal.ProductName = modal.ProductName;
            _modal.PurDate=modal.PurDate;
            _modal.Vendor = modal.Vendor;
            _modal.Qty= modal.Qty;
            _modal.Price = modal.Price;
            _modal.VendorId = modal.VendorId;
            _modal.ProductId = modal.ProductId;
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Purchase modal = db.purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            return View(modal);
        }
        [HttpPost]  
        public IActionResult Delete(Purchase modal)
        {
            Purchase _modal = db.purchases.Where(x => x.PurchaseId == modal.PurchaseId).SingleOrDefault();
            db.purchases.Remove(_modal);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Purchase modal = db.purchases.Where(x => x.PurchaseId == id).SingleOrDefault();
            return View(modal);
        }
    }
}
