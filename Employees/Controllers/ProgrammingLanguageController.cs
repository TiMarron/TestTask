using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Models;
using Employees.ViewModels;

namespace Employees.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ProgrammingLanguage();
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProgrammingLanguageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var language = new ProgrammingLanguage();
            language.Name = model.Name;
            db.ProgrammingLanguages.Add(language);
            db.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }
    }
}