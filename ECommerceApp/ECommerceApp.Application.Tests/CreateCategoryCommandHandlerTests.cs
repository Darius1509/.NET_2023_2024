using ECommerceApp.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        [Fact]
        public async Task CreateCategoryCommandHandler_Success()
        {
            // Arrange
            var categoryName = "Test Category";
            var createCategoryCommand = new CreateCategoryCommand { Name = categoryName };
            var categoryRepository = Substitute.For<ICategoryRepository>();
            var handler = new CreateCategoryCommandHandler(categoryRepository);

            // Act
            var result = await handler.Handle(createCategoryCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Category.Should().NotBeNull();
            result.Category.Id.Should().NotBeEmpty();
            result.Category.CategoryName.Should().Be(categoryName);
        }


        [Fact]
        public async Task CreateCategoryCommandHandler_Failure()
        {
            // Arrange
            var invalidCategoryName = ""; // Empty name will trigger validation failure
            var createCategoryCommand = new CreateCategoryCommand { Name = invalidCategoryName };
            var categoryRepository = Substitute.For<ICategoryRepository>();
            var handler = new CreateCategoryCommandHandler(categoryRepository);

            // Act
            var result = await handler.Handle(createCategoryCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationsErrors.Should().NotBeEmpty();
            result.Category.Should().BeNull();
        }
    }
}
