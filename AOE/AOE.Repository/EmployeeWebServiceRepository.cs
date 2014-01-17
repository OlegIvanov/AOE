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
            var employeeWebServiceProxy = new EmployeeWebService.EmployeeWebService();
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
            var employeeWebServiceProxy = new EmployeeWebService.EmployeeWebService();
            var employeeListRequestProxy = new EmployeeWebService.EmployeeListRequest() 
            { 
                JobId = employeeListRequest.JobId,
                PageIndex = employeeListRequest.PageIndex,
                PageSize = employeeListRequest.PageSize,
            };
            switch (employeeListRequest.SortColumn)
            { 
                case SortColumn.None:
                    employeeListRequestProxy.SortColumn = EmployeeWebService.SortColumn.None;
                    break;
                case SortColumn.FullName:
                    employeeListRequestProxy.SortColumn = EmployeeWebService.SortColumn.FullName;
                    break;
                case SortColumn.Salary:
                    employeeListRequestProxy.SortColumn = EmployeeWebService.SortColumn.Salary;
                    break;
            }
            switch (employeeListRequest.SortOrder)
            {
                case SortOrder.None:
                    employeeListRequestProxy.SortOrder = EmployeeWebService.SortOrder.None;
                    break;
                case SortOrder.Ascending:
                    employeeListRequestProxy.SortOrder = EmployeeWebService.SortOrder.Ascending;
                    break;
                case SortOrder.Descending:
                    employeeListRequestProxy.SortOrder = EmployeeWebService.SortOrder.Descending;
                    break;
            }
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
            var employeeWebServiceProxy = new EmployeeWebService.EmployeeWebService();
            var employeeUpdateRequestProxy = new EmployeeWebService.EmployeeUpdateRequest()
            {
                EmployeeId = employeeUpdateRequest.EmployeeId,
                Salary = employeeUpdateRequest.Salary
            };
            employeeWebServiceProxy.UpdateEmployee(employeeUpdateRequestProxy);
        }
    }
}
