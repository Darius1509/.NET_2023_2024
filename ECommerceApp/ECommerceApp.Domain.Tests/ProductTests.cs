using ECommerceApp.Domain.Entities;
using FluentAssertions;

namespace ECommerceApp.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void When_CreateProductIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();

            // Act
            var result = Product.Create(productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_CreateProductIsCalled_WithInvalidProductName_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();

            // Act
            var result = Product.Create(productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateProductIsCalled_WithInvalidProductQuantity_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = -1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();

            // Act
            var result = Product.Create(productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateProductIsCalled_WithInvalidProductPrice_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = -1;
            var productCategoryID = Guid.NewGuid();

            // Act
            var result = Product.Create(productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_CreateProductIsCalled_WithInvalidProductCategoryID_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.Empty;

            // Act
            var result = Product.Create(productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();
            var productID = Guid.NewGuid();

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithInvalidCategoryId_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.Empty;
            var productID = Guid.NewGuid();

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithInvalidId_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();
            var productID = Guid.Empty;

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithInvalidName_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "";
            var productQuantity = 1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();
            var productID = Guid.NewGuid();

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithInvalidQuantity_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = -1;
            var productPrice = 1;
            var productCategoryID = Guid.NewGuid();
            var productID = Guid.NewGuid();

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateProductIsCalled_WithInvalidPrice_Then_FailureIsReturned()
        {
            // Arrange
            var productName = "Test";
            var productQuantity = 1;
            var productPrice = -1;
            var productCategoryID = Guid.NewGuid();
            var productID = Guid.NewGuid();

            // Act
            var result = Product.Update(productID, productName, productQuantity, productPrice, productCategoryID);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_AttachDescriptionIsCalled_Then_DescriptionIsAdded()
        {
            // Arrange
            var product = Product.Create("Test", 1, 1, Guid.NewGuid()).Value;

            // Act
            product.AttachDescription("Test Description");

            // Assert
            product.ProductDescription.Should().NotBeNull();
        }

        [Fact]
        public void When_AttachDescriptionIsCalled_WithNullDescription_Then_ExceptionIsThrown()
        {
            // Arrange
            var product = Product.Create("Test", 1, 1, Guid.NewGuid()).Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.AttachDescription(null));
        }
    }
}
