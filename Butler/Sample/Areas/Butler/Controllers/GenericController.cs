using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ButlerWeb.Areas.Butler.Controllers
{
    public class GenericController<T> : Controller where T : new()
    {
        //
        // GET: /My/

        public ActionResult Index()
        {
            List<T> entities = ButlerCore.Store.GetAll<T>();

            return View(entities);
        }

        public ActionResult Edit(string id)
        {
            var entity = ButlerCore.Store.Get<T>(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(T entity)
        {
            ButlerCore.Store.Save(entity);
            ViewBag.Saved = true;
            return View(entity);
        }
    }
}
