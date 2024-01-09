namespace ECommerceApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; }
    }
}
