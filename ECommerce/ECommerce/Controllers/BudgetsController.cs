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
    public class BudgetsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<Budget> budgets;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                budgets = db.Budgets
                    .Include(b => b.Company)
                    .Include(b => b.Customer)
                    .Include(b => b.Project).OrderByDescending(c => c.Date);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                budgets = db.Budgets
                    .Where(c => c.CompanyId == user.CompanyId)
                    .Include(o => o.Customer)                    
                    .Include(o => o.Project).OrderByDescending(c => c.Date);
                //==================================================
            }
            return View(budgets.ToPagedList((int)page, 5));
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }        

        public ActionResult Create()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "FullName");
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name");
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");                
                var adminView = new NewBudgetView
                {
                    Date = DateTime.Now,
                    DetailsSc01 = BudgetHelper.GetBudgetDetails("SC01"),
                    DetailsSc02 = BudgetHelper.GetBudgetDetails("SC02"),
                    DetailsSc03 = BudgetHelper.GetBudgetDetails("SC03"),
                    DetailsSc04 = BudgetHelper.GetBudgetDetails("SC04"),
                    DetailsSc05 = BudgetHelper.GetBudgetDetails("SC05"),
                    DetailsSc06 = BudgetHelper.GetBudgetDetails("SC06"),
                    DetailsSc07 = BudgetHelper.GetBudgetDetails("SC07"),
                    DetailsSc08 = BudgetHelper.GetBudgetDetails("SC08"),
                    DetailsSc09 = BudgetHelper.GetBudgetDetails("SC09"),
                    DetailsSc10 = BudgetHelper.GetBudgetDetails("SC10"),
                    DetailsSc11 = BudgetHelper.GetBudgetDetails("SC11"),
                    DetailsSc12 = BudgetHelper.GetBudgetDetails("SC12"),
                    DetailsSc13 = BudgetHelper.GetBudgetDetails("SC13"),
                    DetailsSc14 = BudgetHelper.GetBudgetDetails("SC14"),
                    DetailsSc15 = BudgetHelper.GetBudgetDetails("SC15"),
                    DetailsSc16 = BudgetHelper.GetBudgetDetails("SC16"),
                    DetailsSc17 = BudgetHelper.GetBudgetDetails("SC17"),
                    DetailsSc18 = BudgetHelper.GetBudgetDetails("SC18"),
                    DetailsSc19 = BudgetHelper.GetBudgetDetails("SC19"),
                    DetailsSc20 = BudgetHelper.GetBudgetDetails("SC20"),
                    DetailsSc21 = BudgetHelper.GetBudgetDetails("SC21"),
                    DetailsSc22 = BudgetHelper.GetBudgetDetails("SC22"),
                    DetailsSc23 = BudgetHelper.GetBudgetDetails("SC23"),
                    DetailsSc24 = BudgetHelper.GetBudgetDetails("SC24"),
                    DetailsSc25 = BudgetHelper.GetBudgetDetails("SC25"),
                    DetailsSc26 = BudgetHelper.GetBudgetDetails("SC26"),
                    DetailsSc27 = BudgetHelper.GetBudgetDetails("SC27"),
                    DetailsSc28 = BudgetHelper.GetBudgetDetails("SC28"),
                    DetailsSc29 = BudgetHelper.GetBudgetDetails("SC29"),
                    DetailsSc30 = BudgetHelper.GetBudgetDetails("SC30"),
                    DetailsSc31 = BudgetHelper.GetBudgetDetails("SC31"),
                    DetailsSc32 = BudgetHelper.GetBudgetDetails("SC32"),
                    DetailsSc33 = BudgetHelper.GetBudgetDetails("SC33"),
                    DetailsSc34 = BudgetHelper.GetBudgetDetails("SC34"),
                    DetailsSc35 = BudgetHelper.GetBudgetDetails("SC35"),
                    DetailsSc36 = BudgetHelper.GetBudgetDetails("SC36"),
                    DetailsSc37 = BudgetHelper.GetBudgetDetails("SC37"),
                    DetailsSc38 = BudgetHelper.GetBudgetDetails("SC38"),
                    DetailsSc39 = BudgetHelper.GetBudgetDetails("SC39"),
                    DetailsSc40 = BudgetHelper.GetBudgetDetails("SC40"),
                    DetailsSc41 = BudgetHelper.GetBudgetDetails("SC41"),
                    DetailsSc42 = BudgetHelper.GetBudgetDetails("SC42"),
                    DetailsSc43 = BudgetHelper.GetBudgetDetails("SC43"),
                    DetailsSc44 = BudgetHelper.GetBudgetDetails("SC44"),
                    DetailsSc45 = BudgetHelper.GetBudgetDetails("SC45"),
                    DetailsSc46 = BudgetHelper.GetBudgetDetails("SC46"),
                    DetailsSc47 = BudgetHelper.GetBudgetDetails("SC47"),
                    DetailsSc48 = BudgetHelper.GetBudgetDetails("SC48"),
                    DetailsSc49 = BudgetHelper.GetBudgetDetails("SC49"),
                    DetailsSc50 = BudgetHelper.GetBudgetDetails("SC50"),
                    DetailsSc51 = BudgetHelper.GetBudgetDetails("SC51"),
                    DetailsSc52 = BudgetHelper.GetBudgetDetails("SC52"),
                    DetailsSc53 = BudgetHelper.GetBudgetDetails("SC53"),
                    DetailsSc54 = BudgetHelper.GetBudgetDetails("SC54"),
                };
                return View(adminView);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "FullName");
            ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name");            
            var view = new NewBudgetView
            {
                CompanyId = user.CompanyId,
                Date = DateTime.Now,
                DetailsSc01 = BudgetHelper.GetBudgetDetails("SC01"),
                DetailsSc02 = BudgetHelper.GetBudgetDetails("SC02"),
                DetailsSc03 = BudgetHelper.GetBudgetDetails("SC03"),
                DetailsSc04 = BudgetHelper.GetBudgetDetails("SC04"),
                DetailsSc05 = BudgetHelper.GetBudgetDetails("SC05"),
                DetailsSc06 = BudgetHelper.GetBudgetDetails("SC06"),
                DetailsSc07 = BudgetHelper.GetBudgetDetails("SC07"),
                DetailsSc08 = BudgetHelper.GetBudgetDetails("SC08"),
                DetailsSc09 = BudgetHelper.GetBudgetDetails("SC09"),
                DetailsSc10 = BudgetHelper.GetBudgetDetails("SC10"),
                DetailsSc11 = BudgetHelper.GetBudgetDetails("SC11"),
                DetailsSc12 = BudgetHelper.GetBudgetDetails("SC12"),
                DetailsSc13 = BudgetHelper.GetBudgetDetails("SC13"),
                DetailsSc14 = BudgetHelper.GetBudgetDetails("SC14"),
                DetailsSc15 = BudgetHelper.GetBudgetDetails("SC15"),
                DetailsSc16 = BudgetHelper.GetBudgetDetails("SC16"),
                DetailsSc17 = BudgetHelper.GetBudgetDetails("SC17"),
                DetailsSc18 = BudgetHelper.GetBudgetDetails("SC18"),
                DetailsSc19 = BudgetHelper.GetBudgetDetails("SC19"),
                DetailsSc20 = BudgetHelper.GetBudgetDetails("SC20"),
                DetailsSc21 = BudgetHelper.GetBudgetDetails("SC21"),
                DetailsSc22 = BudgetHelper.GetBudgetDetails("SC22"),
                DetailsSc23 = BudgetHelper.GetBudgetDetails("SC23"),
                DetailsSc24 = BudgetHelper.GetBudgetDetails("SC24"),
                DetailsSc25 = BudgetHelper.GetBudgetDetails("SC25"),
                DetailsSc26 = BudgetHelper.GetBudgetDetails("SC26"),
                DetailsSc27 = BudgetHelper.GetBudgetDetails("SC27"),
                DetailsSc28 = BudgetHelper.GetBudgetDetails("SC28"),
                DetailsSc29 = BudgetHelper.GetBudgetDetails("SC29"),
                DetailsSc30 = BudgetHelper.GetBudgetDetails("SC30"),
                DetailsSc31 = BudgetHelper.GetBudgetDetails("SC31"),
                DetailsSc32 = BudgetHelper.GetBudgetDetails("SC32"),
                DetailsSc33 = BudgetHelper.GetBudgetDetails("SC33"),
                DetailsSc34 = BudgetHelper.GetBudgetDetails("SC34"),
                DetailsSc35 = BudgetHelper.GetBudgetDetails("SC35"),
                DetailsSc36 = BudgetHelper.GetBudgetDetails("SC36"),
                DetailsSc37 = BudgetHelper.GetBudgetDetails("SC37"),
                DetailsSc38 = BudgetHelper.GetBudgetDetails("SC38"),
                DetailsSc39 = BudgetHelper.GetBudgetDetails("SC39"),
                DetailsSc40 = BudgetHelper.GetBudgetDetails("SC40"),
                DetailsSc41 = BudgetHelper.GetBudgetDetails("SC41"),
                DetailsSc42 = BudgetHelper.GetBudgetDetails("SC42"),
                DetailsSc43 = BudgetHelper.GetBudgetDetails("SC43"),
                DetailsSc44 = BudgetHelper.GetBudgetDetails("SC44"),
                DetailsSc45 = BudgetHelper.GetBudgetDetails("SC45"),
                DetailsSc46 = BudgetHelper.GetBudgetDetails("SC46"),
                DetailsSc47 = BudgetHelper.GetBudgetDetails("SC47"),
                DetailsSc48 = BudgetHelper.GetBudgetDetails("SC48"),
                DetailsSc49 = BudgetHelper.GetBudgetDetails("SC49"),
                DetailsSc50 = BudgetHelper.GetBudgetDetails("SC50"),
                DetailsSc51 = BudgetHelper.GetBudgetDetails("SC51"),
                DetailsSc52 = BudgetHelper.GetBudgetDetails("SC52"),
                DetailsSc53 = BudgetHelper.GetBudgetDetails("SC53"),
                DetailsSc54 = BudgetHelper.GetBudgetDetails("SC54"),
            };            
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", budget.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", budget.CustomerId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", budget.ProjectId);
            return View(budget);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", budget.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", budget.CustomerId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", budget.ProjectId);
            return View(budget);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", budget.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", budget.CustomerId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", budget.ProjectId);
            return View(budget);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = db.Budgets.Find(id);
            db.Budgets.Remove(budget);
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
