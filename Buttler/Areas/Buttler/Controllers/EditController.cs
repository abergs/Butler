using Buttler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttler.Controllers
{
    public class EditController : Controller
    {
        //
        // GET: /Edit/

        public ActionResult Index(string id)
        {

            // Fetch dynamic type from mainservice
            dynamic data = DataService.Get(id);
            // Get viewname depending on type
            string viewName = data.GetType().Name;

            /*var view = View(viewName);

            if (view.View == null)
            {
                return View("Index");
            }*/

            return View(viewName,data);
        }
    }
}
