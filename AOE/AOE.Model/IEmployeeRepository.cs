using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Model
{
    public interface IEmployeeRepository
    {
        List<Job> GetJobList();
        List<Employee> GetEmployeeList(EmployeeListRequest employeeListRequest);
        int GetEmployeeCountByJobId(int JobId);
        void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest);
    }
}
