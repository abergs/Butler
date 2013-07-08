using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using ButlerCore;
using ButlerWeb.Areas.Butler.Helpers;
using ButlerWeb.Areas.Butler.Models;

namespace ButlerWeb.Areas.Butler.Controllers
{
    [Authorize]
    public class WelcomeController : Controller
    {
        //
        // GET: /Butler/Welcome/

        public ActionResult Index()
        {
            Assembly targetAssembly = Assembly.GetExecutingAssembly(); // or whichever
            List<DocumentTypeWrapper> subtypes =
                targetAssembly.GetTypes()
                              .Where(t => t.IsSubclassOf(typeof (ButlerDocument)) && t.IsPublic)
                              .Select(t => new DocumentTypeWrapper(t))
                              .ToList();

            var vm = new WelcomeViewModel();
            vm.Types = subtypes;
            foreach (DocumentTypeWrapper type in vm.Types)
            {
                type.Name = Attributes.GetName(type.Type);
            }

            return View(vm);
        }
    }
}