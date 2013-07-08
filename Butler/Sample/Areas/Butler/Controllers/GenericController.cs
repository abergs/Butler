using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ButlerCore;
using ButlerWeb.Areas.Butler.Helpers;

namespace ButlerWeb.Areas.Butler.Controllers
{
    [Authorize]
    public class GenericController<T> : Controller where T : ButlerDocument, new()
    {
        //
        // GET: /My/

        public ActionResult Index()
        {
            List<T> entities = Store.GetAll<T>();
            var model = new GenericControllerModel
                {
                    Name = Attributes.GetName(typeof (T)),
                    Entities = entities.Cast<dynamic>().ToList()
                };

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var entity = Store.Get<T>(id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(T entity)
        {
            Store.Save(entity);
            ViewBag.Saved = true;
            return View(entity);
        }
    }
}