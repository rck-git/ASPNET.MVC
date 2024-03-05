using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Account Overview";
        return View();
    }
    public IActionResult SignIn()
    {
        ViewData["Title"] = "Sign In";
        return View();
    }
    public IActionResult SignUp()
    {
        ViewData["Title"] = "Sign Up";

        return View();
    }
    public IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		return RedirectToAction(nameof(Index));
	}
    //send the form "model"/"object" via a userservice
    //userService.CreateUser(Form)
	public new IActionResult SignOut()
    {
        return RedirectToAction("Index","Home");
    }
}
