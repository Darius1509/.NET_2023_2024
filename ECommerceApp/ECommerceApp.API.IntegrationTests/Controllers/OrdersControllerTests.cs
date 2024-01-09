using FluentAssertions;
using ECommerceApp.API.IntegrationTests.Base;
using ECommerceApp.Application.Features.Orders.Commands.CreateOrder;
using Newtonsoft.Json;
using System.Net.Http.Json;
using ECommerceApp.Application.Features.Orders.Queries;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net;
using Xunit.Abstractions;

namespace ECommerceApp.API.IntegrationTests.Controllers
{
    public class OrdersControllerTests : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/orders";

        [Fact]
        public async Task GetAllOrdersQueryHandler_Should_Return_Successful_Response()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.GetAsync(RequestUri);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OrderDto>>(responseString);

            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }

        [Fact]
        public async Task When_CreateOrderCommandHandlerIsCalledWithValidParameters_Then_Success()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var createOrderCommand = new CreateOrderCommand
            {
                Date = DateTime.Now,
                OrderCustomerId = Guid.NewGuid(),
                OrderStatus = "Pending"
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, createOrderCommand);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CreateOrderCommandResponse>(responseString);

            result.Should().NotBeNull();           
            result.Order.Should().NotBeNull();
            result.Order.Date.Should().Be(createOrderCommand.Date);
            result.Order.OrderCustomerId.Should().Be(createOrderCommand.OrderCustomerId);
            result.Order.OrderStatus.Should().Be(createOrderCommand.OrderStatus);
            
        }



        [Fact]
        public async Task When_CreateOrderCommandHandlerIsCalledWithoutToken_Then_Unauthorized()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = null;
            var createOrderCommand = new CreateOrderCommand
            {
                Date = DateTime.Now,
                OrderCustomerId = Guid.NewGuid(),
                OrderStatus = "Pending"
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, createOrderCommand);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task When_GetAllOrdersQueryHandlerIsCalledWithInvalidToken_Then_Unauthorized()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "InvalidToken");

            // Act
            var response = await Client.GetAsync(RequestUri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task When_GetAllOrdersQueryHandlerIsCalledWithoutToken_Then_Unauthorized()
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
