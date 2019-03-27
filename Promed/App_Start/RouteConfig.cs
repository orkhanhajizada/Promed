using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Promed
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "DoctorUrl",
               url: "doctor/{slug}",
               defaults: new { controller = "Doctors", action = "Details", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "BlogIndex",
              url: "blog",
              defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "BlogUrl",
               url: "read/{slug}",
               defaults: new { controller = "Blog", action = "Read", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "DepartmentUrl",
               url: "department/{slug}",
               defaults: new { controller = "Department", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
