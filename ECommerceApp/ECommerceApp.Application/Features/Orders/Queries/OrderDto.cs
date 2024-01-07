namespace ECommerceApp.Application.Features.Orders.Queries
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; }
    }
}
