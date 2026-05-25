using Practical_12_Test_3.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practical_12_Test_3.Models.Repository
{
    public class EmployeeRepository
    {
        private readonly string conString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM vwEmployeeDetails", con);
               

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dr["EmployeeId"]);
                    employee.FirstName = dr["FirstName"].ToString();
                    employee.MiddleName = dr["MiddleName"].ToString();
                    employee.LastName = dr["LastName"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.DOB = Convert.ToDateTime(dr["DOB"]);
                    employee.MobileNumber = dr["MobileNumber"].ToString();
                    employee.Address = dr["Address"].ToString();
                    employee.Salary = Convert.ToDecimal(dr["Salary"]);

                    employees.Add(employee);
                }
            }

            return employees;
        }

        public void InsertDesignation(string designation)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_InsertDesignation", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Designation", designation);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_InsertEmployee", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName",
                    (object)employee.MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                cmd.Parameters.AddWithValue("@Address",
                    (object)employee.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@DesignationId",
                    (object)employee.DesignationId ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> GetEmployeesByDesignationId(int designationId)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd =
                    new SqlCommand("sp_GetEmployeesByDesignationId", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DesignationId", designationId);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(dr["EmployeeId"]);
                    employee.FirstName = dr["FirstName"].ToString();
                    employee.MiddleName = dr["MiddleName"].ToString();
                    employee.LastName = dr["LastName"].ToString();
                    employee.DOB = Convert.ToDateTime(dr["DOB"]);
                    employee.MobileNumber = dr["MobileNumber"].ToString();
                    employee.Address = dr["Address"].ToString();
                    employee.Salary = Convert.ToDecimal(dr["Salary"]);

                    employees.Add(employee);
                }
            }

            return employees;
        }
        public List<Designation> GetDesignations()
        {
            List<Designation> designations = new List<Designation>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT Id, Designation FROM Designation";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    designations.Add(new Designation
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        DesignationName = dr["Designation"].ToString()
                    });
                }
            }

            return designations;
        }
        public List<EmployeeDesignationDto> GetEmployeeDesignationList()
        {
            List<EmployeeDesignationDto> employees =
                new List<EmployeeDesignationDto>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"
            SELECT
                e.FirstName,
                e.MiddleName,
                e.LastName,
                d.Designation
            FROM Employee e
            INNER JOIN Designation d
                ON e.DesignationId = d.Id";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employees.Add(new EmployeeDesignationDto
                    {
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Designation = dr["Designation"].ToString()
                    });
                }
            }

            return employees;
        }
        public List<DesignationCountDto> GetDesignationCounts()
        {
            List<DesignationCountDto> list =
                new List<DesignationCountDto>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"
            SELECT
                d.Designation,
                COUNT(e.Id) AS EmployeeCount
            FROM Designation d
            LEFT JOIN Employee e
                ON d.Id = e.DesignationId
            GROUP BY d.Designation";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new DesignationCountDto
                    {
                        Designation = dr["Designation"].ToString(),
                        EmployeeCount = Convert.ToInt32(dr["EmployeeCount"])
                    });
                }
            }

            return list;
        }
        public List<DesignationDto> GetDesignationsHavingMoreThanOneEmployee()
        {
            List<DesignationDto> list =
                new List<DesignationDto>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"
            SELECT
                d.Designation
            FROM Designation d
            INNER JOIN Employee e
                ON d.Id = e.DesignationId
            GROUP BY d.Designation
            HAVING COUNT(e.Id) > 1";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new DesignationDto
                    {
                        Designation = dr["Designation"].ToString()
                    });
                }
            }

            return list;
        }
        public Employee GetMaxSalaryEmployee()
        {
            Employee employee = null;

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = @"
            SELECT TOP 1
                e.Id,
                e.FirstName,
                e.MiddleName,
                e.LastName,
                d.Designation,
                e.DOB,
                e.MobileNumber,
                e.Address,
                e.Salary
            FROM Employee e
            LEFT JOIN Designation d
                ON e.DesignationId = d.Id
            ORDER BY e.Salary DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    employee = new Employee
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Designation = dr["Designation"].ToString(),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salary = Convert.ToDecimal(dr["Salary"])
                    };
                }
            }

            return employee;
        }
    }
}