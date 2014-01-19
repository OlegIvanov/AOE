using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWS = EmployeeWebServiceProxyTypesNamespace;

namespace AOE.Repository
{
    public class EmployeeWebserviceRepository : IEmployeeRepository
    {
        private EWS.EmployeeWebService _employeeWebServiceProxy;

        public EmployeeWebserviceRepository(string url)
        {
            _employeeWebServiceProxy = new EWS.EmployeeWebService();
        }

        public List<Job> FindAllJobs()
        {
            return _employeeWebServiceProxy.GetAllJobs()
                .ConvertJobProxyArrayToJobList();
        }

        public List<Employee> FindBy(EmployeeQuery employeeQuery)
        {
            EWS.EmployeeQuery employeeQueryProxy = new EWS.EmployeeQuery 
            { 
                JobId = employeeQuery.JobId,
                SortExpression = employeeQuery.SortExpression,
                PageIndex = employeeQuery.PageIndex,
                PageSize = employeeQuery.PageSize
            };

            return _employeeWebServiceProxy.GetEmployeeList(employeeQueryProxy)
                .ConvertEmployeeProxyArrayToEmployeeList();
        }

        public int GetCountByJobId(int jobId)
        {
            return _employeeWebServiceProxy.GetEmployeeCountByJobId(jobId);
        }

        public Employee FindBy(int employeeId)
        {
            return _employeeWebServiceProxy.GetEmployeeBy(employeeId)
                .ConvertEmployeeProxyToEmployee();
        }

        public void Update(Employee employee)
        {
            _employeeWebServiceProxy.UpdateEmployee(new EWS.Employee 
            { 
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary
            });
        }
    }
}
