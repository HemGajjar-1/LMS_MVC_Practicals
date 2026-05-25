using Practical_11_Test_2.Models.Repository;
using Practical_11_Test_2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_11_Test_2.Models.Service
{
    public class PersonService
    {
        PersonRepository repo = new PersonRepository();
        public List<Person> GetAllPersons()
        {
            return repo.GetAll();
        }
        public Person GetPerson(int id)
        {
            return repo.GetById(id);
        }
        public void AddPerson(Person p)
        {
            repo.Add(p);
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