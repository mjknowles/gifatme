using GifAtMe.Service.Interfaces;
using GifAtMe.Service.Messaging.GifEntries;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GifAtMe.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly IGifEntryService _gifEntryService;

        public HomeController(IGifEntryService gifEntryService)
        {
            if (gifEntryService == null) throw new ArgumentNullException("GifEntry service in GifEntry controller");
            _gifEntryService = gifEntryService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Gif At Me";
            return View(_gifEntryService.GetGifEntries(new GetGifEntriesRequest(User.Identity.GetUserId(), String.Empty, String.Empty)).GifEntries);
        }
    }
}