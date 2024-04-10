
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressService
{
	private readonly AddressRepository _addressRepository;
	private readonly UserRepository _repository;
	private readonly DataContexts _context;
	private readonly UserManager<UserEntity> _userManager;
	private readonly SignInManager<UserEntity> _signInManager;


	public AddressService(UserRepository repository, DataContexts context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressRepository addressRepository)
	{
		_repository = repository;
		_context = context;
		_userManager = userManager;
		_signInManager = signInManager;
		_addressRepository = addressRepository;
	}
	
	public async Task<bool> CreateAddressAsync(AddressEntity entity)
	{
		try
		{
			_context.Addresses.Add(entity);
			await _context.SaveChangesAsync();
			return true;
		}
		catch (Exception ex)
		{
             Console.WriteLine(ex.Message);
            return false;
		}
	}
	public async Task<bool> UpdateAddressAsync(AddressEntity entity)
	{
		try
		{
			var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == entity.Id);

			if (addressEntity != null)
			{
				_context.Entry(addressEntity).CurrentValues.SetValues(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}

	public async Task<AddressEntity> GetAdressAsync(int addressId)
	{
		try
		{
			var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);

			if (addressEntity != null)
			{
				return addressEntity;
			}
			return null;
		}
		catch (Exception ex)
		{	
			Console.WriteLine(ex.Message);
			return null;
		}
	
	}

}
