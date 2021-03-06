﻿using AOE.Service;
using AOE.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Presentation
{
    public interface IEmployeeListView
    {
        void DisplayJobList(List<JobViewModel> jobs);
        void DisplayEmployeeList(List<EmployeeViewModel> employees, int employeeTotalCount);
        int JobId { get; }
        string SortExpression { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int EmployeeId { get; }
        double Salary { get; }
    }
}
