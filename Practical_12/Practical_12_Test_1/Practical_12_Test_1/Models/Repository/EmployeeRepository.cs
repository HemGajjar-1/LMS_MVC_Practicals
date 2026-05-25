using Practical_12_Test_1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practical_12_Test_1.Models.Repository
{
    public class EmployeeRepository
    {
        private string connection_string = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("select * from employee", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Employee
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString()

                    });
                }
                return list;
            }
        }
        public void Insert(Employee emp)
        {

            using(SqlConnection con = new SqlConnection(connection_string))
            {
                string query = @"INSERT INTO EMPLOYEE (FIRSTNAME,MIDDLENAME,LASTNAME,DOB,MOBILENUMBER,ADDRESS) VALUES (@firstname,@middlename,@lastname,@dob,@mobilenumber,@address)";
                SqlCommand cmd = new SqlCommand(query,con);

                cmd.Parameters.AddWithValue("@firstname", emp.FirstName);
                cmd.Parameters.AddWithValue("@middlename", (object) emp.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@lastname", emp.LastName);
                cmd.Parameters.AddWithValue("@dob", emp.DOB);
                cmd.Parameters.AddWithValue("@mobilenumber", emp.MobileNumber);
                cmd.Parameters.AddWithValue("@address", (object) emp.Address ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateFirstName()
        {

            using(SqlConnection con = new SqlConnection(connection_string))
            {
                string query = @"UPDATE EMPLOYEE SET FIRSTNAME = 'SQLPerson' WHERE ID=1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateMiddleName()
        {

            using(SqlConnection con = new SqlConnection(connection_string))
            {
                string query = @"UPDATE EMPLOYEE SET MIDDLENAME = 'I'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteLessThanTwo()
        {

            using(SqlConnection con = new SqlConnection(connection_string))
            {
                string query = @"DELETE FROM EMPLOYEE WHERE ID<2";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteAll()
        {

            using(SqlConnection con = new SqlConnection(connection_string))
            {
                string query = @"TRUNCATE TABLE EMPLOYEE";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}