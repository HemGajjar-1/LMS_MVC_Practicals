using Practical_11.Models.Service;
using Practical_11.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
namespace Practical_11.Controllers
{
    public class PersonController : Controller
    {
        PersonService service = new PersonService();
        
        //READ
        public ActionResult Index()
        {
            var data = service.GetAllPersons();
            return View(data);
        }

        //CREATE GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        //CREATE POST
        [HttpPost]
        public ActionResult Create(Person p)
        {
            p.Id = service.GetAllPersons().Count + 1;
            service.AddPerson(p);
            return RedirectToAction("Index");
        }

        //EDIT GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person p = service.GetPerson(id);
            return View(p);
        }

        //EDIT POST
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            service.UpdatePerson(p);
            return RedirectToAction("Index");
        }

        //DELETE GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person p = service.GetPerson(id);
            return View(p);
        }

        //DELETE POST
        [HttpPost]
        public ActionResult Delete(Person p)
        {
            service.DeletePerson(p.Id);
            return RedirectToAction("Index");
        }
    }
}