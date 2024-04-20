using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Forms;
using MyWebApplication.Models.Views;
using System;

namespace MyWebApplication.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
	private readonly UserService _userService;
	private readonly AddressService _addressService;

	public AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, UserService userservice, AddressService addressService)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_userService = userservice;
		_addressService = addressService;
	}


	[Route("/account/details")]
	[HttpGet]
	public async Task <IActionResult> Details()
    {

		var viewModel = new AccountDetailsViewModel();

		viewModel.profileInfo = await PopulateProfileInfoAsync();
		viewModel.User ??= await PopulateBasicInfoAsync();
		viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

		return View(viewModel);
    }

	[HttpPost]
	[Route("/account/details")]
	public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
	{
		if (viewModel.User != null)
		{
			if (viewModel.User.FirstName != null && viewModel.User.LastName != null && viewModel.User.Email != null)
			{
				var userEntity = await _userManager.GetUserAsync(User);
				if (userEntity != null)
				{
					userEntity.Firstname = viewModel.User.FirstName;
					userEntity.Lastname = viewModel.User.LastName;
					userEntity.Email = viewModel.User.Email;
					userEntity.PhoneNumber = viewModel.User.Phone;
					userEntity.Bio = viewModel.User.Bio;

					var result = await _userManager.UpdateAsync(userEntity);
					if (!result.Succeeded)
					{
						ModelState.AddModelError("Error", "unable to update basic user data");
						ViewData["ErrorMessage"] = "Unable to update basic user data.";

					}
				}
			}
		}
		if (viewModel.AddressInfo != null)
		{
			if (viewModel.AddressInfo.Addressline_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
			{
				var userEntity = await _userManager.GetUserAsync(User);
				if (userEntity != null)
				{
					if (userEntity.AddressId == null)
					{
						AddressEntity addressEntity = new AddressEntity
						{
							AddressLine_1 = viewModel.AddressInfo.Addressline_1,
							AddressLine_2 = viewModel.AddressInfo.Addressline_2,
							PostalCode = viewModel.AddressInfo.PostalCode,
							City = viewModel.AddressInfo.City
						};

						var addressResult = await _addressService.CreateAddressAsync(addressEntity);
						if (!addressResult)
						{
							ModelState.AddModelError("Error", "unable to update address");
							ViewData["ErrorMessage"] = "Unable to update address.";

						}
						userEntity.AddressId = addressEntity.Id;
						_userService.UpdateUserAsync(userEntity);
					};

				}

				var address = await _addressService.GetAdressAsync((int)userEntity.AddressId);

				if (address != null)
				{
					address.AddressLine_1 = viewModel.AddressInfo.Addressline_1;
					address.AddressLine_2 = viewModel.AddressInfo.Addressline_2;
					address.PostalCode = viewModel.AddressInfo.PostalCode;
					address.City = viewModel.AddressInfo.City;

					var addressResult = await _addressService.UpdateAddressAsync(address);
					if (!addressResult)
					{
						ModelState.AddModelError("Error", "unable to update address");
						ViewData["ErrorMessage"] = "Unable to update address.";

					}
				}

				//userEntity.AddressId = address.Id;

				//var result2 = await _userManager.UpdateAsync(userEntity);
			}
		}


		viewModel.profileInfo = await PopulateProfileInfoAsync();
		viewModel.User ??= await PopulateBasicInfoAsync();
		viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

		return View(viewModel);
	}

	private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
	{
		try
		{
			var user = await _userManager.GetUserAsync(User);
			
			return new AccountDetailsBasicInfoModel
			{
				
				FirstName = user.Firstname,
				LastName = user.Lastname,
				Email = user.Email,
				Phone = user.PhoneNumber,
				Bio = user.Bio,
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return null!;
		}
	}
	private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
	{
		try
		{
			var user = await _userManager.GetUserAsync(User);
			
			return new ProfileInfoViewModel
			{
				
				FirstName = user.Firstname,
				LastName = user.Lastname,
				Email = user.Email!
			};
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return null!;
		}
	}
	private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
	{
		try
		{
			var user = await _userManager.GetUserAsync(User);

			if (user != null)
			{
				if (user.AddressId != null)
				{
					var address = await _addressService.GetAdressAsync((int)user.AddressId);
					var viewModel = new AccountDetailsAddressInfoModel
					{
						Addressline_1 = address.AddressLine_1,
						Addressline_2 = address.AddressLine_2,
						PostalCode = address.PostalCode,
						City = address.City,
					};
					return viewModel;
				}
			}

			return new AccountDetailsAddressInfoModel();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return null!;
		}
	}

	[HttpPost]
	public async Task<IActionResult> UploadProfileImage(IFormFile file)
	{
		var user = await _userManager.GetUserAsync(User);

		if (user != null && file != null && file.Length != 0)
		{
			var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/account", fileName);

			using var fs = new FileStream(filePath, FileMode.Create);
			await file.CopyToAsync(fs);

			user.ProfileImage = fileName;

			await _userManager.UpdateAsync(user);
		}
		else 
		{
			TempData["StatusMessage"] = "Unable to upload image"; 
		}
		
		return RedirectToAction("Details", "Account");
	}
}

