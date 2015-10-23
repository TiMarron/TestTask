using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}