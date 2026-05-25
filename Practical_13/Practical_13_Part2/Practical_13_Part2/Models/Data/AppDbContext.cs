using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using Practical_13_Part2.Models.Entity;
using System.Data.Entity;
namespace Practical_13_Part2.Models.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base("name=MyConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }

    }
}