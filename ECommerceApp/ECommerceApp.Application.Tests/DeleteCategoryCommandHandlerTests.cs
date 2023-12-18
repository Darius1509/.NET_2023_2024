using ECommerceApp.Application.Features.Categories.Commands.DeleteCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Commands
{
    public class DeleteCategoryCommandHandlerTests
    {
        [Fact]
        public async Task DeleteCategoryCommandHandler_Success()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var command = new DeleteCategoryCommand { CategoryId = categoryId };
            var repository = Substitute.For<ICategoryRepository>();

            // Mock the repository's FindByIdAsync method to return a successful Result<Category>
            var category = Category.Create("Test Category").Value;
            category.GetType().GetProperty("CategoryId").SetValue(category, categoryId);
            repository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Success(category)));

            var handler = new DeleteCategoryCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().BeNull();
            result.Category.Should().NotBeNull();
            result.Category.CategoryId.Should().Be(categoryId);
            result.Category.CategoryName.Should().Be("Test Category");
        }

        [Fact]
        public async Task DeleteCategoryCommandHandler_Failure()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var deleteCategoryCommand = new DeleteCategoryCommand { CategoryId = categoryId };
            var categoryRepository = Substitute.For<ICategoryRepository>();
            var handler = new DeleteCategoryCommandHandler(categoryRepository);

            // Mock the repository's FindByIdAsync method to return a failure Result<Category>
            categoryRepository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Failure("Category not found")));

            // Act
            var result = await handler.Handle(deleteCategoryCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be("Category was not deleted successfully");
            result.Category.Should().BeNull();
        }
    }
}
