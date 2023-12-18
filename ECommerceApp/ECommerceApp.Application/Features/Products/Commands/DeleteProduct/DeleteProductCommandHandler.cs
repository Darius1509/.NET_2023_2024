using ECommerceApp.Application.Persistence;
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
                Id = product.Value.ProductId,
                Name = product.Value.ProductName,
                Description = product.Value.ProductDescription,
                Quantity = product.Value.ProductQuantity,
                Price = product.Value.ProductPrice,
                ProductCategoryId = product.Value.ProductCategoryId
            };

            return response;
        }
    }
}
