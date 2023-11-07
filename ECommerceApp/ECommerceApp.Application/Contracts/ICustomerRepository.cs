using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Contracts
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
