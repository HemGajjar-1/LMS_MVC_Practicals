using Practical_12_Test_2.Models.Entity;
using Practical_12_Test_2.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_Test_2.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService _service = new EmployeeService();
        public ActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public ActionResult Create(Employee emp)
        {
            _service.Insert(emp);
            return RedirectToAction("Index");
        }
        public ActionResult TotalSalary()
        {
            ViewBag.TotalSalary = _service.TotalSalary();
            return View("Index",_service.GetAll());
        }
        public ActionResult BelowDate()
        {
            return View("Index", _service.BelowData());
        }
        public ActionResult MiddleNameCount()
        {
            ViewBag.MiddleNameCount = _service.MiddleNameCount();
            return View("Index",_service.GetAll());
        }
    }
}