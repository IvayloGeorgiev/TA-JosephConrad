using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace AccountSystem.WebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            RegisterCustomRoutes(RouteTable.Routes);
        }

        public static void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("AddCardRoute", "User/Card/Add/", "~/User/AddCard.aspx", false);
            routes.MapPageRoute("CardDetailsRoute", "User/Card/{cardId}/", "~/User/CardDetails.aspx", false);
        }
    }
}
