using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical_10.Filters;
namespace Practical_10.Controllers.Test4
{
    public class Test4Controller : Controller
    {
        // GET: Test4
        [MyExceptionFilter]
        public ActionResult Index()
        {
            int a = 10;
            int b = 0;
            int c = a / b;
            return Content(c.ToString());
        }
    }
}