using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Concrete;

namespace RepositoryPatternApp.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 1. Create a new Simple Injector container
            Container container = new Container();

            // 2. Configure the container (register)
            container.Register<ICategoryRepository, EFCategoryRepository>();
            container.Register<ICustomerRepository, EFCustomerRepository>();
            container.Register<IEmployeeRepository, EFEmployeeRepository>();
            container.Register<IEmployeeTerritoryRepository, EFEmployeeTerritoryRepository>();
            container.Register<IOrderRepository, EFOrderRepository>();
            container.Register<IOrderDetailRepository, EFOrderDetailRepository>();
            container.Register<IProductRepository, EFProductRepository>();
            container.Register<IRegionRepository, EFRegionRepository>();
            container.Register<IShipperRepository, EFShipperRepository>();
            container.Register<ISupplierRepository, EFSupplierRepository>();
            container.Register<ITerritoryRepository, EFTerritoryRepository>();

            // 3. Verify your configuration
            container.Verify();

            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}