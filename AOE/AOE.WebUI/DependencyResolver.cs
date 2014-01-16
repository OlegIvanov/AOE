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
    public static class DependencyResolver
    {
        public static IContainer GetConfiguredContainer(EmployeeListControlConfig config)
        {
            IContainer container = null;
            switch (config.DataSource.Type)
            {
                case SourceType.Database:
                    container = new Container(x => {
                        x.For<IEmployeeRepository>()
                            .Use<EmployeeDatabaseRepository>()
                            .Ctor<string>()
                            .Is(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
                    });
                    break;
                case SourceType.Webservice:
                    container = new Container(x => {
                        x.For<IEmployeeRepository>()
                            .Use<EmployeeWebServiceRepository>()
                            .Ctor<string>()
                            .Is(config.DataSource.Url);
                    });
                    break;
            }
            return container;
        }
    }
}