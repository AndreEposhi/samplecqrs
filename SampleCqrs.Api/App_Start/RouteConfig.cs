using System.Web.Mvc;
using System.Web.Routing;

namespace SampleCqrs.Api
{
    /// <summary>
    /// Configurações da rota da api
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registra a rota da api
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}