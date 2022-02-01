using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppMaragogiAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //---------------------Home---------------------//
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Panel",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Panel", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SobreEmpresa",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "SobreEmpresa", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Empresas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Empresas", id = UrlParameter.Optional }
            );
            //---------------------Home---------------------//


            //---------------------Empresa------------------//
            routes.MapRoute(
                name: "EditIcon",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Empresa", action = "EditIcon", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditarEmpresaLogo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Empresa", action = "EditEmpresaLogo", id = UrlParameter.Optional }
            );
            //---------------------Empresa------------------//


            //---------------------Maragogi-----------------//
            routes.MapRoute(
                name: "EditCatMaragogiFotos",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "Maragogi", action = "EditCatMaragogiFotos" }
            );

            routes.MapRoute(
                name: "CadCatMaragogi",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "Maragogi", action = "CadCatMaragogi"}
            );
            //---------------------Maragogi-----------------//

            //---------------------DescMaragogi-----------------//
            routes.MapRoute(
                name: "AddDescMaragogi",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "DescMaragogi", action = "AddDescMaragogi" }
            );

            routes.MapRoute(
                name: "DescMaragogi",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "DescMaragogi", action = "DescMaragogi" }
            );

            routes.MapRoute(
                name: "UpDescMaragogi",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "DescMaragogi", action = "UpDescMaragogi" }
            );
            //---------------------DescMaragogi-----------------//
        }
    }
}
