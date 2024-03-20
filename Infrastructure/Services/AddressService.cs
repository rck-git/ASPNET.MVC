
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService
{
	private readonly AddressRepository _Repository;

	public AddressService(AddressRepository repository)
	{
		_Repository = repository;
	}
	public async Task<ResponseResult> GetOrCreateAdressAsync(string streetname, string postalCode, string city)
	{
		try
		{
			var result = await GetAdressAsync(streetname, postalCode, city);
			if (result.StatusCode == StatusCode.NOTFOUND) 
			{
				result = await CreateAdressAsync(streetname, postalCode, city);
			}
			return result;
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

	public async Task<ResponseResult> CreateAdressAsync(string streetname, string postalCode, string city)
	{
		try
		{
			var exists = await _Repository.AlreadyExistsAsync(x => x.StreetName == streetname && x.PostalCode == postalCode && x.City == city);
			if (exists == null)
			{
				var result = await _Repository.CreateAsync(AddressFactory.Create(streetname, postalCode, city));
				if (result.StatusCode == StatusCode.OK)
				{
					return ResponseFactory.Ok(AddressFactory.Create((AddressEntity)result.ContentResult!));
				}
				return result;
			}
			return exists;
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}
	public async Task<ResponseResult> GetAdressAsync(string streetname, string postalCode, string city)
	{
		try
		{
			var result = await _Repository.GetOneAsync(x => x.StreetName == streetname && x.PostalCode == postalCode && x.City == city);
			return result;
		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}
	}

}
