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
                connection.Open();
                IDataReader reader = ExecuteReader(command);
            }

            /*
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetTagsByUserName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = userName;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cn.Open();
                return GetTagCollectionFromReader(ExecuteReader(cmd));
            }
             */
            throw new NotImplementedException();
        }

        private IDataReader ExecuteReader(DbCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
