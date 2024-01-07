using MediatR;

namespace ECommerceApp.Application.Features.Orders.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IRequest<List<OrderDto>>;
}
