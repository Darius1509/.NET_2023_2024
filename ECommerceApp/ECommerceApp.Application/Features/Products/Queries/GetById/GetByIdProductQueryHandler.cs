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
                    Id = product.Value.ProductId,
                    Name = product.Value.ProductName,
                    Description = product.Value.ProductDescription,
                    Quantity = product.Value.ProductQuantity,
                    Price = product.Value.ProductPrice,
                    ProductCategoryId = product.Value.ProductCategoryId
                };
            }
            return new ProductDto();
        }
    }
}
