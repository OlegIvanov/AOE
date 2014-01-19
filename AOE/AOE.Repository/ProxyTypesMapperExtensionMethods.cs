using AOE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EWS = EmployeeWebServiceProxyTypesNamespace;

namespace AOE.Repository
{
    public static class ProxyTypesMapperExtensionMethods
    {
        public static List<Job> ConvertJobProxyArrayToJobList(this EWS.Job[] jobProxyArray)
        {
            List<Job> jobs = new List<Job>();

            foreach (EWS.Job jobProxy in jobProxyArray)
            {
                jobs.Add(jobProxy.ConvertJobProxyToJob());
            }

            return jobs;
        }

        public static Job ConvertJobProxyToJob(this EWS.Job jobProxy)
        {
            return new Job
            {
                Id = jobProxy.Id,
                Name = jobProxy.Name
            };
        }

        public static List<Employee> ConvertEmployeeProxyArrayToEmployeeList(this EWS.Employee[] employeeProxyArray)
        {
            List<Employee> employees = new List<Employee>();

            foreach (EWS.Employee employeeProxy in employeeProxyArray)
            {
                employees.Add(employeeProxy.ConvertEmployeeProxyToEmployee());
            }

            return employees;
        }

        public static Employee ConvertEmployeeProxyToEmployee(this EWS.Employee employeeProxy)
        {
            return new Employee
            {
                Id = employeeProxy.Id,
                FirstName = employeeProxy.FirstName,
                LastName = employeeProxy.LastName,
                Salary = employeeProxy.Salary
            };
        }
    }
}
