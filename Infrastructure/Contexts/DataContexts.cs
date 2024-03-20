
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Contexts;

public class DataContexts(DbContextOptions<DataContexts> options) : DbContext(options)
{
	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<UserEntity> Users { get; set; }

}
