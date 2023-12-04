using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
