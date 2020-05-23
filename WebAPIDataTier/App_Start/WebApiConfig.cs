using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPIDataTier.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /* This binds custom HTTP Attributes paths in controllers to their functions*/
            config.MapHttpAttributeRoutes();

            /*This allows the binding of API routes in the way that it should work
             */
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,                  
                });

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}