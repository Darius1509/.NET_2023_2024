
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IProductRepository repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductCommandResponse();
            var product = await repository.DeleteAsync(request.Id);

            if(!product.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful.";

                return response;
            }

            response.Success = true;
            response.Product = new DeleteProductDto
            {
                ProductId = product.Value.ProductId,
                ProductName = product.Value.ProductName,
                ProductDescription = product.Value.ProductDescription,
                ProductQuantity = product.Value.ProductQuantity,
                ProductPrice = product.Value.ProductPrice,
                ProductCategoryId = product.Value.ProductCategoryId
            };

            return response;
        }
    }
}
