
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class UserEntity
{
	[Key]
	public string Id { get; set; } = null!;
	public string Firstname { get; set; } = null!;
	public string Lastname { get; set; } = null!;
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string SecurityKey { get; set; } = null!;
	public string? Phone { get; set; } = null!;
	public string? Bio { get; set; } = null!;
	public DateTime? Created { get; set; }
	public DateTime? Modified { get; set; }

	[ForeignKey(nameof(Id))]
	public int? AddressId { get; set; }
	public AddressEntity? Address { get; set; }
}
