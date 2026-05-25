using Practical_15_Test_2.Models.Entities;
using Practical_15_Test_2.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practical_15_Test_2.Controllers
{
    public class AccountController : Controller
    {
        private AccountService service;

        public AccountController()
        {
            service = new AccountService();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            bool isValid =
                service.ValidateUser(user);

            if (isValid)
            {
                FormsAuthentication
                    .SetAuthCookie(
                        user.UserName,
                        false);

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            ViewBag.Error =
                "Invalid Username or Password";

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction(
                "Login",
                "Account");
        }
    }
}