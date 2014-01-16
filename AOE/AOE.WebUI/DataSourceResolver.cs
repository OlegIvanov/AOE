using AOE.Repository;
using AOE.Service;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AOE.WebUI
{
    public static class DataSourceResolver
    {
        public static IContainer GetConfiguredContainer(EmployeeListConfig employeeListConfig)
        {
            IContainer container = new Container();
            switch (employeeListConfig.DataSource)
            {
                case EmployeeListDataSource.Database:
                    container.Configure(x => 
                    {
                        x.For<IEmployeeRepository>()
                            .Use<EmployeeDatabaseRepository>()
                            .Ctor<string>("connectionString")
                            .Is(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
                    });
                    break;
            }
            return container;
        }
    }
}