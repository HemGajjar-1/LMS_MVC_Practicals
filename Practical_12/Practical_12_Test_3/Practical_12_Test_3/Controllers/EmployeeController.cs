using Practical_12_Test_3.Models;
using Practical_12_Test_3.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical_12_Test_3.Models.Entity;
namespace Practical_12_Test_3.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService service;

        public EmployeeController()
        {
            service = new EmployeeService();
        }

        // Display Employee List
        public ActionResult Index()
        {
            var employees = service.GetEmployees();

            return View(employees);
        }

        // Create Designation - GET
        public ActionResult CreateDesignation()
        {
            return View();
        }

        // Create Designation - POST
        [HttpPost]
        public ActionResult CreateDesignation(string designation)
        {
            service.InsertDesignation(designation);

            return RedirectToAction("Index");
        }

        // Create Employee - GET
        public ActionResult CreateEmployee()
        {
            ViewBag.Designations = new SelectList(
                service.GetDesignations(),
                "Id",
                "DesignationName"
            );

            return View();
        }

        // Create Employee - POST
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            service.InsertEmployee(employee);

            return RedirectToAction("Index");
        }

        // Search Employee By Designation
        public ActionResult SearchByDesignation()
        {
            EmployeeSearchViewModel model =
                new EmployeeSearchViewModel();

            model.Designations =
                service.GetDesignations()
                       .Select(x => new SelectListItem
                       {
                           Value = x.Id.ToString(),
                           Text = x.DesignationName
                       });

            model.Employees = null;

            return View(model);
        }

        [HttpPost]
        public ActionResult SearchByDesignation(EmployeeSearchViewModel model)
        {
            model.Designations =
                service.GetDesignations()
                       .Select(x => new SelectListItem
                       {
                           Value = x.Id.ToString(),
                           Text = x.DesignationName
                       });

            model.Employees =
                service.GetEmployeesByDesignationId(model.DesignationId);

            return View(model);
        }
        public ActionResult EmployeeDesignationReport()
        {
            var data = service.GetEmployeeDesignationList();

            return View(data);
        }
        public ActionResult DesignationCountReport()
        {
            var data = service.GetDesignationCounts();

            return View(data);
        }
        public ActionResult MultipleEmployeeDesignationReport()
        {
            var data =
                service.GetDesignationsHavingMoreThanOneEmployee();

            return View(data);
        }
        public ActionResult MaxSalaryEmployee()
        {
            var employee = service.GetMaxSalaryEmployee();

            return View(employee);
        }
    }
}