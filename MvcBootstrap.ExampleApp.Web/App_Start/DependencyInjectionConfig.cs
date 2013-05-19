namespace MvcBootstrap.ExampleApp.Web.App_Start
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;

    public static class DependencyInjectionConfig
    {
        public static IDependencyResolver CreateResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(c => new ExampleAppContext("MvcBootstrap.ExampleApp.Data.ExampleAppContext"))
                .As<DbContext>()
                .InstancePerHttpRequest();
            builder.Register(c => new EmployeesRepository(c.Resolve<DbContext>()))
                .As<IEmployeesRepository>()
                .InstancePerHttpRequest();
            builder.Register(c => new RolesRepository(c.Resolve<DbContext>()))
                .As<IRolesRepository>()
                .InstancePerHttpRequest();
            var container = builder.Build();
            return new AutofacDependencyResolver(container);
        }
    }
}