using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Model
{
    public interface IEmployeeRepository
    {
        List<Job> GetJobList();
        EmployeeListModel GetEmployeeList(EmployeeListRequest employeeListRequest);
        void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest);
    }
}
