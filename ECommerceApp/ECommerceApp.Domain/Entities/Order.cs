using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Order
    {
        private Order(DateTime orderDate, string orderStatus, List<Product> orderProducts, Customer orderCustomer)
        {
            OrderId = Guid.NewGuid();
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            OrderProducts = orderProducts;
            OrderCustomer = orderCustomer;
        }

        public Guid OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderStatus { get; private set; }
        public List<Product> OrderProducts { get; private set; }
        public Customer OrderCustomer { get; private set; }

        public static Result<Order> Create(DateTime orderDate, string orderStatus, Customer orderCustomer)
        {
            if (orderDate == DateTime.MinValue)
            {
                return Result<Order>.Failure("Order date cannot be empty");
            }
            if (string.IsNullOrEmpty(orderStatus))
            {
                return Result<Order>.Failure("Order status cannot be empty");
            }
            if (orderCustomer == null)
            {
                return Result<Order>.Failure("Order customer cannot be null");
            }

            List<Product> orderProducts = new List<Product>();

            return Result<Order>.Success(new Order(orderDate, orderStatus, orderProducts, orderCustomer));
        }

        public void AttachProduct(Product product)
        {
            if(OrderProducts == null) { OrderProducts = new List<Product>(); }
            OrderProducts.Add(product);
        }

        public void UpdateStatus(string status)
        {
            OrderStatus = status;
        }
    }
}
