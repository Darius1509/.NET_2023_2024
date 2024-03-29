﻿using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using ECommerceApp.API.IntegrationTests.Base;
using ECommerceApp.Application.Features.Addresses.Commands.CreateAddress;
using ECommerceApp.Application.Features.Addresses.Queries;
using FluentAssertions;
using Newtonsoft.Json;

namespace ECommerceApp.API.IntegrationTests.Controllers
{
    public class AddressesControllerTests : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/addresses";

        [Fact]
        public async Task GetAllAddressesQueryHandler_Should_Return_Successful_Response()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.GetAsync(RequestUri);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<AddressDto>>(responseString);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task When_CreateAddressCommandHandlerIsCalledWithValidParameters_Then_Success()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var createAddressCommand = new CreateAddressCommand
            {
                StreetName = "Test Street",
                PostalCode = 12345,
                City = "Test City",
                Country = "Test Country"
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, createAddressCommand);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CreateAddressCommandResponse>(responseContent);

            // Assert
            result.Should().NotBeNull();            
            result.Address.Should().NotBeNull();
            result.Address.StreetName.Should().Be(createAddressCommand.StreetName);
            result.Address.PostalCode.Should().Be(createAddressCommand.PostalCode);
            result.Address.City.Should().Be(createAddressCommand.City);
            result.Address.Country.Should().Be(createAddressCommand.Country);
            
        }


        [Fact]
        public async Task When_CreateAddressCommandHandlerIsCalledWithInvalidParameters_Then_BadRequest()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var invalidCreateAddressCommand = new CreateAddressCommand
            {
                StreetName = "",
                PostalCode = 12345,
                City = "Test City",
                Country = "Test Country"
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, invalidCreateAddressCommand);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task When_CreateAddressCommandHandlerIsCalledWithoutToken_Then_Unauthorized()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = null;
            var createAddressCommand = new CreateAddressCommand
            {
                StreetName = "Test Street",
                PostalCode = 12345,
                City = "Test City",
                Country = "Test Country"
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, createAddressCommand);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task When_GetAllAddressesQueryHandlerIsCalledWithInvalidToken_Then_Unauthorized()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "InvalidToken");

            // Act
            var response = await Client.GetAsync(RequestUri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task When_GetAddressByIdQueryHandlerIsCalledWithValidParameters_Then_Success()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var createAddressCommand = new CreateAddressCommand
            {
                StreetName = "Test Street",
                PostalCode = 12345,
                City = "Test City",
                Country = "Test Country"
            };

            var responseCreate = await Client.PostAsJsonAsync("/api/v1/addresses", createAddressCommand);
            responseCreate.EnsureSuccessStatusCode();
            var createdAddress = JsonConvert.DeserializeObject<CreateAddressCommandResponse>(await responseCreate.Content.ReadAsStringAsync());

            // Act
            var responseGet = await Client.GetAsync($"/api/v1/addresses/{createdAddress.Address.Id}");
            responseGet.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<AddressDto>(await responseGet.Content.ReadAsStringAsync());

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(createdAddress.Address.Id);
            result.StreetName.Should().Be(createAddressCommand.StreetName);
            result.PostalCode.Should().Be(createAddressCommand.PostalCode);
            result.City.Should().Be(createAddressCommand.City);
            result.Country.Should().Be(createAddressCommand.Country);
        }



        [Fact]
        public async Task When_GetAllAddressesQueryHandlerIsCalledWithoutToken_Then_Unauthorized()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = null;

            // Act
            var response = await Client.GetAsync(RequestUri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        private static string CreateToken()
        {
            return JwtTokenProvider.JwtSecurityTokenHandler.WriteToken(
                new JwtSecurityToken(
                    JwtTokenProvider.Issuer,
                    JwtTokenProvider.Issuer,
                    new List<Claim> { new(ClaimTypes.Role, "User"), new("department", "Security") },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: JwtTokenProvider.SigningCredentials
                ));
        }
    }
}
