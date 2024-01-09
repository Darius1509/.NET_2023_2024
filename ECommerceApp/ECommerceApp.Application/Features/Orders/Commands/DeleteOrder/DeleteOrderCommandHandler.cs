using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderCommandResponse>
    {
        private readonly IOrderRepository repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteOrderCommandResponse();
            var order = await repository.DeleteAsync(request.Id);

            if (!order.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful.";

                return response;
            }

            response.Success = true;
            response.Order = new DeleteOrderDto
            {
                Id = order.Value.OrderId,
                Date = order.Value.OrderDate,
                OrderCustomerId = order.Value.OrderCustomerId,
                OrderStatus = order.Value.OrderStatus
            };

            return response;
        }
    }

}
