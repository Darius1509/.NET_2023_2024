using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
