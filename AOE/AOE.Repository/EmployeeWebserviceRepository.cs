using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Repository
{
    public class EmployeeWebserviceRepository : IEmployeeRepository
    {
        public List<Job> GetJobList()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            throw new NotImplementedException();
        }

        public int GetEmployeeCountByJobId(int JobId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
