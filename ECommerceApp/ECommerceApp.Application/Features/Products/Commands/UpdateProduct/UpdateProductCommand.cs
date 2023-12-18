using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int quantity { get; set; }
        public int price { get; set; }
        public Guid productCategoryId { get; set; }
    }
}
