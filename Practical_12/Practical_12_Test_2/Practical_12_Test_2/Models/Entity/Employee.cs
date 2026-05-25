using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_12_Test_2.Models.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(10,MinimumLength =10)]
        [RegularExpression(@"^[0-9]{10}$")]
        public string MobileNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}