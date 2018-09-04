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
    public class UsersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index()
        {
            IQueryable<User> users;
            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            //Note: Include es un INNER JOIN
            if (adminUser == User.Identity.Name)
                users = db.Users
                    .Include(u => u.City)
                    .Include(u => u.Company)
                    .Include(u => u.Department)
                    .Include(u => u.PensionSystem)
                    .Include(u => u.Project)
                    .Include(u => u.UserRol);
            else
            {
                //verifica el usuario logeado y filtra por su compania
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null)
                    return RedirectToAction("Index", "Home");

                users = db.Users.Where(c => c.CompanyId == user.CompanyId);
                //==================================================
            }
            
            return View(users.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name");            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name");
            ViewBag.PensionSystemId = new SelectList(CombosHelper.GetPensionSystems(), "PensionSystemId", "Name");            

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {                
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name");
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name");
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(), "UserRolId", "Name");
                var adminUserModel = new User
                {
                    State = true,
                    AdmissionDate = DateTime.Now,
                };
                return View(adminUserModel);
            }            
            //verifica el usuario logeado y envia su compania a la vista
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return RedirectToAction("Index", "Home");

            ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name");
            ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(user.CompanyId), "UserRolId", "Name");
            var userModel = new User
            {
                CompanyId = user.CompanyId,
                AdmissionDate = DateTime.Now,
                State = true,
            };
            return View(userModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    UsersHelper.CreateUserASP(user.UserName, "User");

                    if (user.PhotoFile != null)
                    {
                        const string folder = "~/Content/Users";
                        var file = string.Format("{0}.jpg", user.UserId);

                        var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                        if (response)
                        {
                            var pic = string.Format("{0}/{1}", folder, file);
                            user.Photo = pic;
                            db.Entry(user).State = EntityState.Modified;
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

            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", user.CityId);            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            ViewBag.PensionSystemId = new SelectList(CombosHelper.GetPensionSystems(), "PensionSystemId", "Name", user.PensionSystemId);

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);

                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(), "UserRolId", "Name", user.UserRolId);
            }
            else
            {
                var userIdentity = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(userIdentity.CompanyId), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(userIdentity.CompanyId), "UserRolId", "Name", user.UserRolId);
            }
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", user.CityId);            
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            ViewBag.PensionSystemId = new SelectList(CombosHelper.GetPensionSystems(), "PensionSystemId", "Name", user.PensionSystemId);            

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(), "UserRolId", "Name", user.UserRolId);
            }
            else
            {
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(user.CompanyId), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(user.CompanyId), "UserRolId", "Name", user.UserRolId);
            }

            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (user.PhotoFile != null)
                    {
                        var pic = string.Empty;
                        const string folder = "~/Content/Users";
                        var file = string.Format("{0}.jpg", user.UserId);
                        var response = FilesHelper.UploadPhoto(user.PhotoFile, folder, file);
                        if (response)
                        {
                            pic = string.Format("{0}/{1}.", folder, file);
                            user.Photo = pic;
                        }
                    }

                    var db2 = new ECommerceContext();
                    var currentUser = db2.Users.Find(user.UserId);
                    if (currentUser.UserName != user.UserName)
                    {
                        UsersHelper.UpdateUserName(currentUser.UserName, user.UserName);
                    }
                    db2.Dispose();

                    db.Entry(user).State = EntityState.Modified;
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
            ViewBag.CityId = new SelectList(CombosHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.DepartmentId = new SelectList(CombosHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            ViewBag.PensionSystemId = new SelectList(CombosHelper.GetPensionSystems(), "PensionSystemId", "Name", user.PensionSystemId);

            var adminUser = WebConfigurationManager.AppSettings["AdminUser"];
            if (adminUser == User.Identity.Name)
            {
                ViewBag.CompanyId = new SelectList(CombosHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);

                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(), "UserRolId", "Name", user.UserRolId);
            }
            else
            {
                var userIdentity = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ViewBag.ProjectId = new SelectList(CombosHelper.GetProjects(userIdentity.CompanyId), "ProjectId", "Name", user.ProjectId);
                ViewBag.UserRolId = new SelectList(CombosHelper.GetUserRols(userIdentity.CompanyId), "UserRolId", "Name", user.UserRolId);
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            try
            {
                db.SaveChanges();
                UsersHelper.DeleteUser(user.UserName);
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
            return View(user);
        }

        public JsonResult GetCities(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartmentId == departmentId);
            return Json(cities);
        }

        public JsonResult GetProjects(int companyId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var projects = db.Projects.Where(c => c.CompanyId == companyId);
            return Json(projects);
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
