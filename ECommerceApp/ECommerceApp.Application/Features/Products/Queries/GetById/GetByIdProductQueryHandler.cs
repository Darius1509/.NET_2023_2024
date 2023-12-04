using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository repository;

        public GetByIdProductQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product =  await repository.FindByIdAsync(request.Id);
            if (product.IsSuccess)
            {
                return new ProductDto
                {
                    ProductId = product.Value.ProductId,
                    ProductName = product.Value.ProductName,
                    ProductDescription = product.Value.ProductDescription,
                    ProductQuantity = product.Value.ProductQuantity,
                    ProductPrice = product.Value.ProductPrice,
                    ProductCategoryId = product.Value.ProductCategoryId
                };
            }
            return new ProductDto();
        }
    }
}
