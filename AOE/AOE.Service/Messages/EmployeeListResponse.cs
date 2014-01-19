using AOE.Service.ViewModels;
using System.Collections.Generic;

namespace AOE.Service.Messages
{
    public class EmployeeListResponse
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public int EmployeeCountByJobId { get; set; }
    }
}
