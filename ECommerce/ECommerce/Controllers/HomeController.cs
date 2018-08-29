using System.Linq;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public ActionResult Index()
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "ECommerce System .NET.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Informacion de Contacto.";

            return View();
        }
    }
}