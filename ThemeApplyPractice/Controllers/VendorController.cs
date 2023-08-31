using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class VendorController : Controller
    {
        private readonly myDbContext db;
        public VendorController(myDbContext db)
        {
            this.db = db;
        }
        public IActionResult Display()
        {
            List<Vendor> modal = db.vendors.OrderByDescending(x => x.VendorId).ToList();
            return View(modal);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vendor modal)
        {
            if (modal != null)
            {
                db.vendors.Add(modal);
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Vendor modal=db.vendors.Where(x=>x.VendorId== id).FirstOrDefault();
            return View(modal);
        }
        [HttpPost]
        public IActionResult Edit(Vendor modal)
        {
            Vendor _modal = db.vendors.Where(x => x.VendorId == modal.VendorId).SingleOrDefault();
            _modal.VendorName = modal.VendorName;
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Vendor _modal = db.vendors.Where(x => x.VendorId == id).SingleOrDefault();
            return View(_modal);
        }
        [HttpPost]
        public IActionResult Delete(Vendor modal)
        {
            Vendor _modal = db.vendors.Where(x=>x.VendorId ==modal.VendorId).SingleOrDefault();
            db.vendors.Remove(_modal);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        public IActionResult Details(int id)
        {
            Vendor modal = db.vendors.Where(x => x.VendorId == id).SingleOrDefault();
            return View(modal);
        }
    }
}
