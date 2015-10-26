using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Employees.Models;
using Employees.ViewModels;

namespace Employees.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        public ActionResult Index()
        {
            List<EmployeesListViewModel> employeesList = new List<EmployeesListViewModel>();
            IEnumerable<Employee> employees = db.Employees;
            foreach (var e in employees.ToList())
            {
                var employee = new EmployeesListViewModel() {};
                employee.Id = e.Id;
                employee.Name = e.Name;
                employee.SecondName = e.SecondName;
                employee.Department = db.Departments.Find(e.DepartmentId).Name;
                employee.ProgrammingLanguage = db.ProgrammingLanguages.Find(e.ProgrammingLanguageId).Name;
                employee.Years = e.Years;

                employeesList.Add(employee);
            }
            return View(employeesList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new EmployeeAddViewModel
            {
                DepartmentList = db.Departments,
                ProgrammingLanguageList = db.ProgrammingLanguages
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(EmployeeAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var empl = new EmployeeAddViewModel
                {
                    Name = model.Name,
                    SecondName = model.SecondName,
                    Sex = model.Sex,
                    Years = model.Years,
                    DepartmentId = model.DepartmentId,
                    DepartmentList = db.Departments,
                    ProgrammingLanguageId = model.ProgrammingLanguageId,
                    ProgrammingLanguageList = db.ProgrammingLanguages
                };

                return View(empl);
            }
            var employee = new Employee();
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Sex = model.Sex;
            employee.Years = model.Years;
            employee.DepartmentId = model.DepartmentId;
            employee.ProgrammingLanguageId = model.ProgrammingLanguageId;
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Find(id);
            var model = new EmployeeEditViewModel
            {
                Name = employee.Name,
                SecondName = employee.SecondName,
                Sex = employee.Sex,
                Years = employee.Years,
                DepartmentId = employee.DepartmentId,
                DepartmentList = db.Departments,
                ProgrammingLanguageId = employee.ProgrammingLanguageId,
                ProgrammingLanguageList = db.ProgrammingLanguages
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var empl = new EmployeeEditViewModel
                {
                    Name = model.Name,
                    SecondName = model.SecondName,
                    Sex = model.Sex,
                    Years = model.Years,
                    DepartmentId = model.DepartmentId,
                    DepartmentList = db.Departments,
                    ProgrammingLanguageId = model.ProgrammingLanguageId,
                    ProgrammingLanguageList = db.ProgrammingLanguages
                };

                return View(empl);
            }

            var employee = db.Employees.Single(e => e.Id == model.Id);
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Sex = model.Sex;
            employee.Years = model.Years;
            employee.DepartmentId = model.DepartmentId;
            employee.ProgrammingLanguageId = model.ProgrammingLanguageId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {

            db.Employees.Remove(db.Employees.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetPersons(string search)
        {
            List<string> names = db.Employees.Where(e => e.Name.StartsWith(search)).Select(e => e.Name).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutocompleteName(string term)
        {
            var models = db.Employees.Where(e => e.Name.StartsWith(term)).Select(e => e.Name).ToList();
            List<string> modelsList = new List<string>(models.Distinct());

            return Json(modelsList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutocompleteSecondName(string term)
        {
            var models = db.Employees.Where(e => e.SecondName.StartsWith(term)).Select(e => e.SecondName).ToList();
            List<string> modelsList = new List<string>(models.Distinct());

            return Json(modelsList, JsonRequestBehavior.AllowGet);
        }
    }
} 