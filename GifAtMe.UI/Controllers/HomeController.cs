using System.Web.Mvc;

namespace GifAtMe.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Gif At Me";
            return View();
        }
    }
}