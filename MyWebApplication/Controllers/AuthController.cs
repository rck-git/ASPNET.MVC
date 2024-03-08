using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AuthController : Controller
{
	[Route("/signin")]
	public IActionResult SignIn()
    {
        ViewData["Title"] = "Sign In";
        return View();
    }
    [Route("/signup")]
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
