using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public interface IEmployeeRepository
    {
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        JobListResponse GetJobList();
    }
}
