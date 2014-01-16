using AOE.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeList", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@JobId", SqlDbType.Int).Value = employeeListRequest.JobId;
                command.Parameters.Add("@SortExpression", SqlDbType.NVarChar, 50).Value = GetSortExpression(employeeListRequest.SortColumn, employeeListRequest.SortOrder);
                command.Parameters.Add("@PageIndex", SqlDbType.Int).Value = employeeListRequest.PageIndex;
                command.Parameters.Add("@PageSize", SqlDbType.Int).Value = employeeListRequest.PageSize;
                command.Parameters.Add("@EmployeeVirtualCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                connection.Open();
                IDataReader reader = ExecuteReader(command);
                IList<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    employees.Add(new Employee() 
                    {
                        Id = (int)reader["EmployeeId"],
                        FullName = (string)reader["FullName"],
                        Salary = (double)reader["Salary"]
                    });
                }
                return new EmployeeListResponse() 
                { 
                    Employees = employees,
                    EmployeeVirtualCount = (int)command.Parameters["@EmployeeVirtualCount"].Value
                };
            }
        }

        public JobListResponse GetJobList()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetJobList", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                IDataReader reader = ExecuteReader(command);
                IList<Job> jobs = new List<Job>();
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

        private string GetSortExpression(SortColumn sortColumn, Service.SortOrder sortOrder)
        {
            StringBuilder sortExpression = new StringBuilder();
            switch (sortColumn)
            {
                case SortColumn.FullName:
                    sortExpression.Append("FullName");
                    break;
                case SortColumn.Salary:
                    sortExpression.Append("Salary");
                    break;
            }
            sortExpression.Append("_");
            switch (sortOrder)
            { 
                case Service.SortOrder.Ascending:
                    sortExpression.Append("Ascending");
                    break;
                case Service.SortOrder.Descending:
                    sortExpression.Append("Descending");
                    break;
            }
            return sortExpression.ToString();
        }

        private IDataReader ExecuteReader(DbCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
