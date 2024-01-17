using ECommerceApp.Application.Features.Categories.Queries.GetAllCategories;
using ECommerceApp.Application.Persistence;
using FluentAssertions;

namespace ECommerceApp.Application.Tests.Queries
{
    public class GetAllCategoriesQueryHandlerTests : IDisposable
    {

        private readonly ICategoryRepository _mockCategoryRepository;

        public GetAllCategoriesQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        }

        [Fact]
        public async Task GetAllCategoriesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCategoriesQueryHandler(_mockCategoryRepository);

            // Act
            var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3); // assuming result is List<CategoryDto>
        }

        public void Dispose()
        {
        }
    }
}
