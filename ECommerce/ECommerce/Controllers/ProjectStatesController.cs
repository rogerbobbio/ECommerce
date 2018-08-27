using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ProjectStatesController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: ProjectStates
        public ActionResult Index()
        {
            return View(db.ProjectStates.ToList());
        }

        // GET: ProjectStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectState projectState = db.ProjectStates.Find(id);
            if (projectState == null)
            {
                return HttpNotFound();
            }
            return View(projectState);
        }

        // GET: ProjectStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectStateId,Name")] ProjectState projectState)
        {
            if (ModelState.IsValid)
            {
                db.ProjectStates.Add(projectState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectState);
        }

        // GET: ProjectStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectState projectState = db.ProjectStates.Find(id);
            if (projectState == null)
            {
                return HttpNotFound();
            }
            return View(projectState);
        }

        // POST: ProjectStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectStateId,Name")] ProjectState projectState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectState);
        }

        // GET: ProjectStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectState projectState = db.ProjectStates.Find(id);
            if (projectState == null)
            {
                return HttpNotFound();
            }
            return View(projectState);
        }

        // POST: ProjectStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectState projectState = db.ProjectStates.Find(id);
            db.ProjectStates.Remove(projectState);
            db.SaveChanges();
            return RedirectToAction("Index");
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
