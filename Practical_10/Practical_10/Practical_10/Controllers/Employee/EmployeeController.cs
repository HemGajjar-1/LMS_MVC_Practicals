using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers.Test1
{
    public class EmployeeController : Controller
    {
        // GET: Test1
        public ActionResult Index(string name="Hem Gajjar (Default Value)")
        {
            ViewBag.var = name;
            return View();
        }
    }
}