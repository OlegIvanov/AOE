namespace AOE.Model
{
    public class EmployeeQuery
    {
        public int JobId { get; set; }
        public string SortExpression { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
