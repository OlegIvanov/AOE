using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public class EmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public JobListResponse GetJobList()
        {
            JobListResponse jobListResponse = new JobListResponse();

            List<Job> jobs = _employeeRepository.GetJobList();

            jobListResponse.Jobs = jobs.ConvertToJobListViewModel();

            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();

            List<Employee> employees = _employeeRepository.GetEmployeeList(employeeListRequest);
            int employeeCountByJobId = _employeeRepository.GetEmployeeCountByJobId(employeeListRequest.JobId);

            employeeListResponse.Employees = employees.ConvertToEmployeeListViewModel();
            employeeListResponse.EmployeeCountByJobId = employeeCountByJobId;

            return employeeListResponse;
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            _employeeRepository.UpdateEmployee(employeeUpdateRequest);
        }
    }
}
