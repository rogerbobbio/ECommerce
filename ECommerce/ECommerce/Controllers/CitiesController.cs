using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Department);
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,Name,DepartmentId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
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

            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", city.DepartmentId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", city.DepartmentId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,Name,DepartmentId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
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
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", city.DepartmentId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var city = db.Cities.Find(id);
            db.Cities.Remove(city);
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
            return View(city);
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
