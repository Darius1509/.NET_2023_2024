using MediatR;
using ECommerceApp.Application.Persistence;

namespace ECommerceApp.Application.Features.Orders.Queries.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, OrderDto>
    {
        private readonly IOrderRepository repository;

        public GetByIdOrderQueryHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OrderDto> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await repository.FindByIdAsync(request.id);
            if (order.IsSuccess)
            {
                return new OrderDto
                {
                    Id = order.Value.OrderId,
                    Date = order.Value.OrderDate,
                    OrderCustomerId = order.Value.OrderCustomerId,
                    OrderStatus = order.Value.OrderStatus
                };
            }
            else
            {
                return null;
            }
        }
    }
}
