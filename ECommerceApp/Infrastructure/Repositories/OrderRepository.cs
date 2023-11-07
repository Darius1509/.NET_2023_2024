using ECommerceApp.Application.Contracts;
using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}
