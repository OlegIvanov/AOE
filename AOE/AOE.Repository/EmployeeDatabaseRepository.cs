using AOE.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace AOE.Repository
{
    public class EmployeeDatabaseRepository : IEmployeeRepository
    {
        private string _connectionString;

        public EmployeeDatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public JobListResponse GetJobList()
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
                return new JobListResponse()
                {
                    Jobs = jobs
                };
            }
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
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
                        FullName = (string)reader["FullName"],
                        Salary = (double)reader["Salary"]
                    });
                }
                reader.Close();
                return new EmployeeListResponse() 
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
