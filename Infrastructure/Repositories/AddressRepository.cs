
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
	private readonly DataContexts _context;
	public AddressRepository(DataContexts context) : base(context)
	{
		_context = context;
	}


}