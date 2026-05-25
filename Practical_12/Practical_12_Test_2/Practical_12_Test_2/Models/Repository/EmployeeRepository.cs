using Practical_12_Test_2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practical_12_Test_2.Models.Repository
{
    public class EmployeeRepository
    {
        string connection_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<Employee> GetAll()
        {
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Employee> list = new List<Employee>();
                while(dr.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString() ,
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salary = (decimal)dr["Salary"]
                    });
                }
                return list;
            }
        }
        public void Insert(Employee emp)
        {
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE (FIRSTNAME,MIDDLENAME,LASTNAME,DOB,MOBILENUMBER,ADDRESS,SALARY) VALUES (@firstname,@middlename,@lastname,@dob,@mobilenumber,@address,@salary)",con);
                cmd.Parameters.AddWithValue("@firstname", emp.FirstName);
                cmd.Parameters.AddWithValue("@middlename",(object) emp.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@lastname", emp.LastName);
                cmd.Parameters.AddWithValue("@dob", emp.DOB);
                cmd.Parameters.AddWithValue("@mobilenumber", emp.MobileNumber);
                cmd.Parameters.AddWithValue("@address", (object)emp.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public decimal TotalSalary()
        {
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(SALARY) FROM EMPLOYEE",con);
                con.Open();
                var sum = cmd.ExecuteScalar();
                return (Decimal)sum;
            }
        }
        public List<Employee> BelowDate()
        {
            List<Employee> list = new List<Employee>();
            using(SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEE WHERE DOB < @date",con);
                cmd.Parameters.AddWithValue("@date", new DateTime(2000, 1, 1));

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"] as string,
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"] as string,
                        Salary = (decimal)dr["Salary"]
                    });
                }
                return list;
            }
        }
        public int MiddleNameCount()
        {
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM EMPLOYEE WHERE MIDDLENAME IS NULL", con);
                con.Open();
                var result = cmd.ExecuteScalar();
                return (int)result;
            }
        }
    }
}