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

        public List<Job> FindAllJobs()
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

        public List<Employee> FindBy(EmployeeQuery employeeQuery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeList", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@JobId", SqlDbType.Int).Value = employeeQuery.JobId;
                command.Parameters.Add("@SortExpression", SqlDbType.NVarChar, 50).Value = employeeQuery.SortExpression;
                command.Parameters.Add("@PageIndex", SqlDbType.Int).Value = employeeQuery.PageIndex;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = employeeQuery.PageSize;

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    return GetEmployeeCollectionFromReader(reader);
                }
            }
        }

        public int GetCountByJobId(int jobId)
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

        public Employee FindBy(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeByEmployeeId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("EmployeeId", SqlDbType.Int).Value = employeeId;

                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                { 
                    return GetEmployeeCollectionFromReader(reader).First();
                }
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employee.Id;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = employee.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = employee.LastName;
                command.Parameters.Add("@Salary", SqlDbType.Float).Value = employee.Salary;

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
