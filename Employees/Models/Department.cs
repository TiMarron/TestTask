using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Floor { get; set; }
        public int EmployeeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}