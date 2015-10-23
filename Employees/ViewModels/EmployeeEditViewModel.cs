using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees.ViewModels
{
    public class EmployeeEditViewModel
    {
        [Required]
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Give the man a name")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите фамилию!")]
        [DisplayName("Фамилия")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Укажите возраст!")]
        [DisplayName("Возраст")]
        public int Years { get; set; }
        [Required(ErrorMessage = "Укажите пол!")]
        [DisplayName("Пол")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Укажите отдел!")]
        [DisplayName("Отдел")]
        public IEnumerable<SelectListItem> DepartmentSelectList { get; set; }
        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "Укажите язык!")]
        [DisplayName("Язык")]
        public IEnumerable<SelectListItem> ProgrammingLanguageSelectList { get; set; }
        public int? ProgrammingLanguageId { get; set; }
    }
}