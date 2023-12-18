using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository repository;

        public GetAllCategoriesQueryHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
			var categories = await repository.GetAllAsync();
            var listOfCategories = new List<CategoryDto>();

            foreach (var category in categories.Value) 
            {
                listOfCategories.Add(new CategoryDto
                {
                    Id = category.CategoryId,
                    Name = category.CategoryName
                });
            }
            return listOfCategories;
        }
    }
}
