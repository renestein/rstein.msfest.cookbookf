using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleWebDI
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      //Dočasná výhybka
      routes.MapRoute(
                      "PagerRoute", // Route name
                      "{controller}/{action}/{page}", // URL with parameters
                      new
                        {
                          controller = "Recipe",
                          action = "Index",
                          page = UrlParameter.Optional
                        } // Parameter defaults
        );


      routes.MapRoute(
                      name: "Default",
                      url: "{controller}/{action}/{id}",
                      defaults: new
                                  {
                                    controller = "Home",
                                    action = "Index",
                                    id = UrlParameter.Optional
                                  }
        );
    }
  }
}