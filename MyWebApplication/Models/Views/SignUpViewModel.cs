using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace MyWebApplication.Models.Views;

public class SignUpViewModel
{
	public SignUpFormModel Form { get; set; } = new SignUpFormModel();

}
