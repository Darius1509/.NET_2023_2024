using ECommerceApp.Application.Contracts;
using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}
