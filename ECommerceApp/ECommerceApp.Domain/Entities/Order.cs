using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Order
    {
        private Order(DateTime orderDate, string orderStatus, Guid orderCustomerId)
        {
            OrderId = Guid.NewGuid();
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            OrderCustomerId = orderCustomerId;
        }

        public Guid OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderStatus { get; private set; }
        public List<Product> OrderProducts { get; private set; } = new List<Product>();
        public Guid OrderCustomerId { get; private set; }

        public static Result<Order> Create(DateTime orderDate, string orderStatus, Guid orderCustomerId)
        {
            if (orderDate == DateTime.MinValue)
            {
                return Result<Order>.Failure("Order date cannot be empty");
            }
            if (string.IsNullOrEmpty(orderStatus))
            {
                return Result<Order>.Failure("Order status cannot be empty");
            }
            if (orderCustomerId == Guid.Empty)
            {
                return Result<Order>.Failure("Order customer cannot be null");
            }

            return Result<Order>.Success(new Order(orderDate, orderStatus, orderCustomerId));
        }

        public void AttachProduct(Product product)
        {
            OrderProducts.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            OrderProducts.Remove(product);
        }

        public void UpdateStatus(string status)
        {
            OrderStatus = status;
        }
    }
}
