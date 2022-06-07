using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollWithADODotNet
{
    public class EmpRepository
    {
        private SqlConnection connect;    
        private void Connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=payroll_service";
            connect = new SqlConnection(connectingString);
        }
        public bool AddEmployee(EmployeeDetails obj)
        {
            Connection();
            SqlCommand command = new SqlCommand("spAddEmployee", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", obj.Id);
            command.Parameters.AddWithValue("@Name", obj.Name);
            command.Parameters.AddWithValue("@Salary", obj.Salary);
            command.Parameters.AddWithValue("@StartDate", obj.Startdate);
            command.Parameters.AddWithValue("@Gender", obj.Gender);
            command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            command.Parameters.AddWithValue("@Department", obj.Department);
            command.Parameters.AddWithValue("@Deduction", obj.Deduction);
            command.Parameters.AddWithValue("@Taxable_Pay", obj.Taxable_Pay);
            command.Parameters.AddWithValue("@Net_Pay", obj.Net_Pay);
            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<EmployeeDetails> RetrieveEmployeeData()
        {
            Connection();
            List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
            SqlCommand commmand = new SqlCommand("spGetAllEmployees", connect);
            commmand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(commmand);
            DataTable table = new DataTable();
            connect.Open();
            da.Fill(table);
            connect.Close();
            foreach (DataRow data in table.Rows)
            {
                EmployeeList.Add(
                    new EmployeeDetails
                    {
                        Id = Convert.ToInt32(data["Id"]),
                        Name = Convert.ToString(data["Name"]),
                        Salary = Convert.ToInt32(data["Salary"]),
                        Startdate = Convert.ToDateTime(data["StartDate"]),
                        Gender = Convert.ToString(data["Gender"]),
                        PhoneNumber = Convert.ToInt32(data["PhoneNumber"]),
                        Department = Convert.ToString(data["Department"]),
                        Deduction = Convert.ToInt32(data["Deductions"]),
                        Taxable_Pay = Convert.ToInt32(data["Taxable_Pay"]),
                        Net_Pay = Convert.ToInt32(data["Net_Pay"])
                    }
                    );
            }
            return EmployeeList;
        }
        public bool UpdateEmployeeSalary(EmployeeDetails obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("spUpdateEmployee", connect);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            connect.Open();
            int result = com.ExecuteNonQuery();
            connect.Close();
            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteEmployeeDetails(EmployeeDetails emp)
        {
            Connection();
            SqlCommand command = new SqlCommand("spDeleteEmployee", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", emp.Id);
            command.Parameters.AddWithValue("@Name", emp.Name);
            connect.Open();
            int result = command.ExecuteNonQuery();
            connect.Close();
            if(result >= 1)
            {
                Console.WriteLine("Employee details deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete employee details");
            }
        }
        public bool RetrieveEmployeesVByDataRange(DateTime date)
        {
            Connection();
            SqlCommand command = new SqlCommand("spRetrieveByDataRange",connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Startdate", date);
            connect.Open();
            int result = command.ExecuteNonQuery();
            connect.Close();
            if( result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
