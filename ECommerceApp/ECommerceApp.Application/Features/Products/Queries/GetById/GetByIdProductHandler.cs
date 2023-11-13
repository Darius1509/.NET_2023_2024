using ECommerceApp.Application.Contracts;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProduct, ProductDto>
    {
        private readonly IProductRepository repository;

        public GetByIdProductHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProductDto> Handle(GetByIdProduct request, CancellationToken cancellationToken)
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
