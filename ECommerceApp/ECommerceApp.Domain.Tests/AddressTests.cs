using ECommerceApp.Domain.Entities;
using FluentAssertions;

namespace ECommerceApp.Domain.Tests
{
    public class AddressTests
    {
        [Fact]
        public void When_CreateAddressIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange
            var streetName = "Main Street";
            var postalCode = 12345;
            var city = "City";
            var country = "Country";

            // Act
            var result = Address.Create(streetName, postalCode, city, country);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.AddressId.Should().NotBeEmpty();
            result.Value.StreetName.Should().Be(streetName);
            result.Value.PostalCode.Should().Be(postalCode);
            result.Value.City.Should().Be(city);
            result.Value.Country.Should().Be(country);
        }

        [Theory]
        [InlineData("", 12345, "City", "Country")]
        [InlineData("Main Street", 0, "City", "Country")]
        [InlineData("Main Street", 12345, "", "Country")]
        [InlineData("Main Street", 12345, "City", "")]
        public void When_CreateAddressIsCalled_WithInvalidParameters_Then_FailureIsReturned(
            string streetName, int postalCode, string city, string country)
        {
            // Act
            var result = Address.Create(streetName, postalCode, city, country);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateAddressIsCalled_WithValidParameters_Then_SuccessIsReturned()
        {
            // Arrange
            var addressId = Guid.NewGuid();
            var streetName = "Updated Street";
            var postalCode = 54321;
            var city = "Updated City";
            var country = "Updated Country";

            // Act
            var result = Address.Update(addressId, streetName, postalCode, city, country);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.AddressId.Should().Be(addressId);
            result.Value.StreetName.Should().Be(streetName);
            result.Value.PostalCode.Should().Be(postalCode);
            result.Value.City.Should().Be(city);
            result.Value.Country.Should().Be(country);
        }

        [Theory]
        [InlineData("", 54321, "Updated City", "Updated Country")]
        [InlineData("Updated Street", 0, "Updated City", "Updated Country")]
        [InlineData("Updated Street", 54321, "", "Updated Country")]
        [InlineData("Updated Street", 54321, "Updated City", "")]
        public void When_UpdateAddressIsCalled_WithInvalidParameters_Then_FailureIsReturned(
            string streetName, int postalCode, string city, string country)
        {
            // Arrange
            var addressId = Guid.NewGuid();

            // Act
            var result = Address.Update(addressId, streetName, postalCode, city, country);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void When_UpdateAddressIsCalled_WithEmptyAddressId_Then_FailureIsReturned()
        {
            // Arrange
            var streetName = "Updated Street";
            var postalCode = 54321;
            var city = "Updated City";
            var country = "Updated Country";

            // Act
            var result = Address.Update(Guid.Empty, streetName, postalCode, city, country);

            // Assert
            result.IsSuccess.Should().BeFalse();
        }
    }
}
