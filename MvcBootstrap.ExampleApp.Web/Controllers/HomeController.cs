namespace MvcBootstrap.ExampleApp.Web.Controllers
{
    using System.Web.Mvc;

    using MvcBootstrap.Web.Mvc.Controllers;

    public class HomeController : HomeControllerBase
    {
        public override ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
