using RepositoryPatternWithADO.Net.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryPatternWithADO.Net.Repository
{
    public class MockEmployee : IEmployee
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

        public IList<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Employee()
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Position = rdr["Position"].ToString(),
                        Office = rdr["Office"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        Salary = Convert.ToInt32(rdr["Salary"])
                    };
                    employees.Add(employee);
                }
                return (employees);
            }
        }

        public Employee GetEmployeeById(int? id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Position = rdr["Position"].ToString();
                    employee.Office = rdr["Office"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                }
                return employee;
            }
        }

        public void InsertNew(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spAddNew", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@Office", employee.Office);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@Office", employee.Office);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}