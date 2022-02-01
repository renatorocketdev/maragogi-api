using System.Web.Mvc;

namespace AppMaragogiAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Panel() => View();
        
        public ActionResult Index() => View();
        public ActionResult Empresas() => View();
        public ActionResult SobreEmpresa(int id)
        {
            ViewBag.Id = id;

            return View();
        }
    }
}
