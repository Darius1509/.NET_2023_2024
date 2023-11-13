using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetById
{
    public record GetByIdProduct(Guid Id) : IRequest<ProductDto>;
}
