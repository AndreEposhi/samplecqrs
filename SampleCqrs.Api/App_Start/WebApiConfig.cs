using Newtonsoft.Json;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SampleCqrs.Api
{
    /// <summary>
    /// configurações de inicialização da aplicação
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registrar as configurações da aplicação
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SwaggerConfig.Register();
        }
    }
}