using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buttler.Models;

namespace Buttler.Controllers
{   
    public class UnitsController : Controller
    {
		private readonly IUnitRepository unitRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public UnitsController() : this(new UnitRepository())
        {
        }

        public UnitsController(IUnitRepository unitRepository)
        {
			this.unitRepository = unitRepository;
        }

        //
        // GET: /Units/

        public ViewResult Index()
        {
            return View(unitRepository.All);
        }

        //
        // GET: /Units/Details/5

        public ViewResult Details(int id)
        {
            return View(unitRepository.Find(id));
        }

        //
        // GET: /Units/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Units/Create

        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid) {
                unitRepository.InsertOrUpdate(unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Units/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(unitRepository.Find(id));
        }

        //
        // POST: /Units/Edit/5

        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid) {
                unitRepository.InsertOrUpdate(unit);
                unitRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Units/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(unitRepository.Find(id));
        }

        //
        // POST: /Units/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitRepository.Delete(id);
            unitRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                unitRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

