

using ECommerceApp.Application.Features.Addresses.Commands.CreateAddress;
using ECommerceApp.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApp.Application.Persistence;
using FluentAssertions;
using NSubstitute;

namespace ECommerceApp.Application.Tests.Commands
{
    public class CreateAddressCommandHandlerTests
    {
        [Fact]
        public async Task CreateAddressCommandHandler_Success()
        {
            // Arrange
            var createAddressCommand = new CreateAddressCommand {
                StreetName = "Street",
                PostalCode = 700700,
                City = "Iasi",
                Country = "Romania"
            };
            var addressRepository = Substitute.For<IAddressRepository>();
            var handler = new CreateAddressCommandHandler(addressRepository);

            // Act
            var result = await handler.Handle(createAddressCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Address.Should().NotBeNull();
            result.Address.Id.Should().NotBeEmpty();
            result.Address.StreetName.Should().Be("Street");
        }


        [Fact]
        public async Task CreateAddressCommandHandler_Failure()
        {
            // Arrange
            var createAddressCommand = new CreateAddressCommand
            {
                StreetName = "",
                PostalCode = 700700,
                City = "Iasi",
                Country = "Romania"
            };
            var addressRepository = Substitute.For<IAddressRepository>();
            var handler = new CreateAddressCommandHandler(addressRepository);

            // Act
            var result = await handler.Handle(createAddressCommand, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationsErrors.Should().NotBeEmpty();
            result.Address.Should().BeNull();
        }
    }
}
