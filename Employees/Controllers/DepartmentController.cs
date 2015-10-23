using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Models;
using Employees.ViewModels;

namespace Employees.Controllers
{
    public class DepartmentController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        [HttpGet]
        public ActionResult Add()
        {
            var model = new DepartmentViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var department = new Department();
            department.Name = model.Name;
            department.Floor = model.Floor;
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }
    }
}