using ECommerceApp.App.Contracts;
using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerceApp.App.Services
{
    public class OrderDataService : IOrderDataService
    {
        private const string RequestUri = "api/v1/Orders";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public OrderDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<OrderDto>> CreateOrderAsync(OrderViewModel orderViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, orderViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<OrderDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<OrderViewModel> GetOrderByIdAsync(Guid id)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.GetAsync($"{RequestUri}/{id}", HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var order = JsonSerializer.Deserialize<OrderViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return order!;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.GetAsync(RequestUri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var orders = JsonSerializer.Deserialize<List<OrderViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return orders!;
        }

        public async Task<ApiResponse<OrderDto>> UpdateOrderAsync(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
