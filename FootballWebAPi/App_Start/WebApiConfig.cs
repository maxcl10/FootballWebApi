﻿using System.Web.Http;

namespace FootballWebSiteApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Action",
            //    routeTemplate: "api/action/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
              );

        }
    }
}