using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Practical_13_Part2.Models.Entity
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string DesignationName { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}