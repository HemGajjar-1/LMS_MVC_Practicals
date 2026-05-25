using Practical_13_Part2.Models.DTOs;
using Practical_13_Part2.Models.Entity;
using Practical_13_Part2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_13_Part2.Models.Service
{
    public class DesignationService
    {
        private readonly DesignationRepository repo =
           new DesignationRepository();

        // GET ALL
        public List<DesignationDto> GetAll()
        {
            var data = repo.GetAll();

            return data.Select(x => new DesignationDto
            {
                Id = x.Id,
                DesignationName = x.DesignationName
            }).ToList();
        }

        // GET BY ID
        public DesignationDto GetById(int id)
        {
            var x = repo.GetById(id);

            if (x == null)
                return null;

            return new DesignationDto
            {
                Id = x.Id,
                DesignationName = x.DesignationName
            };
        }

        // INSERT
        public void Add(DesignationDto dto)
        {
            Designation d = new Designation()
            {
                DesignationName = dto.DesignationName
            };

            repo.Add(d);
        }

        // UPDATE
        public void Update(DesignationDto dto)
        {
            Designation d = new Designation()
            {
                Id = dto.Id,
                DesignationName = dto.DesignationName
            };

            repo.Update(d);
        }

        // DELETE
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}                                                                                                                                                                                                                                    