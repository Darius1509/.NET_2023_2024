using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
