using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.Views
{
	public class ProfileInfoViewModel
	{

		public string ProfileImageUrl { get; set; } = "profile-image.svg";
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;

	}
}
