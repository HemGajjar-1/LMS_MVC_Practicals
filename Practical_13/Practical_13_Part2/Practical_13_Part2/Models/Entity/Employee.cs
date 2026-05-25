using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_13_Part2.Models.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, StringLength(10)]
        public string MobileNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public int? DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

    }
}