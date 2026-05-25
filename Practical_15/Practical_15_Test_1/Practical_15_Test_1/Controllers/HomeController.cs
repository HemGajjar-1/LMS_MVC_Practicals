using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_15_Test_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string userName = User.Identity.Name;

            string cs =
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    @"INSERT INTO UserLog(UserName,LoginDate)
              VALUES(@UserName,GETDATE())";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@UserName",
                    userName);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            ViewBag.UserName = userName;

            return View();
        }
    }
}