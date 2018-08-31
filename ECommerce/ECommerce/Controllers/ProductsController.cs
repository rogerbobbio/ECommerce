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
    public class ProductsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        
        public ActionResult Index()
        {
            IQueryable<Product> products;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                products = db.Products.Include(p => p.Company).Include(p => p.ProductCategory).Include(p => p.Tax);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                products = db.Products.Where(c => c.CompanyId == user.CompanyId);
                //==================================================
            }
            
            return View(products.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        public ActionResult Create()
        {            
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(), "ProductCategoryId", "Description");
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(), "TaxId", "Description");
                return View();
            }
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(user.CompanyId), "ProductCategoryId", "Description");
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(user.CompanyId), "TaxId", "Description");
            var product = new Product { CompanyId = user.CompanyId };
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {                    
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    
                    if (product.ImageFile != null)
                    {
                        const string folder = "~/Content/Products";
                        var file = string.Format("{0}.jpg", product.ProductId);

                        var response = FilesHelper.UploadPhoto(product.ImageFile, folder, file);
                        if (response)
                        {
                            var pic = string.Format("{0}/{1}", folder, file);
                            product.Image = pic;
                            db.Entry(product).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

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

            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", product.CompanyId);
            ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(), "ProductCategoryId", "Description", product.ProductCategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(), "TaxId", "Description", product.TaxId);
            return View(product);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", product.CompanyId);
                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(), "ProductCategoryId", "Description", product.ProductCategoryId);
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(), "TaxId", "Description", product.TaxId);
            }
            else
            {                
                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(product.CompanyId), "ProductCategoryId", "Description", product.ProductCategoryId);
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(product.CompanyId), "TaxId", "Description", product.TaxId);                
            }

            return View(product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageFile != null)
                    {
                        var pic = string.Empty;
                        const string folder = "~/Content/Products";
                        var file = string.Format("{0}.jpg", product.CompanyId);
                        var response = FilesHelper.UploadPhoto(product.ImageFile, folder, file);
                        if (response)
                        {
                            pic = string.Format("{0}/{1}.", folder, file);
                            product.Image = pic;
                        }
                    }                    

                    db.Entry(product).State = EntityState.Modified;
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
            ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", product.CompanyId);
            ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(), "ProductCategoryId", "Description", product.ProductCategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(), "TaxId", "Description", product.TaxId);
            return View(product);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
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
            return View(product);
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
