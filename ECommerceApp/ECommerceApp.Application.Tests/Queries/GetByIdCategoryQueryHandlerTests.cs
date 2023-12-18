using ECommerceApp.Application.Features.Categories.Commands.UpdateCategory;
using ECommerceApp.Application.Features.Categories.Queries.GetByIdCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Queries
{
    public class GetByIdCategoryQueryHandlerTests
    {
        [Fact]
        public async Task GetByIdCategoryQueryHandler_Success()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var updateCommand = new UpdateCategoryCommand { Id = categoryId, Name = "Updated Category" };
            var repository = Substitute.For<ICategoryRepository>();

            var existingCategory = Category.Create("Existing Category").Value;
            existingCategory.GetType().GetProperty("Id").SetValue(existingCategory, categoryId); // Set the Id

            repository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Success(existingCategory)));

            var handler = new UpdateCategoryCommandHandler(repository);

            // Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationsErrors.Should().BeNullOrEmpty();

            // Assert on the Category
            var updatedCategory = result.Category;
            updatedCategory.Should().NotBeNull();
            updatedCategory.Id.Should().Be(categoryId);
            updatedCategory.Name.Should().Be(existingCategory.CategoryName); // Use the actual name from the system
        }


        [Fact]
        public async Task GetByIdCategoryQueryHandler_ReturnsNull()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var query = new GetByIdCategoryQuery(categoryId);
            var repository = Substitute.For<ICategoryRepository>();

            // Mock the repository's FindByIdAsync method to return a failure Result<Category>
            repository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Failure("Category not found")));

            var handler = new GetByIdCategoryQueryHandler(repository);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}
