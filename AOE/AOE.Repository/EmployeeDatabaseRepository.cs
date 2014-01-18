using AOE.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AOE.Repository
{
    public class EmployeeDatabaseRepository : IEmployeeRepository
    {
        private string _connectionString;

        public EmployeeDatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Job> GetJobList()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetJobList", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                List<Job> jobs = new List<Job>();
                while (reader.Read())
                {
                    jobs.Add(new Job()
                    {
                        Id = (int)reader["JobId"],
                        Name = (string)reader["JobName"]
                    });
                }
                return jobs;
            }
        }

        public EmployeeListModel GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeList", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@JobId", SqlDbType.Int).Value = employeeListRequest.JobId;
                command.Parameters.Add("@SortExpression", SqlDbType.NVarChar, 50).Value = employeeListRequest.SortExpression;
                command.Parameters.Add("@PageIndex", SqlDbType.Int).Value = employeeListRequest.PageIndex;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = employeeListRequest.PageSize;
                command.Parameters.Add("@EmployeeVirtualCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    employees.Add(new Employee() 
                    {
                        Id = (int)reader["EmployeeId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Salary = (double)reader["Salary"]
                    });
                }
                reader.Close();
                return new EmployeeListModel() 
                {
                    Employees = employees,
                    EmployeeVirtualCount = (int)command.Parameters["@EmployeeVirtualCount"].Value
                };
            }
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeUpdateRequest.EmployeeId;
                command.Parameters.Add("@Salary", SqlDbType.Float).Value = employeeUpdateRequest.Salary;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
