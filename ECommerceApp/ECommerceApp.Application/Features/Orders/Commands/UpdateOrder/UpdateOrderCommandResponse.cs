using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandResponse : BaseResponse
    {
        public UpdateOrderCommandResponse() : base()
        {

        }
        public UpdateOrderDto Order { get; set; }
    }
}
