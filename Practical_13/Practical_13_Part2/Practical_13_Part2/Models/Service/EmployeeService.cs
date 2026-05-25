using Practical_13_Part2.Models.DTOs;
using Practical_13_Part2.Models.Entity;
using Practical_13_Part2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_13_Part2.Models.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository = new EmployeeRepository();
        private readonly DesignationRepository designationRepository = new DesignationRepository();

        //GET ALL
        public List<EmployeeDto> GetAll()
        {
            var data = employeeRepository.GetAll();
            return data.Select(x => new EmployeeDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                DOB = x.DOB,
                MobileNumber = x.MobileNumber,
                Address = x.Address,
                Salary = x.Salary,
                DesignationId = x.DesignationId,
                DesignationName = x.Designation != null ? x.Designation.DesignationName : ""

            }).ToList();
        }
        //GET BY ID
        public EmployeeFormDto GetById(int id)
        {
            var x = employeeRepository.GetById(id);

            if (x == null)
                return null;

            return new EmployeeFormDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                DOB = x.DOB,
                MobileNumber = x.MobileNumber,
                Address = x.Address,
                Salary = x.Salary,
                DesignationId = x.DesignationId,
                DesignationList = GetDesignationDropdown()
            };
        }

        //INSERT
        public void Add(EmployeeFormDto dto)
        {
            Employee emp = new Employee()
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                DOB = dto.DOB,
                MobileNumber = dto.MobileNumber,
                Address = dto.Address,
                Salary = dto.Salary,
                DesignationId = dto.DesignationId
            };

            employeeRepository.Add(emp);
        }

        //UPDATE
        public void Update(EmployeeFormDto dto)
        {
            Employee emp = new Employee()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                DOB = dto.DOB,
                MobileNumber = dto.MobileNumber,
                Address = dto.Address,
                Salary = dto.Salary,
                DesignationId = dto.DesignationId
            };

            employeeRepository.Update(emp);
        }

        //DELETE
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

        //DROPDOWN
        public List<SelectListItem> GetDesignationDropdown()
        {
            return designationRepository.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.DesignationName
                }).ToList();
        }

        //CREATE FORM
        public EmployeeFormDto GetCreateModel()
        {
            return new EmployeeFormDto()
            {
                DesignationList = GetDesignationDropdown()
            };
        }

    }
}