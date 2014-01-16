using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE.WebUI
{
    public interface IEmployeeListView
    {
        void DisplayJobList(IList<Job> jobs);
        void DisplayEmployeeList(IList<Employee> employees, int employeeVirtualCount);
        int JobId { get; }
        SortColumn SortColumn { get; }
        SortOrder SortOrder { get; }
        int PageIndex { get; }
        int PageSize { get; }
    }
}
