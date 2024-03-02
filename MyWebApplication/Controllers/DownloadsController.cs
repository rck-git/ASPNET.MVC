using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.Controllers
{
    public class DownloadsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Downloads";
            return View();
        }
    }
}
