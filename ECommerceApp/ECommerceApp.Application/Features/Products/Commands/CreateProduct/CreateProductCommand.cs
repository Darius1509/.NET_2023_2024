using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCategoryId { get; set;}
    }
}
