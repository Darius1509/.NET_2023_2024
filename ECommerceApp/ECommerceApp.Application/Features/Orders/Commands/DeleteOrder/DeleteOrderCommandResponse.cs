using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandResponse : BaseResponse
    {
        public DeleteOrderCommandResponse() : base()
        {

        }
        public DeleteOrderDto Order { get; set; }
    }
}
