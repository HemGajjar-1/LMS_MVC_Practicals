using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical_14.Models.Data;
namespace Practical_14.Models.Repository
{
    public class EmployeeRepository
    {
        private readonly Practical14DbEntities db= new Practical14DbEntities();

        //GET ALL
        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
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
                existing.Name = emp.Name;
                existing.DOB = emp.DOB;
                existing.Age = emp.Age;

                db.SaveChanges();
            }
        }
        //DELETE
        public void Delete(int id)
        {
            var emp = db.Employees.Find(id);
            if(emp!=null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
        }
        //SEARCH
        public List<Employee> SearchByName(string name)
        {
            return db.Employees.Where(x => x.Name.Contains(name)).ToList();
        }
        //PAGINATION
        public List<Employee> GetPagedEmployees(int page,int pageSize)
        {
            return db.Employees
                     .OrderBy(x => x.Id)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
        }
        public int GetEmployeeCount()
        {
            return db.Employees.Count();
        }
    }
}