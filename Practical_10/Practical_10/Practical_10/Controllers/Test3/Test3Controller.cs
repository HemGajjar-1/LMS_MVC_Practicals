using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers.Test3
{
    public class Test3Controller : Controller
    {
        // GET: Test3
        [OutputCache (Duration =300)]
        public ActionResult Index()
        {
            string str = DateTime.Now.ToString();
            ViewBag.Time = str;
            return View();
        }
    }
}