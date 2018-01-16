using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealer.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //for atribute routes 

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "All customers ordered",
            //    url: "customers/all/{order}",
            //    defaults: new { controller = "Customers", action = "All", order = "ascending" },
            //    constraints: new { order = @"ascending|descending" });

            //routes.MapRoute(
            //    name: "All cars from make",
            //    url: "cars/{make}/",
            //    defaults: new { controller = "Cars", action = "All" });

            //routes.MapRoute(
            //    name: "All suppliers filtered",
            //    url: "suppliers/{type}",
            //    defaults: new { controller = "Suppliers", action = "All" },
            //    constraints: new { type = @"local|importers" });

            //routes.MapRoute(
            //    name: "Cars with Their List of Parts by Id",
            //    url: "cars/{id}/parts",
            //    defaults: new { controller = "Cars", action = "About" },
            //    constraints: new { id = @"\d+" });

            //routes.MapRoute(
            //    name: "Total Sales by Customer by Id",
            //    url: "customers/{id}/",
            //    defaults: new { controller = "Customers", action = "About" },
            //    constraints: new { id = @"\d+" });

            //routes.MapRoute(
            //    name: "All Sales",
            //    url: "Sales/",
            //    defaults: new { controller = "Sales", action = "All" });

            //routes.MapRoute(
            //    name: "Sale by provided Id ",
            //    url: "Sales/{id}",
            //    defaults: new { controller = "Sales", action = "About" },
            //    constraints: new { id = @"\d+" });

            //routes.MapRoute(
            //    name: "Sales that are discounted ",
            //    url: "Sales/discounted/{percent}",
            //    defaults: new { controller = "Sales", action = "Discounted", percent = UrlParameter.Optional });
        }
    }
}