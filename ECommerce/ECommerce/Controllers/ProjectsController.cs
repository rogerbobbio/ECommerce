using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User")]
    public class ProjectsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.City).Include(p => p.Companies).Include(p => p.Department).Include(p => p.ProjectState);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name");
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name");
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,Name,DepartmentId,CityId,ProjectStateId,CompanyId,ProjectBegin,ProjectEnd")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
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

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", project.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", project.CompanyId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", project.DepartmentId);
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name", project.ProjectStateId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", project.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", project.CompanyId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", project.DepartmentId);
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name", project.ProjectStateId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,Name,DepartmentId,CityId,ProjectStateId,CompanyId,ProjectBegin,ProjectEnd")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
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
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", project.CityId);
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", project.CompanyId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", project.DepartmentId);
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name", project.ProjectStateId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
            return View(project);
        }

        public JsonResult GetCities(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartmentId == departmentId);
            return Json(cities);
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
