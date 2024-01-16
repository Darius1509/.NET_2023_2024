using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderResponse : BaseResponse
    {
        public AddProductToOrderResponse() : base()
        {
        }

        public AddProductToOrderDto Order { get; set; }
    }
}
