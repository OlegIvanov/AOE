using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public class EmployeeListResponse
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public int EmployeeVirtualCount { get; set; }
    }
}
