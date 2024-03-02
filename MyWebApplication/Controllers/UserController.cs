using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult AccountDetails()
        {
            return View();
        }
    }
}
