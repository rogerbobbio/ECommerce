using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ProjectsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        
        public ActionResult Index()
        {
            IQueryable<Project> projects;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                projects = db.Projects.Include(p => p.City).Include(p => p.Companies).Include(p => p.Department).Include(p => p.ProjectState);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                projects = db.Projects.Where(c => c.CompanyId == user.CompanyId);
                //==================================================
            }
            
            return View(projects.ToList());
        }
        
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
        
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name");            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name");
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name");            

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                return View();
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var project = new Project { CompanyId = user.CompanyId };
            return View(project);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
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
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", project.DepartmentId);
            ViewBag.ProjectStateId = new SelectList(CombosHelper.GetProjectStates(), "ProjectStateId", "Name", project.ProjectStateId);

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", project.CompanyId);

            return View(project);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
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
