using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees.ViewModels
{
    public class EmployeesListViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }
        [DisplayName("Возраст")]
        public int Years { get; set; }
        [DisplayName("Отдел")]
        public string Department { get; set; }
        [DisplayName("Язык")]
        public string ProgrammingLanguage { get; set; }
    }
}
