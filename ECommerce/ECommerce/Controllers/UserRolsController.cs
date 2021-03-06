﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class UserRolsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: UserRols
        public ActionResult Index()
        {
            IQueryable<UserRol> userRols;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                userRols = db.UserRols.Include(u => u.Companies);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                userRols = db.UserRols.Where(c => c.CompanyId == user.CompanyId);
                //==================================================
            }
            
            return View(userRols.ToList());
        }
        
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

        
        public ActionResult Create()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                var userRolNew = new UserRol
                {                    
                    AccumulatedMobility = 0,
                    BasicJornal = 0,
                    Buc = 0,
                    Cts = 0,
                    Dominical = 0,
                    Holidays = 0,
                    HourExtra100 = 0,
                    HourExtra60 = 0,
                    Reward = 0,
                };
                return View(userRolNew);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            var userRol = new UserRol
            {
                CompanyId = user.CompanyId,
                AccumulatedMobility = 0,
                BasicJornal = 0,
                Buc = 0,
                Cts = 0,
                Dominical = 0,
                Holidays = 0,
                HourExtra100 = 0,
                HourExtra60 = 0,
                Reward = 0,
            };
            return View(userRol);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                db.UserRols.Add(userRol);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", userRol.CompanyId);
            return View(userRol);
        }

        
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

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", userRol.CompanyId);
            return View(userRol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRol).State = EntityState.Modified;
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
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
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
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
