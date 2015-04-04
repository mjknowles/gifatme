using System.Web.Mvc;

namespace GifAtMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Gif At Me";
            return View();
        }
    }
}