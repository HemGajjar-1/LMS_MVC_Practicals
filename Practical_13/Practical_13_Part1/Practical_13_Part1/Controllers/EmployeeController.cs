using Practical_13_Part1.Models.DTOs;
using Practical_13_Part1.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Practical_13_Part1.Controllers
{
    public class EmployeeController :Controller
    {
        EmployeeService service = new EmployeeService();
        //READ
        public ActionResult Index()
        {
            return View(service.GetAllEmployees());
        }

        //CREATE GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        public ActionResult Create(CreateDto dto)
        {
            service.AddEmployee(dto);
            return RedirectToAction("Index");
        }

        //EDIT GET
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.GetEmployee(id));
        }

        //EDIT POST
        [HttpPost]
        public ActionResult Edit(UpdateDto dto)
        {
            service.UpdateEmployee(dto);
            return RedirectToAction("Index");
        }

        //DELETE GET
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(service.GetDeleteData(id));
        }

        //DELETE POST
        [HttpPost]
        public ActionResult Delete(DeleteDto dto)
        {
            service.DeleteEmployee(dto.Id);
            return RedirectToAction("Index");
        }
    }
}