using Practical_15_Test_2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practical_15_Test_2.Models.Repository
{
    public class AccountRepository
    {
        private readonly string conString =
            ConfigurationManager
            .ConnectionStrings["DbConnection"]
            .ConnectionString;

        public bool ValidateUser(User user)
        {
            using (SqlConnection con =
                new SqlConnection(conString))
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE UserName=@UserName
                    AND Password=@Password";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@UserName",
                    user.UserName);

                cmd.Parameters.AddWithValue(
                    "@Password",
                    user.Password);

                con.Open();

                int count =
                    (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}