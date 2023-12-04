﻿using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();
            var listOfProducts = new List<ProductDto>();

            foreach (var product in products.Value)
            {
                listOfProducts.Add(new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductQuantity = product.ProductQuantity,
                    ProductPrice = product.ProductPrice,
                    ProductCategoryId = product.ProductCategoryId
                });
            }

            return listOfProducts;
        }
    }
}
