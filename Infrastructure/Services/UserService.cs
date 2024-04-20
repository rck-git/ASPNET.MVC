using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService
{
    private readonly UserRepository _repository;
    private readonly AddressService _addressService;
	private readonly DataContexts _context;
	private readonly UserManager<UserEntity> _userManager;
	private readonly SignInManager<UserEntity> _signInManager;
	

	public UserService(UserRepository repository, AddressService addressService, DataContexts context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
	{
		_repository = repository;
		_addressService = addressService;
		_context = context;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<bool> UpdateUserAsync(UserEntity user)
	{
		
		var existingEntity = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
		if (existingEntity != null)
		{

			existingEntity.Firstname = user.Firstname;
			existingEntity.Lastname = user.Lastname;
			existingEntity.Email = user.Email;
			existingEntity.PhoneNumber = user.PhoneNumber;
			existingEntity.Bio = user.Bio;
			
			var result = await _userManager.UpdateAsync(existingEntity);
			return true;
		}
		return false;
	}
}
