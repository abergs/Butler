using System;
using System.Globalization;
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
                IController controll = base.CreateController(requestContext, controllerName);
                return controll;
            }
            catch (Exception ex)
            {
                object area = requestContext.RouteData.DataTokens["area"];
                if (area != null && area.ToString().ToLowerInvariant() == "butler")
                {
                    string rootspace = "Sample";
                    string models = "Models";
                    Type type = Type.GetType(string.Format("{0}.{1}.{2}", rootspace, models, controllerName));

                    Type rootControllerType = typeof (GenericController<>);
                    Type controllerType = rootControllerType.MakeGenericType(type);
                    return Activator.CreateInstance(controllerType) as IController;
                }
                else
                {
                    throw new HttpException(404,
                                        String.Format(
                                            CultureInfo.CurrentCulture,
                                            requestContext.HttpContext.Request.Path));
                }
            }
        }
    }
}