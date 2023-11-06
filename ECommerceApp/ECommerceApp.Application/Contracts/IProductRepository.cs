using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Contracts
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
