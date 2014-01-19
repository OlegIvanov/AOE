using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOE.Service
{
    public static class EmployeeConvertingExtensionMethods
    {
        public static List<JobViewModel> ConvertToJobListViewModel(this List<Job> jobs)
        {
            List<JobViewModel> jobViewModels = new List<JobViewModel>();

            foreach (Job job in jobs)
            {
                jobViewModels.Add(job.ConvertToJobViewModel());
            }

            return jobViewModels;
        }

        public static JobViewModel ConvertToJobViewModel(this Job job)
        {
            return new JobViewModel
            {
                Id = job.Id,
                Name = job.Name
            };
        }

        public static List<EmployeeViewModel> ConvertToEmployeeListViewModel(this List<Employee> employees)
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                employeeViewModels.Add(employee.ConvertToEmployeeViewModel());
            }

            return employeeViewModels;
        }

        public static EmployeeViewModel ConvertToEmployeeViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            { 
                Id = employee.Id,
                FullName = string.Format("{0} {1}",employee.LastName, employee.FirstName),
                Salary = string.Format("{0:0.00}", employee.Salary)
            };
        }
    }
}
