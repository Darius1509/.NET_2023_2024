using ECommerceApp.Application.Contracts;
using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}
