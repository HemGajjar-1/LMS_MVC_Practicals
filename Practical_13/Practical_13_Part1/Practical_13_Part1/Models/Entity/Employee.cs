using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical_13_Part1.Models.Entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName="varchar")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName="date")]
        public DateTime DOB { get; set; }

        public int? Age { get; set; }
    }
}