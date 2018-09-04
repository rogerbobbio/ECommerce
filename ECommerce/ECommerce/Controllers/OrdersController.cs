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
    public class OrdersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult AddProduct()
        {
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description");
                return View();
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductView newProduct)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(newProduct.ProductId);
                var orderDetailTmp = new OrderDetailTmp
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    Quantity = newProduct.Quantity,
                    TaxRate = product.Tax.Rate,
                    UserName = User.Identity.Name,
                };

                db.OrderDetailTmps.Add(orderDetailTmp);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(), "ProductId", "Description");
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProductId = new SelectList(CombosHelper.GetProducts(user.CompanyId), "ProductId", "Description");
            }
            return View(newProduct);
        }


        public ActionResult Index()
        {
            IQueryable<Order> orders;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                orders = db.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderState)
                    .Include(o => o.Project)
                    .Include(p => p.Company);
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
                    .Include(o => o.Project);
                //==================================================
            }            
            return View(orders.ToList());
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
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name");
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

            ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(user.CompanyId), "CustomerId", "FullName");            
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
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
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
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name", order.ProjectId);
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", order.CustomerId);
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Description", order.OrderStateId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", order.ProjectId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,ProjectId,OrderStateId,Date,Remarks")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CustomerId = new SelectList(CombosHelper.GetCustomers(), "CustomerId", "UserName", order.CustomerId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name", order.ProjectId);
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
