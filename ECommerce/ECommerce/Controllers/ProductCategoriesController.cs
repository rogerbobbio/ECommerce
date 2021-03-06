﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;
using PagedList;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ProductCategoriesController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<ProductCategory> productCategories;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                productCategories = db.ProductCategories.Include(p => p.Company).OrderBy(c => c.Description);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                productCategories = db.ProductCategories.Where(c => c.CompanyId == user.CompanyId).OrderBy(c => c.Description);
                //==================================================
            }
            
            return View(productCategories.ToPagedList((int)page, 5));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }
        
        public ActionResult Create()
        {
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

            var productCategory = new ProductCategory { CompanyId = user.CompanyId };
            return View(productCategory);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategory);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", productCategory.CompanyId);
            return View(productCategory);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", productCategory.CompanyId);
            return View(productCategory);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCategory).State = EntityState.Modified;
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);
            }
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", productCategory.CompanyId);
            return View(productCategory);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var productCategory = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(productCategory);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(productCategory);
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
