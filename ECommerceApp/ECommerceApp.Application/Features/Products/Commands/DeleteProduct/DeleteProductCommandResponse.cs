using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandResponse : BaseResponse
    {
        public DeleteProductCommandResponse() : base()
        {

        }
        public DeleteProductDto Product { get; set; }
    }
}
