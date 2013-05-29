namespace MvcBootstrap.ExampleApp.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public class EmployeesRepository : BootstrapRepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(DbContext context)
            : base(context)
        {
        }

        public Employee GetByName(string name)
        {
            return this.Items.SingleOrDefault(e => e.Name == name);
        }
    }
}