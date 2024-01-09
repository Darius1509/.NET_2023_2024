using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderCommandResponse>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; }
    }
}
