using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttler.Areas.Buttler.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            var model = Buttler.Client.ButtleClient.Get("welcome");
            return View(model);
        }
    }
}
