using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Customer
    {
        private Customer(String name, String email, String pass)
        {
            CustomerId = Guid.NewGuid();
            CustomerName = name;
            CustomerEmail = email;
            CustomerPassword = pass;
        }

        public Guid CustomerId { get; private set; }
        public String CustomerName { get; private set; }
        public String CustomerEmail { get; private set; }
        public String CustomerPassword { get; private set; }
        public List<Address>? CustomerAddresses { get; private set; }
        public List<Product>? CustomerWishlist { get; private set; }
        public List<Order>? CustomerOrders { get; private set; }

        public static Result<Customer> Create(String name, String email, String pass)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return Result<Customer>.Failure("Customer name cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(email))
            {
                return Result<Customer>.Failure("Customer email cannot be empty.");
            }

            if (String.IsNullOrWhiteSpace(pass))
            {
                return Result<Customer>.Failure("Customer password cannot be empty.");
            }

            return Result<Customer>.Success(new Customer(name, email, pass));
        }

        public void AttachAddress(Address address)
        {
            if (CustomerAddresses == null) { CustomerAddresses = new List<Address>(); }
            CustomerAddresses.Add(address);
        }

        public void AttachProduct(Product product)
        {
            if (CustomerWishlist == null) { CustomerWishlist = new List<Product>(); }
            CustomerWishlist.Add(product);
        }

        public void AttachOrder(Order order)
        {
            if (CustomerOrders == null) { CustomerOrders = new List<Order>(); }
            CustomerOrders.Add(order);
        }
    }
}
