using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RStein.Cookbook.Business.BusinessServices;
using RStein.Cookbook.EF;
using RStein.Cookbook.EF.EFServices;
using RStein.Cookbook.ExportServices;
using SimpleUIFacade;
using SimpleWebDI.Infrastructure;

namespace SimpleWebDI
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : HttpApplication
  {
    private WindsorContainer m_container;

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterAuth();
      setupDIContainer();
      setControllerFactory();
    }

    private void setControllerFactory()
    {
      ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(m_container));
    }

    private void setupDIContainer()
    {
      //Je lepší rozdělit instalaci do tříd podporujících rozhraní IWindsorInstaller
      //container.Install(new MySpecialServicesInstaller());

      m_container = new WindsorContainer();
      m_container.Register(Classes.FromThisAssembly().
                                   BasedOn(typeof (ControllerBase))
                                  .LifestyleTransient(),
                           Component.For(typeof (IRepository<>)).
                                     ImplementedBy(typeof (DefaultEfRepository<>)).LifestylePerWebRequest(),
                           Component.For<CookbookMfContext>().LifestylePerWebRequest(),
                           Component.For<IExporter>().ImplementedBy<WordExporter>().LifestyleSingleton(),
                           Component.For<RecipeUIFacade>().LifestylePerWebRequest());
    }
  }
}