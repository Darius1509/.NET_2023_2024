using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Contracts
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
