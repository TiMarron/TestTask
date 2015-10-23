using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employees.ViewModels
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Укажите название отдела!")]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите этаж!")]
        [DisplayName("Этаж, №")]
        public int Floor { get; set; }
    }
}