using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOE.WebUI
{
    public class EmployeeListPresenter
    {
        private IEmployeeListView _employeeListView;
        private EmployeeService _employeeService;

        public EmployeeListPresenter(IEmployeeListView employeeListView, EmployeeService employeeService)
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
                SortColumn = _employeeListView.SortColumn,
                SortOrder = _employeeListView.SortOrder,
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