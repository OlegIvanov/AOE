﻿namespace AOE.Service.Messages
{
    public class EmployeeListRequest
    {
        public int JobId { get; set; }
        public string SortExpression { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
