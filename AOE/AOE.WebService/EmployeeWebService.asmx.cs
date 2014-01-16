using AOE.Repository;
using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace AOE.WebService
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
        private EmployeeDatabaseRepository _repository;

        public EmployeeWebService() 
        {
            _repository = new EmployeeDatabaseRepository(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
        }

        [WebMethod]
        public JobListResponse GetJobList()
        {
            return _repository.GetJobList();
        }

        [WebMethod]
        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            return _repository.GetEmployeeList(employeeListRequest);
        }
    }
}
