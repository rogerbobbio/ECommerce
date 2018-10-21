using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class QuotesController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<Quote> quotes;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                quotes = db.Quotes
                    .Include(q => q.Company)
                    .Include(q => q.Product)
                    .Include(q => q.Supplier).OrderBy(c => c.Date);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                quotes = db.Quotes
                    .Include(p => p.Product)
                    .Include(p => p.Supplier)
                    .Where(p => p.CompanyId == user.CompanyId).OrderBy(c => c.Date);
            }
            return View(quotes.ToPagedList((int)page, 5));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        public ActionResult Create()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description");
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(), "SupplierId", "FirstName");
                var quoteNew = new Quote
                {
                    Date = DateTime.Now,
                };
                return View(quoteNew);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description");
            ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(user.CompanyId), "SupplierId", "FirstName");
            var quote = new Quote
            {
                Date = DateTime.Now,
                CompanyId = user.CompanyId
            };            
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
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
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", quote.CompanyId);

                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductCategoryId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(), "SupplierId", "FirstName", quote.SupplierId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductCategoryId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(user.CompanyId), "SupplierId", "FirstName", quote.SupplierId);
            }            
            return View(quote);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", quote.CompanyId);
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(), "SupplierId", "FirstName", quote.SupplierId);
            }
            else
            {
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(quote.CompanyId), "ProductId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(quote.CompanyId), "SupplierId", "FirstName", quote.SupplierId);
            }            
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
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
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", quote.CompanyId);

                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(), "SupplierId", "FirstName", quote.SupplierId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description", quote.ProductId);
                ViewBag.SupplierId = new SelectList(CombosHelper.GetSuppliers(user.CompanyId), "SupplierId", "FirstName", quote.SupplierId);
            }
            return View(quote);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
            return RedirectToAction("Index");
        }
            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(quote);
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
