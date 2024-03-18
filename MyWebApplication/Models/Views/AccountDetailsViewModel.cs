using MyWebApplication.Models.Forms;

namespace MyWebApplication.Models.Views;

public class AccountDetailsViewModel
{
	public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
	{
		ProfileImage = "/images/account/profile-image.svg",
		FirstName = "Rickard",
		LastName = "last",
		Email = "Email@domain.com",
		Phone = "123",
		//Bio = "Demo Bio",
	};

	public AccountDetailsAddressInfoModel AdressInfo { get; set; } = new AccountDetailsAddressInfoModel();
}
