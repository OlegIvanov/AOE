using AOE.Model;
using AOE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace AOE.EmployeeWebService
{
    /// <summary>
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : System.Web.Services.WebService
    {
        private IEmployeeRepository _repository;

        public EmployeeWebService()
        {
            _repository = new EmployeeDatabaseRepository(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
        }

        [WebMethod]
        public List<Job> GetAllJobs()
        {
            return _repository.FindAllJobs();
        }

        [WebMethod]
        public List<Employee> GetEmployeeList(EmployeeQuery employeeQuery)
        {
            return _repository.FindBy(employeeQuery);
        }

        [WebMethod]
        public int GetEmployeeCountByJobId(int jobId)
        {
            return _repository.GetCountByJobId(jobId);
        }

        [WebMethod]
        public Employee GetEmployeeBy(int employeeId)
        {
            return _repository.FindBy(employeeId);
        }

        [WebMethod]
        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
