using MediatR;

namespace ECommerceApp.Application.Features.Orders.Queries.GetByIdOrder
{
    public record GetByIdOrderQuery(Guid id) : IRequest<OrderDto>;
}
