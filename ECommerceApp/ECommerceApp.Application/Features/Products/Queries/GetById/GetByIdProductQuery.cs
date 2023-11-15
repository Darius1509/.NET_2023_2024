using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetById
{
    public record GetByIdProductQuery(Guid Id) : IRequest<ProductDto>;
}
