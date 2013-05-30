namespace MvcBootstrap.ExampleApp.Web.App_Start
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Data.Repositories;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public static class DependencyInjectionConfig
    {
        public static IDependencyResolver CreateResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.Register(c => new ExampleAppContext(ExampleAppContext.ConnectionStringName))
                .As<DbContext>()
                .InstancePerHttpRequest();
            
            builder.Register(c => new EmployeesRepository(c.Resolve<DbContext>()))
                .As<IBootstrapRepository<Employee>>()
                .As<IEmployeesRepository>()
                .InstancePerHttpRequest();
            
            builder.Register(c => new RolesRepository(c.Resolve<DbContext>()))
                .As<IBootstrapRepository<Role>>()
                .As<IRolesRepository>()
                .InstancePerHttpRequest();

            builder.Register(c => new UserProfileRepository(c.Resolve<DbContext>()))
                .As<IBootstrapRepository<ExampleUserProfile>>()
                .As<IUserProfileRepository<ExampleUserProfile>>()
                .InstancePerHttpRequest();
            
            var container = builder.Build();
            
            return new AutofacDependencyResolver(container);
        }
    }
}