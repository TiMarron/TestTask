﻿using System;
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
                DepartmentSelectList = new SelectList(db.Departments, "Id", "Name"),
                ProgrammingLanguageSelectList = new SelectList(db.ProgrammingLanguages, "Id", "Name")
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
                    DepartmentSelectList = new SelectList(db.Departments, "Id", "Name"),
                    ProgrammingLanguageSelectList = new SelectList(db.ProgrammingLanguages, "Id", "Name")
                };

                return View(empl);
            }
            var employee = new Employee();
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Sex = model.Sex;
            employee.Years = model.Years;
            employee.DepartmentId = int.Parse(Request.Form["DepartmentSelectList"]);
            employee.ProgrammingLanguageId = int.Parse(Request.Form["ProgrammingLanguageSelectList"]);
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
                DepartmentSelectList = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId),
                ProgrammingLanguageSelectList = new SelectList(db.ProgrammingLanguages, "Id", "Name", employee.ProgrammingLanguageId)
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
                    ProgrammingLanguageId = model.ProgrammingLanguageId,
                    DepartmentSelectList = new SelectList(db.Departments, "Id", "Name"),
                    ProgrammingLanguageSelectList = new SelectList(db.ProgrammingLanguages, "Id", "Name")
                };

                return View(empl);
            }

            var employee = db.Employees.Single(e => e.Id == model.Id);
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Sex = model.Sex;
            employee.Years = model.Years;
            employee.DepartmentId = int.Parse(Request.Form["DepartmentSelectList"]);
            employee.ProgrammingLanguageId = int.Parse(Request.Form["ProgrammingLanguageSelectList"]);
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

        public ActionResult AutocompleteSearch(string term)
        {
            var models = db.Employees.Where(e => e.Name.StartsWith(term)).Select(e => e.Name).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}