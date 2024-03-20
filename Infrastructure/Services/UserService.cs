using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService
{
    private readonly UserRepository _repository;
    private readonly AddressService _addressService;

    public UserService(UserRepository repository, AddressService addressService)
    {
        _repository = repository;
        _addressService = addressService;
    }

    public async Task<ResponseResult> CreateUserAsync(SignUpFormModel model)
    {
        try
        {
            var exists = await _repository.AlreadyExistsAsync(x => x.Email == model.Email);
            if (exists.StatusCode == StatusCode.EXISTS)
                return exists;

			var result = await _repository.CreateAsync(UserFactory.Create(model));

			if (result.StatusCode != StatusCode.OK)
			{
				return result;
			}
			
			return ResponseFactory.Ok("User was created successfully.");
		}
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }

    }
	public async Task<ResponseResult> SignInUserAsync(SignInFormModel model)
	{
		try
		{
			var result = await _repository.GetOneAsync(x => x.Email == model.Email);
			if (result.StatusCode == StatusCode.OK && result.ContentResult != null)
			{
				var userEntity = (UserEntity)result.ContentResult;
				if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
				{
					return ResponseFactory.Ok();
				}
			}
				return ResponseFactory.Error("Incorrect email or password.");

		}
		catch (Exception ex)
		{
			return ResponseFactory.Error(ex.Message);
		}

	}
}
