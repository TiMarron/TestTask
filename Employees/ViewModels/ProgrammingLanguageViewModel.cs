using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employees.ViewModels
{
    public class ProgrammingLanguageViewModel
    {
        [Required(ErrorMessage="Укажите название языка")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}