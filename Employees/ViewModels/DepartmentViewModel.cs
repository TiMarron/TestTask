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
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Этаж, №")]
        public int Floor { get; set; }
    }
}