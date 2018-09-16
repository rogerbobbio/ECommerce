using System.Collections.Generic;
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
    public class PensionSystemsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index()
        {
            List<PensionSystem> pensionSystems;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                pensionSystems = db.PensionSystems.Include(p => p.Companies).ToList();
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                pensionSystems = db.PensionSystems.Where(c => c.CompanyId == user.CompanyId).ToList();
                //==================================================
            }
            return View(pensionSystems);
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
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                var pensionSystemNew = new PensionSystem
                {
                    Commission = 0,
                    Bonus = 0,
                    Input = 0,
                    Total = 0,
                    Top = 0,
                };
                return View(pensionSystemNew);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var pensionSystem = new PensionSystem
            {
                CompanyId = user.CompanyId,
                Commission = 0,
                Bonus = 0,
                Input = 0,
                Total = 0,
                Top = 0,
            };
            return View(pensionSystem);
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

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", pensionSystem.CompanyId);
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

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", pensionSystem.CompanyId);

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

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", pensionSystem.CompanyId);
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
