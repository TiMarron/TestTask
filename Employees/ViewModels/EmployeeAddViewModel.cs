using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using Employees.Models;

namespace Employees.ViewModels
{
    public class EmployeeAddViewModel
    {
        [Required(ErrorMessage = "Give the man a name")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите фамилию!")]
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Укажите возраст!")]
        [DisplayName("Возраст")]
        public int? Years { get; set; }
        [Required(ErrorMessage = "Укажите пол!")]
        [DisplayName("Пол")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Укажите отдел!")]
        [DisplayName("Отдел")]
        public int? DepartmentId { get; set; }
        public virtual IEnumerable<Department> DepartmentList { get; set; }
        [Required(ErrorMessage = "Укажите язык!")]
        [DisplayName("Язык")]
        public int? ProgrammingLanguageId { get; set; }
        public virtual IEnumerable<ProgrammingLanguage> ProgrammingLanguageList { get; set; }
    }
}