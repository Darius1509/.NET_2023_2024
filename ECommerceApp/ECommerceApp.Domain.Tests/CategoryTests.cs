using ECommerceApp.Domain.Entities;
using FluentAssertions;

namespace ECommerceApp.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void When_CreateCategoryIsCalled_And_CategoryNameIsValid_Then_SuccessIsReturned()
        {
            // Arrange && Act
            var result = Category.Create("Test Category");
            // Assert
            //Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue(); 
        }

        [Fact]
        public void When_CreateCategoryIsCalled_And_CategoryNameIsNull_Then_FailureIsReturned()
        {
            // Arrange && Act
            var result = Category.Create(null);
            // Assert
            //Assert.False(result.IsSuccess);
            result.IsSuccess.Should().BeFalse();    
        }

        [Fact]
        public void When_AttachProductIsCalled_Then_ProductIsAddedToCategory()
        {
            // Arrange
            var category = Category.Create("Test Category").Value;
            var product = Product.Create("Test Product", 5, 5, Guid.NewGuid()).Value;

            // Act
            category.AttachProduct(product);

            // Assert
            category.Products.Should().NotBeNull();
            category.Products.Should().Contain(product);
        }

        [Fact]
        public void When_AttachProductIsCalled_WithNullProduct_Then_ExceptionIsThrown()
        {
            // Arrange
            var category = Category.Create("Test Category").Value;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => category.AttachProduct(null));
        }
    }
}