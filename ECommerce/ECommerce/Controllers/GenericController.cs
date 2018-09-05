using System.Linq;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class GenericController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

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