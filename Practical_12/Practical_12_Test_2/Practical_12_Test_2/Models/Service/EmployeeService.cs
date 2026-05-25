using Practical_12_Test_2.Models.Entity;
using Practical_12_Test_2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_12_Test_2.Models.Service
{
    public class EmployeeService
    {
        EmployeeRepository repo = new EmployeeRepository();
        public List<Employee> GetAll()
        {
            return repo.GetAll();
        }
        public void Insert(Employee emp)
        {
            repo.Insert(emp);
        }
        public decimal TotalSalary()
        {
            return repo.TotalSalary();
        }
        public List<Employee> BelowData()
        {
            return repo.BelowDate();
        }
        public int MiddleNameCount()
        {
            return repo.MiddleNameCount();
        }
    }
}