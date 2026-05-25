using Practical_11_Test_2.Models.Entity;
using Practical_11_Test_2.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_11_Test_2.Models.Repository
{
    public class PersonRepository
    {
        public List<Person> GetAll()
        {
            return PersonData.persons;
        } 
        public Person GetById(int id)
        {
            return PersonData.persons.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Person p)
        {
            PersonData.persons.Add(p);
        }
        public void Update(Person p)
        {
            Person old = GetById(p.Id);
            old.Name = p.Name;
            old.DOB = p.DOB;
            old.Address = p.Address;
        }
        public void Delete(int id)
        {
            Person p = GetById(id);
            PersonData.persons.Remove(p);
        }
    }
}