namespace ECommerceApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; }
    }
}
