using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
