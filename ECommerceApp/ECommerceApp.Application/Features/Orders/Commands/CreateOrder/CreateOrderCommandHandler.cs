using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderCommandResponse();
            var validator = new CreateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
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
                var order = Order.Create(request.Date, request.OrderStatus, request.OrderCustomerId);
                if (order.IsSuccess)
                {
                    await repository.AddAsync(order.Value);
                    response.Order = new CreateOrderDto
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
