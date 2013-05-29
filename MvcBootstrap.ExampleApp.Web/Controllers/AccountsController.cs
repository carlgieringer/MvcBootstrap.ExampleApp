namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.Web.Mvc.Controllers;
    using MvcBootstrap.Web.Mvc.Filters;

    [InitializeSimpleMembership(typeof(ExampleAppContext), typeof(UserProfile), ExampleAppContext.ConnectionStringName)]
    public class AccountsController : AccountsControllerBase<UserProfile>
    {
        public AccountsController(IUserProfileRepository<UserProfile> repository)
            : base(repository)
        {
        }
    }
}
