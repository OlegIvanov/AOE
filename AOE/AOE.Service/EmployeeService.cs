﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            JobListResponse jobListResponse = _employeeRepository.GetJobList();
            return jobListResponse;
        }

        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            EmployeeListResponse employeeListResponse = _employeeRepository.GetEmployeeList(employeeListRequest);
            return employeeListResponse;
        }
    }
}