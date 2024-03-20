using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models;

public class SignInFormModel
{
	[DataType(DataType.EmailAddress)]
	[Display(Name = "Email address", Prompt = "Enter your email address", Order = 0)]
	[Required(ErrorMessage = "Invalid email adress")]

	public string Email { get; set; } = null!;

	[DataType(DataType.Password)]
	[Display(Name = "Password", Prompt = "Enter your Password", Order = 1)]
	[Required(ErrorMessage = "Invalid password")]
	public string Password { get; set; } = null!;


	[Display(Name = "Remember me", Order = 2)]
	public bool RememberMe { get; set; }
}
