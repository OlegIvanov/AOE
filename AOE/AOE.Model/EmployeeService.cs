using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Model
{
    public class EmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Job> GetJobList()
        {
            return _employeeRepository.GetJobList();
        }

        public EmployeeListModel GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            return _employeeRepository.GetEmployeeList(employeeListRequest);
        }

        public void UpdateEmployee(EmployeeUpdateRequest employeeUpdateRequest)
        {
            _employeeRepository.UpdateEmployee(employeeUpdateRequest);
        }
    }
}
