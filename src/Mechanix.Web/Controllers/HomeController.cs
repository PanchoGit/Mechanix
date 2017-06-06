using System.Web.Mvc;

namespace Mechanix.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}