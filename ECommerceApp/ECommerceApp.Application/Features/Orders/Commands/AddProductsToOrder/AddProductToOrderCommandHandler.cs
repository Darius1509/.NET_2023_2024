using MediatR;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommand, AddProductToOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public AddProductToOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<AddProductToOrderResponse> Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.FindByIdAsync(request.Id);

                if (order == null)
                {
                    return new AddProductToOrderResponse
                    {
                        Success = false,
                        Message = $"Order with ID {request.Id} not found"
                    };
                }

               
                
                var orderObj = Order.Create(request.Date, request.OrderStatus, request.OrderCustomerId);
                //orderObj.AttachOrder(product);

                //_orderRepository.UpdateAsync(orderObj);

                return new AddProductToOrderResponse
                {
                    Success = true,
                    Message = "Product attached to order successfully"
                };
            }
            catch (Exception ex)
            {
                // Handle exceptions accordingly
                return new AddProductToOrderResponse
                {
                    Success = false,
                    Message = $"Error attaching product to order: {ex.Message}"
                };
            }
        }
    }
}
