using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using ECommerceApp.API.IntegrationTests.Base;
using ECommerceApp.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApp.Application.Features.Categories.Queries;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ECommerceApp.API.IntegrationTests.Controllers
{
    public class CategoriesControllerTests(ITestOutputHelper output) : BaseApplicationContextTests
    {
        private const string RequestUri = "/api/v1/categories";
        private readonly ITestOutputHelper output = output;

        [Fact]
        public async Task GetAllCategoriesQueryHandler_Should_Return_Successful_Response()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Act
            var response = await Client.GetAsync(RequestUri);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CategoryDto>>(responseString);
            
            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
        }
        [Fact]
        public async Task When_PostCategoryCommandHandlerIsCalledWithRightParameters_Then_TheEntityCreatedShouldBeReturned()
        {
            // Arrange
            string token = CreateToken();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var category = new CreateCategoryCommand
            {
                Name = "Test Category",
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, category);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            output.WriteLine("Response JSON:");
            output.WriteLine(responseString);

            var responseObject = JsonConvert.DeserializeObject<CreateCategoryCommandResponse>(responseString);
            responseObject.Should().NotBeNull();
            responseObject.Category.Should().NotBeNull();
            responseObject.Category.Name.Should().Be(category.Name);
        }



        [Fact]
        public async Task When_PostCategoryCommandHandlerIsCalledWithMissingToken_Then_UnauthorizedResponseShouldBeReturned()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = null;
            var category = new CreateCategoryCommand
            {
                Name = "Test Category",
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, category);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }


        [Fact]
        public async Task When_PostCategoryCommandHandlerIsCalledWithInvalidToken_Then_UnauthorizedResponseShouldBeReturned()
        {
            // Arrange
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "InvalidToken");
            var category = new CreateCategoryCommand
            {
                Name = "Test Category",
            };

            // Act
            var response = await Client.PostAsJsonAsync(RequestUri, category);

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
