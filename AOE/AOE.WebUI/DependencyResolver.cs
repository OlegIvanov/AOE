using AOE.Model;
using AOE.Repository;
using StructureMap;
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
                    container = new Container(x => 
                    {
                        x.For<IEmployeeRepository>()
                            .Use<EmployeeDatabaseRepository>()
                            .Ctor<string>()
                            .Is(WebConfigurationManager.ConnectionStrings["LocalDatabase"].ConnectionString);
                    });
                    break;
            }
            return container;
        }
    }
}