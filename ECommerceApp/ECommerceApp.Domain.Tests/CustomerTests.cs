using ECommerceApp.Domain.Entities;
using FluentAssertions;

namespace ECommerceApp.Domain.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void When_CreateCustomerIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange & Act
            var result = Customer.Create("Customer Test", "customer@email.com", "12345678");

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateCustomerIsCalled_WithInvalidName_Then_FailureIsReturned()
        {
            // Arrange & Act
            var result = Customer.Create("", "customer@email.com", "12345678");

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateCustomerIsCalled_WithInvalidEmail_Then_FailureIsReturned()
        {
            // Arrange & Act
            var result = Customer.Create("Customer Test", "", "12345678");

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateCustomerIsCalled_WithInvalidPassword_Then_FailureIsReturned()
        {
            // Arrange & Act
            var result = Customer.Create("Customer Test", "customer@email.com", "");

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_AttachAddressIsCalled_Then_AddressIsAdded()
        {
            // Arrange
            var address = Address.Create("Street", 700700, "Iasi", "Romania").Value;
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act
            customer.AttachAddress(address);

            // Assert
            customer.CustomerAddresses.Should().NotBeNull();
            customer.CustomerAddresses.Should().Contain(address);
        }

        [Fact]
        public void When_AttachAddressIsCalled_WithNullAddress_Then_ExceptionIsThrown()
        {
            // Arrange
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.AttachAddress(null));
        }

        [Fact]
        public void When_AttachProductIsCalled_Then_ProductIsAdded()
        {
            // Arrange
            var product = Product.Create("Product Name", 1, 1, Guid.NewGuid()).Value;
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act
            customer.AttachProduct(product);

            // Assert
            customer.CustomerWishlist.Should().NotBeNull();
            customer.CustomerWishlist.Should().Contain(product);
        }

        [Fact]
        public void When_AttachProductIsCalled_WithNullProduct_Then_ExceptionIsThrown()
        {
            // Arrange
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.AttachProduct(null));
        }

        [Fact]
        public void When_AttachOrderIsCalled_Then_OrderIsAdded()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act
            customer.AttachOrder(order);

            // Assert
            customer.CustomerOrders.Should().NotBeNull();
            customer.CustomerOrders.Should().Contain(order);
        }

        [Fact]
        public void When_AttachOrderIsCalled_WithNullOrder_Then_ExceptionIsThrown()
        {
            // Arrange
            var customer = Customer.Create("Customer Test", "customer@email.com", "12345678").Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.AttachOrder(null));
        }
    }
}
