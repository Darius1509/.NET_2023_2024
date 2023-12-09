using MediatR;

namespace ECommerceApp.Application.Features.Categories.Queries.GetByIdCategory
{
    public record GetByIdCategoryQuery(Guid id) : IRequest<CategoryDto>;
}
