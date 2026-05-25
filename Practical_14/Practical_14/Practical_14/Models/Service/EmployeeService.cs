using Practical_14.Models.Data;
using Practical_14.Models.DTOs;
using Practical_14.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
namespace Practical_14.Models.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository repo= new EmployeeRepository();
        //GET ALL
        public List<EmployeeDto> GetAll()
        {
            var data = repo.GetAll();
            return data.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                DOB = x.DOB,
                Age = x.Age
            }).ToList();
        }
        //GET BY ID
        public EmployeeDto GetById(int id)
        {
            var x = repo.GetById(id);
            if (x == null)
            {
                return null;
            }
            return new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                DOB = x.DOB,
                Age = x.Age
            };
        }
        // INSERT
        public void Add(EmployeeDto dto)
        {
            Employee emp = new Employee()
            {
                Name = dto.Name,
                DOB = dto.DOB,
                Age = dto.Age
            };

            repo.Add(emp);
        }

        // UPDATE
        public void Update(EmployeeDto dto)
        {
            Employee emp = new Employee()
            {
                Id = dto.Id,
                Name = dto.Name,
                DOB = dto.DOB,
                Age = dto.Age
            };

            repo.Update(emp);
        }
        //DELETE
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        // SEARCH
        public List<EmployeeDto> SearchByName(string name)
        {
            var data = repo.SearchByName(name);

            return data.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Name = x.Name,
                DOB = x.DOB,
                Age = x.Age
            }).ToList();
        }
        //PAGINATION
        public EmployeeListDto GetEmployees(int page)
        {
            int pageSize = 10;

            var employees = repo
                .GetPagedEmployees(page, pageSize)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    DOB = x.DOB,
                    Age = x.Age
                })
                .ToList();

            int totalRecords =
                repo.GetEmployeeCount();

            int totalPages =
                (int)Math.Ceiling(
                    (double)totalRecords / pageSize);

            return new EmployeeListDto
            {
                Employees = employees,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }


    }
}