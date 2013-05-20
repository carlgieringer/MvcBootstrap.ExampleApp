namespace MvcBootstrap.ExampleApp.Web
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using MvcBootstrap.ExampleApp.Web.App_Start;
    using MvcBootstrap.Web.Mvc.ModelBinding;
    using MvcBootstrap.Web.Mvc.ModelMetadata;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(DependencyInjectionConfig.CreateResolver());
            ModelMetadataProviders.Current = new BootstrapModelMetadataProvider();
            ModelBinders.Binders.DefaultBinder = new MvcBootstrapModelBinder();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}