using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WritingPlatform.App_Start;

namespace WritingPlatform
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyInjectionConfig.RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
