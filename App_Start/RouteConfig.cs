﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeAutomationMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Automation",
                url: "Automation/{action}/{id}",
                defaults: new { controller = "Automation", action = "Monitor", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Switch",
                url: "Automation/{action}/{id}",
                defaults: new { controller = "Automation", action = "Switch", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PartialRelayStatus",
                url: "Automation/{action}/{id}",
                defaults: new { controller = "Automation", action = "PartialRelayStatus", id = UrlParameter.Optional }
            );
                        
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}