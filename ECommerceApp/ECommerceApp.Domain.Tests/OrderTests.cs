using ECommerceApp.Domain.Entities;
using FluentAssertions;


namespace ECommerceApp.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void When_CreateOrderIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange
            var orderDate = DateTime.Now;
            var orderStatus = "Pending";
            var orderCustomerId = Guid.NewGuid();

            // Act
            var result = Order.Create(orderDate, orderStatus, orderCustomerId);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateOrderIsCalled_WithInvalidOrderDate_Then_FailureIsReturned()
        {
            // Arrange
            var orderDate = DateTime.MinValue;
            var orderStatus = "Pending";
            var orderCustomerId = Guid.NewGuid();

            // Act
            var result = Order.Create(orderDate, orderStatus, orderCustomerId);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateOrderIsCalled_WithInvalidOrderStatus_Then_FailureIsReturned()
        {
            // Arrange
            var orderDate = DateTime.Now;
            var orderStatus = "";
            var orderCustomerId = Guid.NewGuid();

            // Act
            var result = Order.Create(orderDate, orderStatus, orderCustomerId);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateOrderIsCalled_WithInvalidOrderCustomerId_Then_FailureIsReturned()
        {
            // Arrange
            var orderDate = DateTime.Now;
            var orderStatus = "Pending";
            var orderCustomerId = Guid.Empty;

            // Act
            var result = Order.Create(orderDate, orderStatus, orderCustomerId);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }
        [Fact]
        public void When_AttachProductIsCalled_Then_ProductIsAddedToOrder()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;
            var product = Product.Create("Test Product", 5, 5, Guid.NewGuid()).Value;

            // Act
            order.AttachProduct(product);

            // Assert
            order.OrderProducts.Should().NotBeNull();
            order.OrderProducts.Should().Contain(product);
        }

        [Fact]
        public void When_AttachProductIsCalled_WithNullProduct_Then_ExceptionIsThrown()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => order.AttachProduct(null));
        }

        [Fact]
        public void When_RemoveProductIsCalled_Then_ProductIsRemovedFromOrder()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;
            var product = Product.Create("Test Product", 5, 5, Guid.NewGuid()).Value;
            order.AttachProduct(product);

            // Act
            order.RemoveProduct(product);

            // Assert
            order.OrderProducts.Should().NotBeNull();
            order.OrderProducts.Should().NotContain(product);
        }
        [Fact]
        public void When_RemoveProductIsCalled_WithNullProduct_Then_ExceptionIsThrown()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => order.RemoveProduct(null));
        }

        [Fact]
        public void When_UpdateStatusIsCalled_Then_OrderStatusIsUpdated()
        {
            // Arrange
            var order = Order.Create(DateTime.Now, "Pending", Guid.NewGuid()).Value;
            var newStatus = "Shipped";

            // Act
            order.UpdateStatus(newStatus);

            // Assert
            order.OrderStatus.Should().Be(newStatus);
        }

    }
}
