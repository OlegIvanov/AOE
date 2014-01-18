using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public class EmployeeService
    {
        private Model.EmployeeService _employeeService;

        public EmployeeService(Model.EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public JobListResponse GetJobList()
        {
            JobListResponse jobListResponse = new JobListResponse();
            List<Job> jobs = _employeeService.GetJobList();
            jobListResponse.Jobs = jobs.ConvertToJobListViewModel();
            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();
            EmployeeListModel employeeListModel = _employeeService.GetEmployeeList(employeeListRequest);
            employeeListResponse.Employees = employeeListModel.Employees.ConvertToEmployeeListViewModel();
            employeeListResponse.EmployeeVirtualCount = employeeListModel.EmployeeVirtualCount;
            return employeeListResponse;
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            _employeeService.UpdateEmployee(employeeUpdateRequest);
        }
    }
}
