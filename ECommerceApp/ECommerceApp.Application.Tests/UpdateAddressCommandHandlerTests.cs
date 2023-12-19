using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentValidation.Results;
using FluentValidation;
using NSubstitute;
using ECommerceApp.Application.Features.Addresses.Commands.UpdateAddress;
using FluentAssertions;

namespace ECommerceApp.Application.Tests.Commands
{
    public class UpdateAddressCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var updateCommand = new UpdateAddressCommand 
            { 
                Id = addressId, 
                StreetName = "Street",
                PostalCode = 700700,
                City = "Iasi",
                Country = "Romania"
            };
            var repository = Substitute.For<IAddressRepository>();

            var existingAddress = Address.Create("Existing Address", 700700, "Iasi", "Romania").Value;
            existingAddress.GetType().GetProperty("AddressId").SetValue(existingAddress, addressId); // Set the Id

            repository.FindByIdAsync(addressId).Returns(Task.FromResult(Result<Address>.Success(existingAddress)));

            var handler = new UpdateAddressCommandHandler(repository);

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
            var updateCommand = new UpdateAddressCommand 
            { 
                Id = Guid.NewGuid(), 
                StreetName = null,
                PostalCode = 700700,
                City = "Iasi",
                Country = "Romania"
            };

            // Mock the validator
            var validator = Substitute.For<IValidator<UpdateAddressCommand>>();
            validator.ValidateAsync(updateCommand, Arg.Any<CancellationToken>()).Returns(new ValidationResult(new List<ValidationFailure>()
            {
                new ValidationFailure("StreetName", "Street Name is required")
            }));

            // Mock the repository
            var repository = Substitute.For<IAddressRepository>();

            var handler = new UpdateAddressCommandHandler(repository);

            // Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationsErrors.Should().NotBeNullOrEmpty();

            // Assert
            result.ValidationsErrors.Should().Contain(error => error.Contains("Street Name is required"));
        }
    }
}
