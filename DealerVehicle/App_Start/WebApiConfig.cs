using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DealerVehicle
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "Api_Api_Default",
            //    routeTemplate: "{controller}/api/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );
        }
    }
}
