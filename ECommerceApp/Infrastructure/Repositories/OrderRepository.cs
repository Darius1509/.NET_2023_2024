using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, ECommerceApp.Application.Persistence.IOrderRepository
    {
        public OrderRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}
