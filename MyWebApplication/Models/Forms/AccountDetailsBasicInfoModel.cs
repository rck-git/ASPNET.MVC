using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.Forms;

public class AccountDetailsBasicInfoModel
{
	public int AddressId { get; set; }

	[DataType(DataType.ImageUrl)]
	public string? ProfileImage { get; set; }

	[Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
	[Required(ErrorMessage = "Invalid first name")]
	[DataType(DataType.Text)]
	public string FirstName { get; set; } = null!;

	[Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
	[Required(ErrorMessage = "Invalid last name")]
	[DataType(DataType.Text)]
	public string LastName { get; set; } = null!;

	
	[Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
	[Required(ErrorMessage = "Invalid email adress")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = null!;
	
	
	
	[Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
	[Required(ErrorMessage = "Phone is required")]
	[DataType(DataType.PhoneNumber)]
	public string Phone { get; set; } = null!;

	[Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
	[DataType(DataType.MultilineText)]
	public string? Bio {  get; set; }
}
