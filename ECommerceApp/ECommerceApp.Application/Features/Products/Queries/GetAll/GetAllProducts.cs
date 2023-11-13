using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetAll
{
    public record GetAllProducts() : IRequest<List<ProductDto>>;
}
