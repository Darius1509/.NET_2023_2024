using MediatR;
using ECommerceApp.Application.Persistence;

namespace ECommerceApp.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
    {
        private readonly ICategoryRepository repository;

        public GetByIdCategoryQueryHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
			var category = await repository.FindByIdAsync(request.id);
            if(category.IsSuccess)
            {
                return new CategoryDto
                {
                    CategoryId = category.Value.CategoryId,
                    CategoryName = category.Value.CategoryName
                };
            }
            else
            {
                return null;
            }
        }
    }
}
