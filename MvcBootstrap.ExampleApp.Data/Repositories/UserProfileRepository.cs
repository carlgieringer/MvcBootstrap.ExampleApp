namespace MvcBootstrap.ExampleApp.Data.Repositories
{
    using System.Data.Entity;

    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;

    public class UserProfileRepository : UserProfileRepositoryBase<ExampleUserProfile>
    {
        public UserProfileRepository(DbContext context)
            : base(context)
        {
        }
    }
}
