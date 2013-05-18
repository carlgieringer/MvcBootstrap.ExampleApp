namespace MvcBootstrap.ExampleApp.Data.Repositories
{
    using System.Data.Entity;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public class RolesRepository : BootstrapRepositoryBase<Role>, IRolesRepository
    {
        public RolesRepository(DbContext context)
            : base(context)
        {
        }
    }
}