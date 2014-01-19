using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Model
{
    public interface IEmployeeRepository
    {
        List<Job> FindAllJobs();
        List<Employee> FindBy(EmployeeQuery employeeQuery);
        int GetCountByJobId(int jobId);
        Employee FindBy(int employeeId);
        void Update(Employee employee);
    }
}
