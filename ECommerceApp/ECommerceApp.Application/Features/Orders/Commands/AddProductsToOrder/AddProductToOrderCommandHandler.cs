using MediatR;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommand, AddProductToOrderResponse>
    {
        private readonly IOrderRepository repository;

        public AddProductToOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddProductToOrderResponse> Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
        {
			//create a new order and assign a empty list of products to it
            var response = new AddProductToOrderResponse();
            var validator = new AddProductToOrderCommandValidator();
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
                    response.Order = new AddProductToOrderDto
                    {
                        Id = order.Value.OrderId,
                        Date = order.Value.OrderDate,
                        OrderCustomerId = order.Value.OrderCustomerId,
                        OrderStatus = order.Value.OrderStatus,
                        Products = new List<Product>()
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
