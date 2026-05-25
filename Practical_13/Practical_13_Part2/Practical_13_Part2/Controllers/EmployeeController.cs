using Practical_13_Part2.Models.DTOs;
using Practical_13_Part2.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_13_Part2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService service =
            new EmployeeService();

        // INDEX
        public ActionResult Index()
        {
            var data = service.GetAll();

            return View(data);
        }

        // CREATE GET
        [HttpGet]
        public ActionResult Create()
        {
            var model = service.GetCreateModel();

            return View(model);
        }

        // CREATE POST
        [HttpPost]
        public ActionResult Create(EmployeeFormDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Add(dto);

                return RedirectToAction("Index");
            }

            dto.DesignationList = service.GetDesignationDropdown();

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
        public ActionResult Edit(EmployeeFormDto dto)
        {
            if (ModelState.IsValid)
            {
                service.Update(dto);

                return RedirectToAction("Index");
            }

            dto.DesignationList = service.GetDesignationDropdown();

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
        public ActionResult Delete(EmployeeFormDto dto)
        {
            service.Delete(dto.Id);

            return RedirectToAction("Index");
        }
    }
}