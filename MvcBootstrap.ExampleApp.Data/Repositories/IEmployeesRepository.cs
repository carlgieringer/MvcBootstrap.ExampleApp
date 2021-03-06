﻿namespace MvcBootstrap.ExampleApp.Data.Repositories
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public interface IEmployeesRepository : IBootstrapRepository<Employee>
    {
    }
}