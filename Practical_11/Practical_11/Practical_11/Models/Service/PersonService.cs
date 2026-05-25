using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practical_11.Models.Entity;
using Practical_11.Models.Repository;

namespace Practical_11.Models.Service
{
    public class PersonService
    {
        PersonRepository repo = new PersonRepository();
        public List<Person> GetAllPersons()
        {
            return repo.GetAll();
        }
        public void AddPerson(Person p)
        {
            repo.Add(p);
        }
        public Person GetPerson(int id)
        {
            return repo.GetById(id);
        }
        public void UpdatePerson(Person p)
        {
            repo.Update(p);
        }
        public void DeletePerson(int id)
        {
            repo.Delete(id);
        }

    }
}