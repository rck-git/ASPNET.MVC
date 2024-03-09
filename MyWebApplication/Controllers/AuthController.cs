using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Forms;
using MyWebApplication.Models.Views;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AuthController : Controller
{

	[Route("/signin")]
	[HttpGet]
	public IActionResult SignIn()
    {
		ViewData["Title"] = "Sign In";

		SignInViewModel viewModel = new SignInViewModel();
        return View(viewModel);
    }

	[Route("/signin")]
	[HttpPost]
	public IActionResult SignIn(SignInViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		//	var result = _authService.SignIn(model.Form);
		//	if (result)
		//	{
		//		return RedirectToAction("Account", "Index");
		//	}

		//	model.ErrorMessage = "Incorrect email or password";
		//	return View(model);
		//}
		
		model.ErrorMessage = "Incorrect email or password";
		return View(model);

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


	public new IActionResult SignOut()
    {
        return RedirectToAction("Index","Home");
    }
}
