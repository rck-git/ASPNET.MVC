using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Forms;
using MyWebApplication.Models.Views;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AuthController : Controller
{

	private readonly UserService _userService;

	public AuthController(UserService userService)
	{
		_userService = userService;
	}

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
	public async Task<IActionResult> SignIn(SignInViewModel model)
	{
		if (ModelState.IsValid)
		{
			var result = await _userService.SignInUserAsync(model.Form);
			if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
				return RedirectToAction("Details", "Account");
		}
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
	public async Task<IActionResult> SignUp(SignUpViewModel model)
	{
		ViewData["Title"] = "Sign Up";

		if (ModelState.IsValid)
		{
			var result = await _userService.CreateUserAsync(model.Form);
			if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
			{
				return RedirectToAction("SignIn", "Auth");
			}
		}
		return View(model);
		
	}


	public new IActionResult SignOut()
    {
        return RedirectToAction("Index","Home");
    }
}
