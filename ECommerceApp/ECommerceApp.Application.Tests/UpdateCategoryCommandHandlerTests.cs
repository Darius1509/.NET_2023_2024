using ECommerceApp.Application.Features.Categories.Commands.UpdateCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Commands
{
    public class UpdateCategoryCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var updateCommand = new UpdateCategoryCommand { CategoryId = categoryId, Name = "Updated Category" };
            var repository = Substitute.For<ICategoryRepository>();

            var existingCategory = Category.Create("Existing Category").Value;
            existingCategory.GetType().GetProperty("CategoryId").SetValue(existingCategory, categoryId); // Set the CategoryId

            repository.FindByIdAsync(categoryId).Returns(Task.FromResult(Result<Category>.Success(existingCategory)));

            var handler = new UpdateCategoryCommandHandler(repository);

            // Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationsErrors.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_InvalidRequest_ReturnsValidationErrors()
        {
            // Arrange
            var updateCommand = new UpdateCategoryCommand { CategoryId = Guid.NewGuid(), Name = "" };

            // Mock the validator
            var validator = Substitute.For<IValidator<UpdateCategoryCommand>>();
            validator.ValidateAsync(updateCommand, Arg.Any<CancellationToken>()).Returns(new ValidationResult(new List<ValidationFailure>()
            {
                new ValidationFailure("Name", "Name is required")
            }));

            // Mock the repository
            var repository = Substitute.For<ICategoryRepository>();

            var handler = new UpdateCategoryCommandHandler(repository);

            // Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationsErrors.Should().NotBeNullOrEmpty();

            // Assert
            result.ValidationsErrors.Should().Contain(error => error.Contains("Name is required"));
        }
    }
}
