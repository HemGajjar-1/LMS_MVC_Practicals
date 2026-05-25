using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_Test_3.Models.Entity
{
    public class EmployeeSearchViewModel
    {
        public int DesignationId { get; set; }

        public List<Employee> Employees { get; set; }

        public IEnumerable<SelectListItem> Designations { get; set; }
    }
}