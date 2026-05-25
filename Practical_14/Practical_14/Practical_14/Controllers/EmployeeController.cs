using Practical_14.Models.DTOs;
using Practical_14.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_14.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService service =
            new EmployeeService();

        // INDEX
        public ActionResult Index(int page = 1)
        {
            var data = service.GetEmployees(page);

            return View(data);
        }

        //SEARCH
        [HttpGet]
        public ActionResult Search(string name)
        {
            var data = service.SearchByName(name);

            return PartialView("_EmployeeList", data);
        }

        // CREATE GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public ActionResult Create(EmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Add(dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }

        // EDIT GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = service.GetById(id);

            return View(data);
        }

        // EDIT POST
        [HttpPost]
        public ActionResult Edit(EmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Update(dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }

        // DELETE GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = service.GetById(id);

            return View(data);
        }

        // DELETE POST
        [HttpPost]
        public ActionResult Delete(EmployeeDto dto)
        {
            service.Delete(dto.Id);

            return RedirectToAction("Index");
        }
    }
}