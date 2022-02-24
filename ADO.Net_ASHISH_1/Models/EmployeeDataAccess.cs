using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO.Net_ASHISH_1.Models
{
    public class EmployeeDataAccess
    {
        DbConnetcion Dbconnetcion;
        public EmployeeDataAccess()
        {
            Dbconnetcion = new DbConnetcion();
        }
          public List<Employee> GetEmployees()
        {
            string Sp = "spt_Employee";
            SqlCommand sql = new SqlCommand(Sp,Dbconnetcion.Connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@action","SELECT");
            if (Dbconnetcion.Connection.State == ConnectionState.Closed)
            {
                Dbconnetcion.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (dr.Read())
            {
                Employee Emp = new Employee();
                Emp.id = (int)dr["id"];
                Emp.name = dr["name"].ToString();
                Emp.email = dr["email"].ToString();
                Emp.gender = dr["gender"].ToString();
                Emp.mobile= dr["mobile"].ToString();
               
                employees.Add(Emp);
            }
            Dbconnetcion.Connection.Close();
            return employees;
        }
    }
}
