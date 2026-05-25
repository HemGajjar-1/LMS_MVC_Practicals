using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_9.Controllers
{
    public class Test3Controller : Controller
    {
        // GET: Test3
        public ActionResult Index()
        {
            ViewBag.hello = "Hello World";
            return View();
        }
    }
}