using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int? Years { get; set; }
        public string Sex { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}