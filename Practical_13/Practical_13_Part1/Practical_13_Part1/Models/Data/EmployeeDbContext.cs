using Practical_13_Part1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_13_Part1.Models.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext() : base("MyConnection") { }
        public DbSet<Employee> Employees { get; set; }
    }
}