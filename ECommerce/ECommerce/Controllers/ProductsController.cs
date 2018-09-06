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
    public class ProductsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            IQueryable<Product> products;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
                products = db.Products
                    .Include(p => p.Company)
                    .Include(p => p.ProductCategory)
                    .Include(p => p.Tax).OrderBy(c => c.Description);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                products = db.Products
                    .Include(p => p.ProductCategory)
                    .Include(p => p.Tax)
                    .Where(p => p.CompanyId == user.CompanyId).OrderBy(c => c.Description);
                //==================================================
            }
            
            return View(products.ToPagedList((int)page, 5));
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
            var product = new Product
            {
                CompanyId = user.CompanyId
            };
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                var responseSave = DBHelper.SaveChanges(db);
                if (responseSave.Succeeded)
                {
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
                ModelState.AddModelError(string.Empty, responseSave.Message);
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
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(user.CompanyId), "ProductCategoryId", "Description", product.ProductCategoryId);
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(user.CompanyId), "TaxId", "Description", product.TaxId);
            }
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
                if (product.ImageFile != null)
                {
                    var pic = string.Empty;
                    const string folder = "~/Content/Products";
                    var file = string.Format("{0}.jpg", product.ProductId);
                    var response = FilesHelper.UploadPhoto(product.ImageFile, folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}.", folder, file);
                        product.Image = pic;
                    }
                }

                db.Entry(product).State = EntityState.Modified;
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
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", product.CompanyId);

                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(), "ProductCategoryId", "Description", product.ProductCategoryId);
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(), "TaxId", "Description", product.TaxId);
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProductCategoryId = new SelectList(CombosHelper.GetProductCategories(user.CompanyId), "ProductCategoryId", "Description", product.ProductCategoryId);
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(user.CompanyId), "TaxId", "Description", product.TaxId);
            }            
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
            var responseSave = DBHelper.SaveChanges(db);
            if (responseSave.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, responseSave.Message);
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
