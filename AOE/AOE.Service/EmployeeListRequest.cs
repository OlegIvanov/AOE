using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public class EmployeeListRequest
    {
        public int JobId { get; set; }
        public SortColumn SortColumn { get; set; }
        public SortOrder SortOrder { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
