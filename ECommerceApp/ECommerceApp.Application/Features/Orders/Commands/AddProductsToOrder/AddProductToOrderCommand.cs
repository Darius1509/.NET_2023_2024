using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommand : IRequest<AddProductToOrderResponse>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; }
    }
}
