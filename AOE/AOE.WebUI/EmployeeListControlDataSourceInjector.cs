using AOE.Model;
using AOE.Repository;
using StructureMap;
using System.Web.Configuration;

namespace AOE.WebUI
{
    public static class EmployeeListControlDataSourceInjector
    {
        public static IContainer GetConfiguredContainer(EmployeeListControlConfig employeeListConfig)
        {
            IContainer container = null;

            switch (employeeListConfig.DataSource.Type)
            {
                case SourceType.Database:
                    {
                        container = new Container(x =>
                        {
                            x.For<IEmployeeRepository>()
                                .Use<EmployeeDatabaseRepository>()
                                .Ctor<string>()
                                .Is(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
                        });
                        break;
                    }
                case SourceType.Webservice:
                    {
                        container = new Container(x =>
                        {
                            x.For<IEmployeeRepository>()
                                .Use<EmployeeWebserviceRepository>()
                                .Ctor<string>()
                                .Is(employeeListConfig.DataSource.Url);
                        });
                        break;
                    }
            }

            return container;
        }
    }
}