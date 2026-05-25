using Practical_12_Test_3.Models.DTOs;
using Practical_12_Test_3.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_12_Test_3.Models.Service
{
    public class EmployeeService
    {
        private EmployeeRepository repository;

        public EmployeeService()
        {
            repository = new EmployeeRepository();
        }

        public List<Employee> GetEmployees()
        {
            return repository.GetEmployees();
        }

        public void InsertDesignation(string designation)
        {
            repository.InsertDesignation(designation);
        }

        public void InsertEmployee(Employee employee)
        {
            repository.InsertEmployee(employee);
        }

        public List<Employee> GetEmployeesByDesignationId(int designationId)
        {
            return repository.GetEmployeesByDesignationId(designationId);
        }
        public List<Designation> GetDesignations()
        {
            return repository.GetDesignations();
        }
        public List<EmployeeDesignationDto> GetEmployeeDesignationList()
        {
            return repository.GetEmployeeDesignationList();
        }
        public List<DesignationCountDto> GetDesignationCounts()
        {
            return repository.GetDesignationCounts();
        }
        public List<DesignationDto> GetDesignationsHavingMoreThanOneEmployee()
        {
            return repository.GetDesignationsHavingMoreThanOneEmployee();
        }
        public Employee GetMaxSalaryEmployee()
        {
            return repository.GetMaxSalaryEmployee();
        }
    }
}