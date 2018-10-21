using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;
using PagedList;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class OverrunsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<Overrun> overruns;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                overruns = db.Overruns
                    .Include(o => o.Company)
                    .Include(o => o.Project).OrderBy(c => c.Date);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                overruns = db.Overruns
                    .Include(p => p.Project)                    
                    .Where(p => p.CompanyId == user.CompanyId).OrderBy(c => c.Date);
            }            
            return View(overruns.ToPagedList((int)page, 5));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var overrun = db.Overruns.Find(id);
            if (overrun == null)
            {
                return HttpNotFound();
            }
            return View(overrun);
        }

        public ActionResult Create()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name");
                var overrunNew = new Overrun
                {
                    Date = DateTime.Now,
                    Type = "Adicional",
                };
                return View(overrunNew);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name");            
            var overrun = new Overrun
            {
                Date = DateTime.Now,
                CompanyId = user.CompanyId,
                Type = "Adicional",
            };            
            return View(overrun);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Overrun overrun)
        {
            if (ModelState.IsValid)
            {
                db.Overruns.Add(overrun);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    if (overrun.DocFile != null)
                    {
                        const string folder = "~/Content/Documents";
                        var file = Path.GetFileName(overrun.DocFile.FileName);

                        var response = FilesHelper.UploadFile(overrun.DocFile, folder, file);
                        if (response)
                        {
                            var doc = string.Format("{0}/{1}", folder, file);
                            overrun.Document = doc;
                            db.Entry(overrun).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", overrun.CompanyId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name", overrun.ProjectId);                
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name", overrun.ProjectId);                
            }            
            return View(overrun);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var overrun = db.Overruns.Find(id);
            if (overrun == null)
            {
                return HttpNotFound();
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", overrun.CompanyId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name", overrun.ProjectId);
            }
            else
            {
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(overrun.CompanyId), "ProjectId", "Description", overrun.ProjectId);
            }            
            return View(overrun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Overrun overrun)
        {
            if (ModelState.IsValid)
            {
                if (overrun.DocFile != null)
                {
                    var doc = string.Empty;
                    const string folder = "~/Content/Documents";
                    var file = Path.GetFileName(overrun.DocFile.FileName);

                    var response = FilesHelper.UploadFile(overrun.DocFile, folder, file);
                    if (response)
                    {
                        doc = string.Format("{0}/{1}.", folder, file);
                        overrun.Document = doc;
                    }
                }

                db.Entry(overrun).State = EntityState.Modified;
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", overrun.CompanyId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name", overrun.ProjectId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name", overrun.ProjectId);                
            }            
            return View(overrun);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var overrun = db.Overruns.Find(id);
            if (overrun == null)
            {
                return HttpNotFound();
            }
            return View(overrun);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var overrun = db.Overruns.Find(id);
            db.Overruns.Remove(overrun);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(overrun);
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
