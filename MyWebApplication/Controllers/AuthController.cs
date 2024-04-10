using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Models.Forms;
using MyWebApplication.Models.Views;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace MyWebApplication.Controllers;

public class AuthController : Controller
{

	private readonly UserManager<UserEntity> _userManager;
	private readonly SignInManager<UserEntity> _signInManager;

	public AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}


	[Route("/signin")]
	[HttpGet]
	public IActionResult SignIn(string returnUrl)
    {
		

		ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
		ViewData["Title"] = "Sign In";
		SignInViewModel viewModel = new SignInViewModel();

        return View(viewModel);
    }

	[Route("/signin")]
	[HttpPost]
	public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
	{
	
		if (ModelState.IsValid)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Form.Email, model.Form.Password, model.Form.RememberMe, false);
			if (result.Succeeded)
			{	
				if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
					return Redirect(returnUrl);

				return RedirectToAction("Details", "Account");
			}
		}
		ModelState.AddModelError("Error", "Incorrect email or password\"");
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
			var exists = await _userManager.Users.AnyAsync(x => x.Email == model.Form.Email);
			if (exists)
			{
				ModelState.AddModelError("AlreadyExists", "User with the same email address already exists");
				return View(model);
			}
			var userEntity = new UserEntity
			{
				Firstname = model.Form.FirstName,
				Lastname = model.Form.LastName,
				Email = model.Form.Email,
				UserName = model.Form.Email,
			};
			var result = await _userManager.CreateAsync(userEntity, model.Form.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Auth");
			}
		}
		return View(model);

	}


	[HttpGet]
	[Route("/signout")]
	public new  async Task<IActionResult> SignOut()
    {
		await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }
}
