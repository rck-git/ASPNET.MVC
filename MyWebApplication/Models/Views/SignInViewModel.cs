using MyWebApplication.Models.Forms;

namespace MyWebApplication.Models.Views;

public class SignInViewModel
{

	public SignInFormModel Form { get; set; } = new SignInFormModel();

	public string? ErrorMessage { get; set; }
}
