
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Contexts;

public class DataContexts : IdentityDbContext<UserEntity>{
	public DataContexts(DbContextOptions<DataContexts> options) : base(options)
	{
	}

	public DbSet<AddressEntity> Addresses { get; set; }
}
