using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class IssuanceController : Controller
    {
        private readonly myDbContext db;
        public IssuanceController(myDbContext db)
        {
            this.db = db;
        }
        public IActionResult Display()
        {
             List<Issuance> li = db.issuances.OrderByDescending(x => x.Issuance_Id).ToList();
            return View(li);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductList = (from c in db.products select new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName });
            ViewBag.EmployeeList = (from e in db.employees select new SelectListItem { Value = e.EmployeeId.ToString(), Text = e.EmployeeName });

            return View();
        }
        [HttpPost]
        public IActionResult Create(Issuance modal)
        {
            if (modal != null)
            {
                db.issuances.Add(modal);
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ProductList = (from c in db.products select new SelectListItem { Value = c.ProductId.ToString(), Text = c.ProductName });
            ViewBag.EmployeeList = (from c in db.employees select new SelectListItem { Value = c.EmployeeId.ToString(), Text = c.EmployeeName });
            Issuance li = db.issuances.Where(x => x.Issuance_Id == id).SingleOrDefault();
            return View(li);
        }
        [HttpPost]
        public IActionResult Edit(Issuance modal)
        {
            //Issuance _modal = db.issuances.Where(x => x.Issuance_Id == modal.Issuance_Id).SingleOrDefault();
            db.issuances.Update(modal);
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Issuance modal = db.issuances.Where(x => x.Issuance_Id == id).SingleOrDefault();
            return View(modal);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Issuance modal = db.issuances.Where(x => x.Issuance_Id == id).SingleOrDefault();
            return View(modal);
        }
        [HttpPost]
        public IActionResult Delete(Issuance modal)
        {
            db.issuances.Remove(modal);
            db.SaveChanges();
            return RedirectToAction("display");
        }
    }
}
