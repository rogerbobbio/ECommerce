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
    public class OrdersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult DeleteProducts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetailTmp = db.OrderDetailTmps.FirstOrDefault(odt => odt.UserName == User.Identity.Name && odt.ProductId == id);
            if (orderDetailTmp == null)
            {
                return HttpNotFound();
            }
            db.OrderDetailTmps.Remove(orderDetailTmp);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult AddProduct()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(true), "ProductId", "Description");
                return PartialView();
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId, true), "ProductId", "Description");
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductView newProduct)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (ModelState.IsValid)
            {
                var orderDetailTmp = db.OrderDetailTmps.FirstOrDefault(odt => odt.UserName == User.Identity.Name && odt.ProductId == newProduct.ProductId);
                if (orderDetailTmp == null)
                {
                    var product = db.Products.Find(newProduct.ProductId);
                    orderDetailTmp = new OrderDetailTmp
                    {
                        Description = product.Description,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        Quantity = newProduct.Quantity,
                        TaxRate = product.Tax.Rate,
                        UserName = User.Identity.Name,
                    };

                    db.OrderDetailTmps.Add(orderDetailTmp);
                }
                else
                {
                    orderDetailTmp.Quantity += newProduct.Quantity;
                    db.Entry(orderDetailTmp).State = EntityState.Modified;
                }
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
                    return RedirectToAction("Create");
                }
                ModelState.AddModelError(string.Empty, responseSave.Message);                                
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description");
            }
            else
            {                
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description");
            }
            return PartialView(newProduct);
        }




        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<Order> orders;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                orders = db.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderState)
                    .Include(o => o.Project)
                    .Include(p => p.Company).OrderByDescending(c => c.Date);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                orders = db.Orders
                    .Where(c => c.CompanyId == user.CompanyId)
                    .Include(o => o.Customer)
                    .Include(o => o.OrderState)
                    .Include(o => o.Project).OrderByDescending(c => c.Date);
                //==================================================
            }
            
            return View(orders.ToPagedList((int)page, 5));
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        
        public ActionResult Create()
        {            
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "FullName");
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(0), "ProjectId", "Name");
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                var adminView = new NewOrderView
                {                    
                    Date = DateTime.Now,
                    Details = db.OrderDetailTmps.Where(odt => odt.UserName == User.Identity.Name).ToList(),
                };
                return View(adminView);
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "FullName");            
            ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name");
            var view = new NewOrderView
            {
                CompanyId = user.CompanyId,
                Date = DateTime.Now,
                Details = db.OrderDetailTmps.Where(odt => odt.UserName == User.Identity.Name).ToList(),
            };            
            return View(view);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewOrderView order)
        {
            if (ModelState.IsValid)
            {
                var response = MovementsHelper.NewOrder(order, User.Identity.Name);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, response.Message);                
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(order.CompanyId), "ProjectId", "Name", order.ProjectId);
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", order.CompanyId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(user.CompanyId), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name", order.ProjectId);
            }
            order.Details = db.OrderDetailTmps.Where(odt => odt.UserName == User.Identity.Name).ToList();
            return View(order);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", order.CustomerId);
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Description", order.OrderStateId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", order.ProjectId);
            return View(order);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,ProjectId,OrderStateId,Date,Remarks")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
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
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(order.CompanyId), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(order.CompanyId), "ProjectId", "Name", order.ProjectId);
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "ProjectId", "Name", order.CompanyId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(user.CompanyId), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name", order.ProjectId);
            }            
            return View(order);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
            return View(order);
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
