using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetAll
{
    public record GetAllProductsQuery() : IRequest<List<ProductDto>>;
}
