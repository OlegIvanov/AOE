using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE.Repository
{
    public class EmployeeWebServiceRepository : IEmployeeRepository
    {
        private string _url;

        public EmployeeWebServiceRepository(string url)
        {
            _url = url;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            throw new NotImplementedException();
        }

        public JobListResponse GetJobList()
        {
            throw new NotImplementedException();
        }
    }
}
