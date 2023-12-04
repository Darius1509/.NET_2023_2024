using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateProductCommandResponse();
            var validator = new CreateProductCommandValidator();
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
                var product = Product.Create(request.ProductName, request.ProductQuantity, request.ProductPrice, request.ProductCategoryId);
                if (product.IsSuccess)
                {
                    await repository.AddAsync(product.Value);
                    response.Product = new CreateProductDto
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
