using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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