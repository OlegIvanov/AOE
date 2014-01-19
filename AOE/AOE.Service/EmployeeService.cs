using AOE.Model;
using AOE.Service.Messages;
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

            List<Job> jobs = _employeeRepository.FindAllJobs();

            jobListResponse.Jobs = jobs.ConvertToJobListViewModel();

            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EmployeeListResponse employeeListResponse = new EmployeeListResponse();

            EmployeeQuery employeeQuery = new EmployeeQuery
            {
                JobId = employeeListRequest.JobId,
                SortExpression = employeeListRequest.SortExpression,
                PageIndex = employeeListRequest.PageIndex,
                PageSize = employeeListRequest.PageSize
            };
            List<Employee> employees = _employeeRepository.FindBy(employeeQuery);

            int employeeCountByJobId = _employeeRepository.GetCountByJobId(employeeListRequest.JobId);

            employeeListResponse.Employees = employees.ConvertToEmployeeListViewModel();
            employeeListResponse.EmployeeTotalCount = employeeCountByJobId;

            return employeeListResponse;
        }

        public void UpdateEmployeeSalary(EmployeeUpdateSalaryRequest employeeUpdateSalaryRequest)
        {
            Employee employee = _employeeRepository.FindBy(employeeUpdateSalaryRequest.EmployeeId);

            employee.Salary = employeeUpdateSalaryRequest.Salary;

            _employeeRepository.Update(employee);
        }
    }
}
