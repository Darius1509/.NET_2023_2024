using MediatR;
using ECommerceApp.Application.Persistence;

namespace ECommerceApp.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository repository;

        public GetAllOrdersQueryHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
			var orders = await repository.GetAllAsync();
            var listOfOrders = new List<OrderDto>();

            foreach (var order in orders.Value)
            {
                listOfOrders.Add(new OrderDto
                {
                    Id = order.OrderId,
                    Date = order.OrderDate,
                    OrderCustomerId = order.OrderCustomerId,
                    OrderStatus = order.OrderStatus
                });
            }
            return listOfOrders;
        }
    }
}
