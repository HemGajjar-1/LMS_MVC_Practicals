using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_13_Part2.Models.DTOs
{
    public class EmployeeFormDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int? DesignationId { get; set; }
        //For dropdown data
        public List<SelectListItem> DesignationList { get; set; }
    }
}