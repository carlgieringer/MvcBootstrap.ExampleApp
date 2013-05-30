﻿namespace MvcBootstrap.ExampleApp.Web.App_Start
{
    using System.Web.Mvc;

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}