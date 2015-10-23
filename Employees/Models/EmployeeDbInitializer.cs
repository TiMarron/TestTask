using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class EmployeeDbInitializer : DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext db)
        {
            var departments = new List<Department>
            {
                new Department { Floor = 5, Name = "Отдел страха и упрека" },
                new Department { Floor = 4, Name = "Отдел откладывания на завтрак" },
                new Department { Floor = 4, Name = "Отдел получения зарплаты" }
            };
            departments.ForEach(d => db.Departments.Add(d));

            var progLangs = new List<ProgrammingLanguage>
            {
                new ProgrammingLanguage { Name = "С#" },
                new ProgrammingLanguage { Name = "php" },
                new ProgrammingLanguage { Name = "python" },
                new ProgrammingLanguage { Name = "perl" },
                new ProgrammingLanguage { Name = "lisp" }
            };
            progLangs.ForEach(pl => db.ProgrammingLanguages.Add(pl));
            db.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { Name = "Имельян", SecondName = "Иванов", Sex = "Мужской", Years = 22, DepartmentId = 1, ProgrammingLanguageId = 2},
                new Employee { Name = "Ростислав", SecondName = "Иванов", Sex = "Мужской", Years = 18, DepartmentId = 2, ProgrammingLanguageId = 1},
                new Employee { Name = "Емеля", SecondName = "Иванов", Sex = "Мужской", Years = 19, DepartmentId = 2, ProgrammingLanguageId = 1},
                new Employee { Name = "Иван", SecondName = "Иванов", Sex = "Мужской", Years = 49, DepartmentId = 3, ProgrammingLanguageId = 1},
                new Employee { Name = "Святогор", SecondName = "Иванов", Sex = "Мужской", Years = 25, DepartmentId = 1, ProgrammingLanguageId = 2}

            };
            employees.ForEach(e => db.Employees.Add(e));
            db.SaveChanges();

            base.Seed(db);
        }
    }
}