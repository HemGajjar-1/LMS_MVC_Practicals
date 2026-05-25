using Practical_13_Part2.Models.Data;
using Practical_13_Part2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_13_Part2.Models.Repository
{
    public class DesignationRepository
    {
        private readonly AppDbContext db = new AppDbContext();

        //GET ALL
        public List<Designation> GetAll()
        {
            return db.Designations.ToList();
        }

        //GET BY ID
        public Designation GetById(int id)
        {
            return db.Designations.Find(id);
        }

        // INSERT
        public void Add(Designation designation)
        {
            db.Designations.Add(designation);
            db.SaveChanges();
        }

        //UPDATE
        public void Update(Designation designation)
        {
            var existing = db.Designations.Find(designation.Id);
            if(existing !=null)
            {
                existing.DesignationName = designation.DesignationName;
                db.SaveChanges();
            }
        }

        //DELETE
        public void Delete(int id)
        {
            var data = db.Designations.Find(id);
            if (data != null)
            {
                db.Designations.Find(id);
                db.SaveChanges();
            }
        }
    }
}