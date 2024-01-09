using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
    {
        private readonly IOrderRepository repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateOrderCommandResponse();
            var validator = new UpdateOrderCommandValidator();
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
                var order = Order.Update(request.Id, request.Date, request.OrderCustomerId, request.OrderStatus);
                if (order.IsSuccess)
                {
                    await repository.UpdateAsync(order.Value);
                    response.Order = new UpdateOrderDto
                    {
                        Id = order.Value.OrderId,
                        Date = order.Value.OrderDate,
                        OrderCustomerId = order.Value.OrderCustomerId,
                        OrderStatus = order.Value.OrderStatus
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationsErrors = new List<string>()
                    {
                        order.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
