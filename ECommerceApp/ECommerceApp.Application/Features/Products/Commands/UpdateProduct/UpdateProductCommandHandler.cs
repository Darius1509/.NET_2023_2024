using ECommerceApp.Application.Contracts;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductRepository repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            this.repository = repository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateProductCommandResponse();
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationsErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationsErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var product = Product.Update(request.productId,request.ProductName, request.ProductQuantity, request.ProductPrice, request.ProductCategoryId);
                if (product.IsSuccess)
                {
                    await repository.UpdateAsync(product.Value);
                    response.Product = new UpdateProductDto
                    {
                        ProductId = product.Value.ProductId,
                        ProductName = product.Value.ProductName,
                        ProductDescription = product.Value.ProductDescription,
                        ProductQuantity = product.Value.ProductQuantity,
                        ProductPrice = product.Value.ProductPrice,
                        ProductCategoryId = product.Value.ProductCategoryId
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationsErrors = new List<string>()
                    {
                        product.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
