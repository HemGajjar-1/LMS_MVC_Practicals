using Practical_12_Test_1.Models.Entity;
using Practical_12_Test_1.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_Test_1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service = new EmployeeService();
        public ActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                var data = _service.GetAll();
                return View("Index",data);
            }
            _service.Insert(emp);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateFirstName()
        {
            _service.UpdateFirstName();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateMiddleName()
        {
            _service.UpdateMiddleName();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteLessThanTwo()
        {
            _service.DeleteLessThanTwo();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAll()
        {
            _service.DeleteAll();
            return RedirectToAction("Index");
        }
    }
}