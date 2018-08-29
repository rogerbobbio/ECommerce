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
    public class UserRolsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: UserRols
        public ActionResult Index()
        {
            var userRols = db.UserRols.Include(u => u.Companies);
            return View(userRols.ToList());
        }

        // GET: UserRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRol = db.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // GET: UserRols/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
            return View();
        }

        // POST: UserRols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserRolId,Name,CompanyId,BasicJornal,Buc,AccumulatedMobility,Dominical,Holidays,Cts,Reward,HourExtra60,HourExtra100,Scholarship")] UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                db.UserRols.Add(userRol);
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

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", userRol.CompanyId);
            return View(userRol);
        }

        // GET: UserRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRol = db.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", userRol.CompanyId);
            return View(userRol);
        }

        // POST: UserRols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRolId,Name,CompanyId,BasicJornal,Buc,AccumulatedMobility,Dominical,Holidays,Cts,Reward,HourExtra60,HourExtra100,Scholarship")] UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRol).State = EntityState.Modified;
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
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", userRol.CompanyId);
            return View(userRol);
        }

        // GET: UserRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userRol = db.UserRols.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // POST: UserRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userRol = db.UserRols.Find(id);
            db.UserRols.Remove(userRol);
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
            return View(userRol);
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
