using Infrastructure.Entities;
using MyWebApplication.Models.Forms;

namespace MyWebApplication.Models.Views;

public class AccountDetailsViewModel
{
	public ProfileInfoViewModel profileInfo { get; set; } = null!;
	public AccountDetailsBasicInfoModel User { get; set; } = null!;
	public AccountDetailsAddressInfoModel AddressInfo { get; set; } = null!;
}
