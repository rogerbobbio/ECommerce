using System;
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

        [HttpPost]
        public void AddDetails()
        {
            BudgetHelper.AddBudgetDetails(User.Identity.Name);
        }

        public ActionResult Create()
        {
            AddDetails();
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "FullName");
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name");
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");                
                var adminView = new NewBudgetView
                {
                    Date = DateTime.Now,
                    DetailsSc01 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC01").ToList(),
                    DetailsSc02 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC02").ToList(),
                    DetailsSc03 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC03").ToList(),
                    DetailsSc04 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC04").ToList(),
                    DetailsSc05 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC05").ToList(),
                    DetailsSc06 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC06").ToList(),
                    DetailsSc07 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC07").ToList(),
                    DetailsSc08 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC08").ToList(),
                    DetailsSc09 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC09").ToList(),
                    DetailsSc10 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC10").ToList(),
                    DetailsSc11 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC11").ToList(),
                    DetailsSc12 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC12").ToList(),
                    DetailsSc13 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC13").ToList(),
                    DetailsSc14 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC14").ToList(),
                    DetailsSc15 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC15").ToList(),
                    DetailsSc16 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC16").ToList(),
                    DetailsSc17 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC17").ToList(),
                    DetailsSc18 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC18").ToList(),
                    DetailsSc19 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC19").ToList(),
                    DetailsSc20 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC20").ToList(),
                    DetailsSc21 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC21").ToList(),
                    DetailsSc22 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC22").ToList(),
                    DetailsSc23 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC23").ToList(),
                    DetailsSc24 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC24").ToList(),
                    DetailsSc25 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC25").ToList(),
                    DetailsSc26 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC26").ToList(),
                    DetailsSc27 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC27").ToList(),
                    DetailsSc28 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC28").ToList(),
                    DetailsSc29 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC29").ToList(),
                    DetailsSc30 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC30").ToList(),
                    DetailsSc31 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC31").ToList(),
                    DetailsSc32 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC32").ToList(),
                    DetailsSc33 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC33").ToList(),
                    DetailsSc34 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC34").ToList(),
                    DetailsSc35 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC35").ToList(),
                    DetailsSc36 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC36").ToList(),
                    DetailsSc37 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC37").ToList(),
                    DetailsSc38 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC38").ToList(),
                    DetailsSc39 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC39").ToList(),
                    DetailsSc40 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC40").ToList(),
                    DetailsSc41 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC41").ToList(),
                    DetailsSc42 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC42").ToList(),
                    DetailsSc43 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC43").ToList(),
                    DetailsSc44 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC44").ToList(),
                    DetailsSc45 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC45").ToList(),
                    DetailsSc46 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC46").ToList(),
                    DetailsSc47 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC47").ToList(),
                    DetailsSc48 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC48").ToList(),
                    DetailsSc49 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC49").ToList(),
                    DetailsSc50 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC50").ToList(),
                    DetailsSc51 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC51").ToList(),
                    DetailsSc52 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC52").ToList(),
                    DetailsSc53 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC53").ToList(),
                    DetailsSc54 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC54").ToList(),
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
                DetailsSc01 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC01").ToList(),
                DetailsSc02 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC02").ToList(),
                DetailsSc03 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC03").ToList(),
                DetailsSc04 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC04").ToList(),
                DetailsSc05 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC05").ToList(),
                DetailsSc06 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC06").ToList(),
                DetailsSc07 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC07").ToList(),
                DetailsSc08 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC08").ToList(),
                DetailsSc09 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC09").ToList(),
                DetailsSc10 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC10").ToList(),
                DetailsSc11 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC11").ToList(),
                DetailsSc12 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC12").ToList(),
                DetailsSc13 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC13").ToList(),
                DetailsSc14 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC14").ToList(),
                DetailsSc15 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC15").ToList(),
                DetailsSc16 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC16").ToList(),
                DetailsSc17 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC17").ToList(),
                DetailsSc18 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC18").ToList(),
                DetailsSc19 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC19").ToList(),
                DetailsSc20 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC20").ToList(),
                DetailsSc21 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC21").ToList(),
                DetailsSc22 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC22").ToList(),
                DetailsSc23 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC23").ToList(),
                DetailsSc24 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC24").ToList(),
                DetailsSc25 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC25").ToList(),
                DetailsSc26 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC26").ToList(),
                DetailsSc27 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC27").ToList(),
                DetailsSc28 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC28").ToList(),
                DetailsSc29 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC29").ToList(),
                DetailsSc30 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC30").ToList(),
                DetailsSc31 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC31").ToList(),
                DetailsSc32 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC32").ToList(),
                DetailsSc33 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC33").ToList(),
                DetailsSc34 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC34").ToList(),
                DetailsSc35 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC35").ToList(),
                DetailsSc36 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC36").ToList(),
                DetailsSc37 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC37").ToList(),
                DetailsSc38 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC38").ToList(),
                DetailsSc39 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC39").ToList(),
                DetailsSc40 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC40").ToList(),
                DetailsSc41 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC41").ToList(),
                DetailsSc42 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC42").ToList(),
                DetailsSc43 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC43").ToList(),
                DetailsSc44 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC44").ToList(),
                DetailsSc45 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC45").ToList(),
                DetailsSc46 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC46").ToList(),
                DetailsSc47 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC47").ToList(),
                DetailsSc48 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC48").ToList(),
                DetailsSc49 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC49").ToList(),
                DetailsSc50 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC50").ToList(),
                DetailsSc51 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC51").ToList(),
                DetailsSc52 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC52").ToList(),
                DetailsSc53 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC53").ToList(),
                DetailsSc54 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC54").ToList(),
            };            
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewBudgetView budget)
        {
            if (ModelState.IsValid)
            {
                var response = MovementsHelper.NewBudget(budget, User.Identity.Name);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "UserName",budget.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(budget.CompanyId), "ProjectId", "Name",budget.ProjectId);
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", budget.CompanyId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(user.CompanyId), "CustomerId", "UserName",budget.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name",budget.ProjectId);
            }
            budget.DetailsSc01 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC01").ToList();
            budget.DetailsSc02 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC02").ToList();
            budget.DetailsSc03 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC03").ToList();
            budget.DetailsSc04 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC04").ToList();
            budget.DetailsSc05 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC05").ToList();
            budget.DetailsSc06 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC06").ToList();
            budget.DetailsSc07 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC07").ToList();
            budget.DetailsSc08 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC08").ToList();
            budget.DetailsSc09 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC09").ToList();
            budget.DetailsSc10 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC10").ToList();
            budget.DetailsSc11 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC11").ToList();
            budget.DetailsSc12 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC12").ToList();
            budget.DetailsSc13 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC13").ToList();
            budget.DetailsSc14 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC14").ToList();
            budget.DetailsSc15 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC15").ToList();
            budget.DetailsSc16 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC16").ToList();
            budget.DetailsSc17 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC17").ToList();
            budget.DetailsSc18 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC18").ToList();
            budget.DetailsSc19 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC19").ToList();
            budget.DetailsSc20 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC20").ToList();
            budget.DetailsSc21 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC21").ToList();
            budget.DetailsSc22 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC22").ToList();
            budget.DetailsSc23 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC23").ToList();
            budget.DetailsSc24 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC24").ToList();
            budget.DetailsSc25 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC25").ToList();
            budget.DetailsSc26 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC26").ToList();
            budget.DetailsSc27 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC27").ToList();
            budget.DetailsSc28 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC28").ToList();
            budget.DetailsSc29 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC29").ToList();
            budget.DetailsSc30 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC30").ToList();
            budget.DetailsSc31 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC31").ToList();
            budget.DetailsSc32 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC32").ToList();
            budget.DetailsSc33 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC33").ToList();
            budget.DetailsSc34 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC34").ToList();
            budget.DetailsSc35 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC35").ToList();
            budget.DetailsSc36 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC36").ToList();
            budget.DetailsSc37 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC37").ToList();
            budget.DetailsSc38 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC38").ToList();
            budget.DetailsSc39 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC39").ToList();
            budget.DetailsSc40 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC40").ToList();
            budget.DetailsSc41 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC41").ToList();
            budget.DetailsSc42 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC42").ToList();
            budget.DetailsSc43 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC43").ToList();
            budget.DetailsSc44 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC44").ToList();
            budget.DetailsSc45 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC45").ToList();
            budget.DetailsSc46 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC46").ToList();
            budget.DetailsSc47 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC47").ToList();
            budget.DetailsSc48 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC48").ToList();
            budget.DetailsSc49 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC49").ToList();
            budget.DetailsSc50 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC50").ToList();
            budget.DetailsSc51 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC51").ToList();
            budget.DetailsSc52 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC52").ToList();
            budget.DetailsSc53 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC53").ToList();
            budget.DetailsSc54 = db.BudgetDetailTmps.Where(odt => odt.UserName == User.Identity.Name && odt.SubcategoryCode == "SC54").ToList();
            return View(budget);
        }

        public ActionResult EditBudgetDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var budgetDetailTmp = db.BudgetDetailTmps.Find(id);
            if (budgetDetailTmp == null)
            {
                return HttpNotFound();
            }

            var editBudgetDetailView = new EditBudgetDetailView
            {
                BudgetDetailTmpId = (int)id,
                Description = budgetDetailTmp.Description,
                Category = budgetDetailTmp.Category,
                Subcategory = budgetDetailTmp.Subcategory,
                Metered = budgetDetailTmp.Metered,
                UnitPrice = budgetDetailTmp.UnitPrice,
                Remarks = budgetDetailTmp.Remarks,
            };
            return PartialView(editBudgetDetailView);
        }

        [HttpPost]
        public ActionResult EditBudgetDetail(EditBudgetDetailView editBudgetDetail)
        {
            if (ModelState.IsValid)
            {
                var budgetDetailTmp = db.BudgetDetailTmps.FirstOrDefault(odt => odt.UserName == User.Identity.Name && odt.BudgetDetailTmpId == editBudgetDetail.BudgetDetailTmpId);
                if (budgetDetailTmp != null)
                {
                    budgetDetailTmp.UnitPrice = editBudgetDetail.UnitPrice;
                    budgetDetailTmp.Metered = editBudgetDetail.Metered;
                    budgetDetailTmp.PartialPrice = editBudgetDetail.UnitPrice * (decimal)editBudgetDetail.Metered;
                    budgetDetailTmp.Remarks = editBudgetDetail.Remarks;
                    db.Entry(budgetDetailTmp).State = EntityState.Modified;
                    var responseSave = DBHelper.SaveChanges(db);
                    if (responseSave.Succeeded)
                    {
                        return RedirectToAction("Create");
                    }
                    ModelState.AddModelError(string.Empty, responseSave.Message);
                }
            }
            return PartialView(editBudgetDetail);
        }

        public ActionResult Edit(int? id)
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

            var editView = new EditBudgetView
            {
                BudgetId = budget.BudgetId,
                Company = budget.Company.Name,
                Customer = budget.Customer.FullName,
                Project = budget.Project.Name,
                Date = budget.Date,
                Remarks = budget.Remarks,

                DetailsSc01 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC01").ToList(),
                DetailsSc02 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC02").ToList(),
                DetailsSc03 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC03").ToList(),
                DetailsSc04 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC04").ToList(),
                DetailsSc05 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC05").ToList(),
                DetailsSc06 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC06").ToList(),
                DetailsSc07 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC07").ToList(),
                DetailsSc08 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC08").ToList(),
                DetailsSc09 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC09").ToList(),
                DetailsSc10 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC10").ToList(),
                DetailsSc11 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC11").ToList(),
                DetailsSc12 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC12").ToList(),
                DetailsSc13 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC13").ToList(),
                DetailsSc14 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC14").ToList(),
                DetailsSc15 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC15").ToList(),
                DetailsSc16 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC16").ToList(),
                DetailsSc17 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC17").ToList(),
                DetailsSc18 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC18").ToList(),
                DetailsSc19 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC19").ToList(),
                DetailsSc20 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC20").ToList(),
                DetailsSc21 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC21").ToList(),
                DetailsSc22 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC22").ToList(),
                DetailsSc23 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC23").ToList(),
                DetailsSc24 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC24").ToList(),
                DetailsSc25 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC25").ToList(),
                DetailsSc26 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC26").ToList(),
                DetailsSc27 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC27").ToList(),
                DetailsSc28 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC28").ToList(),
                DetailsSc29 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC29").ToList(),
                DetailsSc30 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC30").ToList(),
                DetailsSc31 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC31").ToList(),
                DetailsSc32 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC32").ToList(),
                DetailsSc33 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC33").ToList(),
                DetailsSc34 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC34").ToList(),
                DetailsSc35 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC35").ToList(),
                DetailsSc36 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC36").ToList(),
                DetailsSc37 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC37").ToList(),
                DetailsSc38 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC38").ToList(),
                DetailsSc39 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC39").ToList(),
                DetailsSc40 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC40").ToList(),
                DetailsSc41 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC41").ToList(),
                DetailsSc42 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC42").ToList(),
                DetailsSc43 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC43").ToList(),
                DetailsSc44 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC44").ToList(),
                DetailsSc45 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC45").ToList(),
                DetailsSc46 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC46").ToList(),
                DetailsSc47 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC47").ToList(),
                DetailsSc48 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC48").ToList(),
                DetailsSc49 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC49").ToList(),
                DetailsSc50 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC50").ToList(),
                DetailsSc51 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC51").ToList(),
                DetailsSc52 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC52").ToList(),
                DetailsSc53 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC53").ToList(),
                DetailsSc54 = db.BudgetDetails.Where(odt => odt.BudgetId == budget.BudgetId && odt.SubcategoryCode == "SC54").ToList(),
            };

            return View(editView);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBudgetView budget)
        {
            if (ModelState.IsValid)
            {
                var response = MovementsHelper.EditBudget(budget);
                if (response.Succeeded)
                {
                return RedirectToAction("Index");
            }

                ModelState.AddModelError(string.Empty, response.Message);
            }            
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
