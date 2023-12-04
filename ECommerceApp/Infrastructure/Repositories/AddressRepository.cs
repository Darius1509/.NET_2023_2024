using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}
