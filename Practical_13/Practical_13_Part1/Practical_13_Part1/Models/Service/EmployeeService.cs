using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Web;
using Antlr.Runtime.Tree;
using Practical_13_Part1.Models.DTOs;
using Practical_13_Part1.Models.Entity;
using Practical_13_Part1.Models.Repository;
namespace Practical_13_Part1.Models.Service
{
    public class EmployeeService
    {
        EmployeeRepository repo = new EmployeeRepository();
        //READ 
        public List<UpdateDto> GetAllEmployees()
        {
            return repo.GetAll().Select(x => new UpdateDto
            {
                Id = x.Id,
                Name = x.Name,
                DOB = x.DOB,
                Age = x.Age
            }).ToList();
        }
        //FIND
        public UpdateDto GetEmployee(int id)
        {
            Employee emp = repo.GetById(id);
            return new UpdateDto
            {
                Id = emp.Id,
                Name = emp.Name,
                DOB = emp.DOB,
                Age = emp.Age
            };
        }
        //CREATE
        public void AddEmployee(CreateDto dto)
        {
            Employee emp = new Employee
            {
                Name = dto.Name,
                DOB = dto.DOB,
                Age = dto.Age
            };
            repo.Add(emp);
        }
        //UPDATE
        public void UpdateEmployee(UpdateDto dto)
        {
            Employee emp = new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                DOB = dto.DOB,
                Age = dto.Age
            };
            repo.Update(emp);
        }
        //DELETE
        public void DeleteEmployee(int id)
        {
            repo.Delete(id);
        }
        //DELETE DTO
        public DeleteDto GetDeleteData(int id)
        {
            Employee emp = repo.GetById(id);
            return new DeleteDto
            {
                Id = emp.Id,
                Name = emp.Name
            };
        }
    }
}