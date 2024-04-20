
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
	[Key]
	[ProtectedPersonalData]
	public string Firstname { get; set; } = null!;
	[ProtectedPersonalData]
	public string Lastname { get; set; } = null!;
	public string? ProfileImage { get; set; } = "profile-image.svg";
	public string? Bio { get; set; } = null!;
	public DateTime? Created { get; set; }
	public DateTime? Modified { get; set; }

	[ForeignKey(nameof(Id))]
	public int? AddressId { get; set; }
	public AddressEntity? Address { get; set; }
}
