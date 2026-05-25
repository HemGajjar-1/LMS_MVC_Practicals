using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers.Test2
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult ViewDemo()
        {
            return View("ViewDemo");
        }
        public ContentResult ContentDemo()
        {
            return Content("Hello");
        }
        public JsonResult JsonDemo()
        {
            var data = new
            {
                FirstName = "Hem",
                LastName = "Gajjar"
            };
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public EmptyResult EmptyDemo()
        {
            return new EmptyResult();
        }
        public FileResult FileDemo()
        {
            return File("~/Content/DemoFile.txt","text/plain","sample.txt");
        }
        public RedirectResult RedirectResultDemo()
        {
            return Redirect("https://www.youtube.com/");
        }
        public RedirectToRouteResult RedirectToActionDemo()
        {
            return RedirectToAction("Index");
        }
    }
}