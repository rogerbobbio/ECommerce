using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class PensionSystemsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: PensionSystems
        public ActionResult Index()
        {
            return View(db.PensionSystems.ToList());
        }

        // GET: PensionSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PensionSystem pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        // GET: PensionSystems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PensionSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PensionSystemId,Name,Commission,Bonus,Input,Total,Top")] PensionSystem pensionSystem)
        {
            if (ModelState.IsValid)
            {
                db.PensionSystems.Add(pensionSystem);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same value.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }

            return View(pensionSystem);
        }

        // GET: PensionSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PensionSystem pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        // POST: PensionSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PensionSystemId,Name,Commission,Bonus,Input,Total,Top")] PensionSystem pensionSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pensionSystem).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same value.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            return View(pensionSystem);
        }

        // GET: PensionSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PensionSystem pensionSystem = db.PensionSystems.Find(id);
            if (pensionSystem == null)
            {
                return HttpNotFound();
            }
            return View(pensionSystem);
        }

        // POST: PensionSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pensionSystem = db.PensionSystems.Find(id);
            db.PensionSystems.Remove(pensionSystem);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "The record can't be delete because it has related records.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
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
