using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Forms;
using MyWebApplication.Models.Views;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AuthController : Controller
{

	[Route("/signin")]
	public IActionResult SignIn()
    {
		SignUpViewModel viewModel = new SignUpViewModel();
		ViewData["Title"] = "Sign In";
        return View(viewModel);
    }



    [Route("/signup")]
	[HttpGet]
	public IActionResult SignUp()
    {
        ViewData["Title"] = "Sign Up";

		SignUpViewModel viewModel = new SignUpViewModel();
		
        return View(viewModel);
	}


	[Route("/signup")]
	[HttpPost]
	public IActionResult SignUp(SignUpViewModel model)
	{
		ViewData["Title"] = "Sign Up";

		if (!ModelState.IsValid)
		{
			return View(model);
		}
		//return View(model);
		return RedirectToAction("SignIn", "Auth");
	}


	//public IActionResult OnPost()
	//{
	//	if (!ModelState.IsValid)
	//	{
	//		return View();
	//	}
	//	return RedirectToAction(nameof(Index));
	//}
	//send the form "model"/"object" via a userservice
	//userService.CreateUser(Form)
	public new IActionResult SignOut()
    {
        return RedirectToAction("Index","Home");
    }
}
