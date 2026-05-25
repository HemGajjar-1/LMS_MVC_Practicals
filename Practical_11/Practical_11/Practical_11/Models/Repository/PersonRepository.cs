using System;
using System.Collections.Generic;
using Practical_11.Models.Data;
using Practical_11.Models.Entity;
using System.Linq;
using System.Web;

namespace Practical_11.Models.Repository
{
    public class PersonRepository
    {
        //READ
        public List<Person> GetAll()
        {
            return PersonData.persons;
        }

        //CREATE
        public void Add(Person p)
        {
            PersonData.persons.Add(p);
        }

        //FIND
        public Person GetById(int id)
        {
            return PersonData.persons.FirstOrDefault(x => x.Id == id);
        }

        //UPDATE
        public void Update(Person p)
        {
            Person old = GetById(p.Id);
            old.Name = p.Name;
            old.DOB = p.DOB;
            old.Address = p.Address;
        }

        //DELETE
        public void Delete(int id)
        {
            Person p = GetById(id);
            PersonData.persons.Remove(p);
        }
    }
}