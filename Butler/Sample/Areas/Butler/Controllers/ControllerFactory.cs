using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ButlerWeb.Areas.Butler.Controllers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                var controll = base.CreateController(requestContext, controllerName);
                return controll;
            }
            catch (Exception ex)
            {
                if (requestContext.RouteData.DataTokens["area"].ToString().ToLowerInvariant() == "butler")
                {
                    string rootspace = "Sample";
                    string models = "Models";
                    Type type = Type.GetType(string.Format("{0}.{1}.{2}", rootspace, models, controllerName));

                    Type rootControllerType = typeof(GenericController<>);
                    Type controllerType = rootControllerType.MakeGenericType(type);
                    return Activator.CreateInstance(controllerType) as IController;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}