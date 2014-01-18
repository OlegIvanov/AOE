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
            var employeeWebServiceProxy = new ProxyNamespace.EmployeeWebService();
            var jobListResponseProxy = employeeWebServiceProxy.GetJobList();
            JobListResponse jobListResponse = new JobListResponse() 
            { 
                Jobs = new List<Job>()
            };
            foreach (var jobProxy in jobListResponseProxy.Jobs)
            {
                jobListResponse.Jobs.Add(new Job() 
                { 
                    Id = jobProxy.Id,
                    Name = jobProxy.Name
                });
            }
            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            var employeeWebServiceProxy = new ProxyNamespace.EmployeeWebService();
            var employeeListRequestProxy = new ProxyNamespace.EmployeeListRequest() 
            { 
                JobId = employeeListRequest.JobId,
                SortExpression = employeeListRequest.SortExpression,
                PageIndex = employeeListRequest.PageIndex,
                PageSize = employeeListRequest.PageSize
            };
            var employeeListResponseProxy = employeeWebServiceProxy.GetEmployeeList(employeeListRequestProxy);
            EmployeeListResponse employeeListResponse = new EmployeeListResponse()
            {
                Employees = new List<Employee>(),
                EmployeeVirtualCount = employeeListResponseProxy.EmployeeVirtualCount
            };
            foreach(var employeeProxy in employeeListResponseProxy.Employees)
            {
                employeeListResponse.Employees.Add(new Employee()
                {
                    Id = employeeProxy.Id,
                    FullName = employeeProxy.FullName,
                    Salary = employeeProxy.Salary
                });
            }
            return employeeListResponse;
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            var employeeWebServiceProxy = new ProxyNamespace.EmployeeWebService();
            var employeeUpdateRequestProxy = new ProxyNamespace.EmployeeUpdateRequest()
            {
                EmployeeId = employeeUpdateRequest.EmployeeId,
                Salary = employeeUpdateRequest.Salary
            };
            employeeWebServiceProxy.UpdateEmployee(employeeUpdateRequestProxy);
        }
    }
}
