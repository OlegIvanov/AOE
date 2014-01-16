using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE.Service
{
    public interface IEmployeeRepository
    {
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        JobListResponse GetJobList();
    }
}
