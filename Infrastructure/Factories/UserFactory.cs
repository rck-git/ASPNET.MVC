

using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
	public static UserEntity Create()
	{
		try
		{
			var date = DateTime.Now;

			return new UserEntity()
			{
				Id = Guid.NewGuid().ToString(),
				Created	= date,
				Modified = date,
			};
		}
		catch (Exception)
		{
		}
		return null!;
	}

	public static UserEntity Create(SignUpFormModel model)
	{
		try
		{
			var date = DateTime.Now;

			var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);

			return new UserEntity 
			{ 
				Id = Guid.NewGuid().ToString(),
				Firstname = model.FirstName,
				Lastname = model.LastName,
				Email = model.Email,
				Password = password,
				SecurityKey = securityKey,
				Created = date,
				Modified = date,
			};

		}
		catch (Exception)
		{
		}
		return null!;
	}
}
