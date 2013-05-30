namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Web.Mvc.Controllers;
    using MvcBootstrap.Web.Mvc.Filters;

    [InitializeSimpleMembership(
        typeof(ExampleAppContext), 
        typeof(ExampleUserProfile), 
        ExampleAppContext.ConnectionStringName)]
    public class AccountsController : AccountsControllerBase<ExampleUserProfile, ExampleUserProfileViewModel>
    {
        public AccountsController(IUserProfileRepository<ExampleUserProfile> repository)
            : base(repository)
        {
            //this.Config.RequireAccountConfirmation = true;
        }
    }
}
