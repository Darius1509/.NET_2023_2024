using MediatR;

namespace ECommerceApp.Application.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
}
