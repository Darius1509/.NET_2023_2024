using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IOrderDataService
    {
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel> GetOrderByIdAsync(Guid id);
        Task<ApiResponse<OrderDto>> CreateOrderAsync(OrderViewModel orderViewModel);
        Task<ApiResponse<OrderDto>> UpdateOrderAsync(OrderViewModel orderViewModel);
    }
}
