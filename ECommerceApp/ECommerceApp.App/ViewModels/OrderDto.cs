namespace ECommerceApp.App.ViewModels
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid OrderCustomerId { get; set; }
        public DateTime Date { get; set; }
        public string OrderStatus { get; set; }
    }
}
