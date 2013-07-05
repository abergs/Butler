using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web2.Models;
using Web2.Controllers;

namespace Web2.Controllers
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
            catch (Exception)
            {
                string rootspace = "Web2";
                string models = "Models";
                string controllers = "Controllers";
                string GenericController = "MyController";
                Type type = Type.GetType(string.Format("{0}.{1}.{2}", rootspace, models, controllerName));

                string mycontroller = string.Format("{0}.{1}.{2}", rootspace, controllers, GenericController);
                Type rootControllerType = typeof(MyController<>);

                Type controllerType = rootControllerType.MakeGenericType(type);
                return Activator.CreateInstance(controllerType) as IController;
            }
        }
    }
}