using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GifAtMe
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "RouteToUserName",
                routeTemplate: "api/GifEntries/{userName}"
            );

            config.Routes.MapHttpRoute(
                name: "RouteToUserNameKeywordAlternateIndex",
                routeTemplate: "api/GifEntries/{userName}/{keyword}/{alternateIndex}",
                defaults: new { alternateIndex = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Needed for StructureMap initialization
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
