using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_11.Models.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
    }
}