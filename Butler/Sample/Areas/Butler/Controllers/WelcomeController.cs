using ButlerWeb.Areas.Butler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ButlerWeb.Areas.Butler.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Butler/Welcome/

        public ActionResult Index()
        {
            var targetAssembly = Assembly.GetExecutingAssembly(); // or whichever
            var subtypes = targetAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ButlerCore.ButlerDocument)) && t.IsPublic).Select(t => new DocumentTypeWrapper(t)).ToList();

            var vm = new WelcomeViewModel();
            vm.Types = subtypes;
            foreach (var type in vm.Types)
            {
                type.Name = GetName(type.Type).ToString();
            }

            return View(vm);
        }

        private string GetName(Type type)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);  // Reflection
            foreach (System.Attribute attr in attrs)
            {
                if (attr is DisplayNameAttribute)
                {
                    DisplayNameAttribute a = (DisplayNameAttribute)attr;
                    return a.DisplayName;
                }
            }

            return type.Name;
        }
    }
}
