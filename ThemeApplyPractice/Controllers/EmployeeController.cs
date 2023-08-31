using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;
using System.Linq;
using ThemeApplyPractice.DBContextFolder;
using ThemeApplyPractice.Models;

namespace ThemeApplyPractice.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly myDbContext db;
        public EmployeeController(myDbContext db)
        {
            this.db = db;
        }

        public IActionResult Display()
        {
            List<Employee> emp = db.employees.OrderByDescending(x => x.EmployeeId).ToList();
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee modal)
        {
            if (modal != null)
            {
                db.employees.Add(modal);
                db.SaveChanges();
                return RedirectToAction("display");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee _modal = db.employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            return View(_modal);
        }
        [HttpPost]
        public IActionResult Edit(Employee modal)
        {
            Employee _modal = db.employees.Where(x => x.EmployeeId == modal.EmployeeId).SingleOrDefault();
            _modal.EmployeeName = modal.EmployeeName;
            db.SaveChanges();
            return RedirectToAction("display");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Employee _modal = db.employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            return View(_modal);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee _modal = db.employees.Where(x => x.EmployeeId == id).SingleOrDefault();
            return View(_modal); 
        }
        [HttpPost]
        public IActionResult Delete(Employee modal)
        {
            Employee _modal = db.employees.Where(x => x.EmployeeId == modal.EmployeeId).SingleOrDefault();
            db.employees.Remove(_modal);
            db.SaveChanges();
            return RedirectToAction("display");
        }

    }
}
