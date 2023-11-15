using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid productId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
