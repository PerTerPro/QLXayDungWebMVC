using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLXayDungWebMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Reading", 
                url: "{name}-{id}.html", 
                defaults: new { controller = "NhanVien", action = "Index", id = (string)null, name = (string)null }
            );

            //routes.MapRoute(
            //    name: "NhanVien",
            //    url: "{controller}/{action}.htm",
            //    defaults: new { controller = "NhanVien", action = "Index", id = (string)null }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
