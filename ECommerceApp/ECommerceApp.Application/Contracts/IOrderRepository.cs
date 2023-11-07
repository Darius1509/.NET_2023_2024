using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
