using AOE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        [WebMethod]
        public JobListResponse GetJobList()
        {
            throw new NotImplementedException();
        }

        [WebMethod]
        public EmployeeListResponse GetEmployeeList(EmployeeListRequest employeeListRequest)
        {
            throw new NotImplementedException();
        }
    }
}
