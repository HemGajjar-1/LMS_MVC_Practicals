using Practical_13_Part2.Models.Data;
using Practical_13_Part2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_13_Part2.Models.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db = new AppDbContext();
        
        //GET ALL (with designation included in LINQ later)
        public List<Employee> GetAll()
        {
            return db.Employees.Include("Designation").ToList();
        }

        //GET BY ID
        public Employee GetById(int id)
        {
            return db.Employees.Find(id);
        }

        //INSERT
        public void Add(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }

        //UPDATE
        public void Update(Employee emp)
        {
            var existing = db.Employees.Find(emp.Id);
            if(existing != null)
            {
                existing.FirstName = emp.FirstName;
                existing.MiddleName = emp.MiddleName;
                existing.LastName = emp.LastName;
                existing.DOB = emp.DOB;
                existing.MobileNumber = emp.MobileNumber;
                existing.Address = emp.Address;
                existing.Salary = emp.Salary;
                existing.DesignationId = emp.DesignationId;

                db.SaveChanges();
            }
        }

        //DELETE
        public void Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if(emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
    }
}