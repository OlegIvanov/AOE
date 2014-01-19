using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Repository
{
    public class EmployeeWebserviceRepository : IEmployeeRepository
    {
        public List<Job> FindAllJobs()
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindBy(EmployeeQuery employeeQuery)
        {
            throw new NotImplementedException();
        }

        public int GetCountByJobId(int jobId)
        {
            throw new NotImplementedException();
        }

        public Employee FindBy(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
