using Practical_13_Part1.Models.Data;
using Practical_13_Part1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_13_Part1.Models.Repository
{
    public class EmployeeRepository
    {
        EmployeeDbContext db = new EmployeeDbContext();

        //READ
        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        //FIND
        public Employee GetById(int id)
        {
            return db.Employees.Find(id);
        }

        //CREATE
        public void Add(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }

        //UPDATE
        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
        }

        //DELETE
        public void Delete(int id)
        {
            Employee emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
        }
    }
}