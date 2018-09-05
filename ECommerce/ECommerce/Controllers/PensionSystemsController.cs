using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PensionSystemsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index()
        {
            return View(db.PensionSystems.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PensionSystem pensionSystem)
        {
            if (ModelState.IsValid)
            {
                db.PensionSystems.Add(pensionSystem);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            return View(pensionSystem);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PensionSystem pensionSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pensionSystem).State = EntityState.Modified;
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }
            return View(pensionSystem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pensionSystem = db.PensionSystems.Find(id);
            db.PensionSystems.Remove(pensionSystem);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(pensionSystem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
