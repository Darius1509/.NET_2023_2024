using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OrderCustomerId { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        public List<Product> Products { get; set; }
    }
}
