using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerceApp.Application.Features.Categories.Queries.GetByIdCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ECommerceApp.Application.Tests.Queries
{
    public class GetByIdCategoryQueryHandlerTests
    {
        [Fact]
        public async Task Handle_CategoryExists_ReturnsCategoryDto()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var query = new GetByIdCategoryQuery(categoryId);
            var repository = Substitute.For<ICategoryRepository>();

            // Mock the repository's FindByIdAsync method to return a successful Result<Category>
            var category = Category.Create("Test Category").Value;
            category.GetType().GetProperty("CategoryId").SetValue(category, categoryId); // Set the CategoryId using reflection
            repository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Success(category)));

            var handler = new GetByIdCategoryQueryHandler(repository);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CategoryId.Should().Be(categoryId);
            result.CategoryName.Should().Be("Test Category");
        }

        [Fact]
        public async Task Handle_CategoryDoesNotExist_ReturnsNull()
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
