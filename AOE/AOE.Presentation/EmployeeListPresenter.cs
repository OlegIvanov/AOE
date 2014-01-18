using AOE.Model;
using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOE.Presentation
{
    public class EmployeeListPresenter
    {
        private IEmployeeListView _employeeListView;
        private Service.EmployeeService _employeeService;

        public EmployeeListPresenter(IEmployeeListView employeeListView, Service.EmployeeService employeeService)
        {
            _employeeListView = employeeListView;
            _employeeService = employeeService;
        }

        public void DisplayJobList()
        {
            JobListResponse jobListResponse = _employeeService.GetJobList();
            _employeeListView.DisplayJobList(jobListResponse.Jobs);
        }

        public void DisplayEmployeeList()
        {
            EmployeeListRequest employeeListRequest = new EmployeeListRequest() 
            { 
                JobId = _employeeListView.JobId,
                SortExpression = _employeeListView.SortExpression,
                PageSize = _employeeListView.PageSize,
                PageIndex = _employeeListView.PageIndex
            };
            EmployeeListResponse employeeListResponse = _employeeService.GetEmployeeList(employeeListRequest);
            _employeeListView.DisplayEmployeeList(employeeListResponse.Employees, employeeListResponse.EmployeeVirtualCount);
        }

        public void UpdateEmployee()
        {
            EmployeeUpdateRequest employeeUpdateRequest = new EmployeeUpdateRequest()
            {
                EmployeeId = _employeeListView.EmployeeId,
                Salary = _employeeListView.Salary
            };
            _employeeService.UpdateEmployee(employeeUpdateRequest);
        }
    }
}