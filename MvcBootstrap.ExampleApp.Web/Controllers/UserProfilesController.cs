namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using MvcBootstrap.Data;
    using MvcBootstrap.ExampleApp.Domain.Models;
    using MvcBootstrap.ExampleApp.Web.ViewModels;
    using MvcBootstrap.Web.Mvc.Controllers;

    public class UserProfilesController : BootstrapControllerBase<ExampleUserProfile, ExampleUserProfileViewModel>
    {
        public UserProfilesController(IBootstrapRepository<ExampleUserProfile> repository)
            : base(repository)
        {
        }
    }
}
