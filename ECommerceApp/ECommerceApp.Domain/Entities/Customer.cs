using ECommerceApp.Domain.Common;
using System.Net;

namespace ECommerceApp.Domain.Entities
{
    public class Customer
    {
        private Customer(string customerName, string customerEmail, string customerPassword)
        {
            CustomerId = Guid.NewGuid();
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPassword = customerPassword;
        }

        public Guid CustomerId { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public string CustomerEmail { get; private set; } = string.Empty;
        public string CustomerPassword { get; private set; } = string.Empty;
        public List<Address>? CustomerAddresses { get; private set; }
        public List<Product>? CustomerWishlist { get; private set; }
        public List<Order>? CustomerOrders { get; private set; }

        public static Result<Customer> Create(string customerName, string customerEmail, string customerPassword)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return Result<Customer>.Failure("Customer name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                return Result<Customer>.Failure("Customer email cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customerPassword))
            {
                return Result<Customer>.Failure("Customer password cannot be empty.");
            }

            return Result<Customer>.Success(new Customer(customerName, customerEmail, customerEmail));
        }

        public void AttachAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address), "Address cannot be null");
            }
            if (CustomerAddresses == null) { CustomerAddresses = new List<Address>(); }
            CustomerAddresses.Add(address);
        }

        public void AttachProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Products cannot be null");
            }
            if (CustomerWishlist == null) { CustomerWishlist = new List<Product>(); }
            CustomerWishlist.Add(product);
        }

        public void AttachOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Address cannot be null");
            }
            if (CustomerOrders == null) { CustomerOrders = new List<Order>(); }
            CustomerOrders.Add(order);
        }
    }
}
