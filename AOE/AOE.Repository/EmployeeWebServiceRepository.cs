using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Repository
{
    public class EmployeeWebServiceRepository : IEmployeeRepository
    {
        private string _url;

        public EmployeeWebServiceRepository(string url)
        {
            _url = url;
        }

        public JobListResponse GetJobList()
        {
            throw new NotImplementedException();
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
