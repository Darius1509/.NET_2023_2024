using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<DeleteOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
