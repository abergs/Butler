using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web2.Controllers
{
    public class MyController<T> : Controller where T : new()
    {
        //
        // GET: /My/

        public ActionResult Index()
        {
            List<T> entities = Butler.Store.GetAll<T>();

            return View(entities);
        }

        public ActionResult Edit(string id)
        {
            var entity = Butler.Store.Get<T>(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(T entity)
        {
            Butler.Store.Save(entity);
            ViewBag.Saved = true;
            return View(entity);
        }
    }
}
