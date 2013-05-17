namespace MvcBootstrap.ExampleApp.Data.Repositories
{
    using System.Data.Entity;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public class EmployeesRepository : BootstrapRepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(DbContext context)
            : base(context)
        {
        }
    }
}