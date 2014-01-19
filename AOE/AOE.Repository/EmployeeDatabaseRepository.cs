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

                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetJobCollectionFromReader(reader);
                }
            }
        }

        public List<Employee> GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeList", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@JobId", SqlDbType.Int).Value = employeeListRequest.JobId;
                command.Parameters.Add("@SortExpression", SqlDbType.NVarChar, 50).Value = employeeListRequest.SortExpression;
                command.Parameters.Add("@PageIndex", SqlDbType.Int).Value = employeeListRequest.PageIndex;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = employeeListRequest.PageSize;

                connection.Open();
                
                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetEmployeeCollectionFromReader(reader);
                }
            }
        }

        public int GetEmployeeCountByJobId(int jobId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeCountByJobId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("JobId", SqlDbType.Int).Value = jobId;

                connection.Open();

                return (int)command.ExecuteScalar();
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

        private List<Job> GetJobCollectionFromReader(IDataReader dataReader)
        {
            List<Job> jobs = new List<Job>();

            while (dataReader.Read())
            {
                jobs.Add(new Job
                {
                    Id = (int)dataReader["JobId"],
                    Name = (string)dataReader["JobName"]
                });
            }

            return jobs;
        }

        private List<Employee> GetEmployeeCollectionFromReader(IDataReader dataReader)
        {
            List<Employee> employees = new List<Employee>();

            while (dataReader.Read())
            {
                employees.Add(new Employee
                {
                    Id = (int)dataReader["EmployeeId"],
                    FirstName = (string)dataReader["FirstName"],
                    LastName = (string)dataReader["LastName"],
                    Salary = (double)dataReader["Salary"]
                });
            }

            return employees;
        }
    }
}
