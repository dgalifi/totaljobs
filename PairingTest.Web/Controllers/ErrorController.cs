using System.Web.Mvc;

namespace PairingTest.Web.Controllers
{

    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View("Error");
        }
    }
}
