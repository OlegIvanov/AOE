using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public interface IEmployeeRepository
    {
        JobListResponse GetJobList();
        EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest);
        void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest);
    }
}
