using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOE.Service
{
    public class EmployeeListResponse
    {
        public IList<Employee> Employees { get; set; }
        public int EmployeeVirtualCount { get; set; }
    }
}
