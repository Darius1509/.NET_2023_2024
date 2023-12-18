using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Common;
using ECommerceApp.Domain.Entities;
using NSubstitute;

namespace ECommerceApp.Application.Tests
{
    public class RepositoryMocks
    {
        public static ICategoryRepository GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                Category.Create("House").Value,
                Category.Create("Garden").Value,
                Category.Create("School").Value
            };

            var mockCategoryRepository = Substitute.For<ICategoryRepository>();
            mockCategoryRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Category>>.Success(categories)));

            return mockCategoryRepository;
        }
    }
}
