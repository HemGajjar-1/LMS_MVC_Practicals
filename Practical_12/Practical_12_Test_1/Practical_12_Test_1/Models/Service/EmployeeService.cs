using Practical_12_Test_1.Models.Entity;
using Practical_12_Test_1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_12_Test_1.Models.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository repo = new EmployeeRepository();
        public List<Employee> GetAll()
        {
            return repo.GetAll();
        }
        public void Insert(Employee emp)
        {
            repo.Insert(emp);
        }
        public void UpdateFirstName()
        {
            repo.UpdateFirstName();
        }
        public void UpdateMiddleName()
        {
            repo.UpdateMiddleName();
        }
        public void DeleteLessThanTwo()
        {
            repo.DeleteLessThanTwo();
        }
        public void DeleteAll()
        {
            repo.DeleteAll();
        }

    }
}