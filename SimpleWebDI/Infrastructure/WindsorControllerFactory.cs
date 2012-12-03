using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace SimpleWebDI.Infrastructure
{
  public class WindsorControllerFactory : DefaultControllerFactory
  {
    private WindsorContainer m_container;

    public WindsorControllerFactory(WindsorContainer container)
    {
      m_container = container;
    }

    public override void ReleaseController(IController controller)
    {
      m_container.Release(controller);
      base.ReleaseController(controller);
    }


    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
      if (controllerType == null)
      {
        return base.GetControllerInstance(requestContext, controllerType);
      }

      return m_container.Resolve(controllerType) as IController;
    }
  }
}