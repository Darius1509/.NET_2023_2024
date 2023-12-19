

using ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress;
using ECommerceApp.Application.Features.Categories.Commands.DeleteCategory;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using FluentAssertions;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Commands
{
    public class DeleteAddressCommandHandlerTests
    {
        [Fact]
        public async Task DeleteAddressCommandHandler_Success()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var command = new DeleteAddressCommand { Id = addressId };
            var repository = Substitute.For<IAddressRepository>();

            // Mock the repository's FindByIdAsync method to return a successful Result<Address>
            var address = Address.Create("Street", 700700, "Iasi", "Romania").Value;
            address.GetType().GetProperty("AddressId").SetValue(address, addressId);
            repository.FindByIdAsync(addressId).Returns(Task.FromResult(Result<Address>.Success(address)));

            var handler = new DeleteAddressCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().BeNull();
            result.Address.Should().NotBeNull();
            result.Address.Id.Should().Be(addressId);
            result.Address.StreetName.Should().Be("Street");
        }

        [Fact]
        public async Task DeleteAddressCommandHandler_Failure()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var command = new DeleteAddressCommand { Id = addressId };
            var repository = Substitute.For<IAddressRepository>();
            var handler = new DeleteAddressCommandHandler(repository);

            // Mock the repository's FindByIdAsync method to return a failure Result<Category>
            repository.FindByIdAsync(addressId).Returns(Task.FromResult(Result<Address>.Failure("Address not found")));

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be("Deletion was unsuccessful.");
            result.Address.Should().BeNull();
        }
    }
}
