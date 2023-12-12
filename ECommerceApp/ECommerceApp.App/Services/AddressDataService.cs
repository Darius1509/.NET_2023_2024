using ECommerceApp.App.Contracts;
using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerceApp.App.Services
{
    public class AddressDataService: IAddressDataService
    {
        private const string RequestUri = "api/v1/Addresses";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public AddressDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<AddressDto>> CreateAddressAsync(AddressViewModel addressViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, addressViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<AddressDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<AddressViewModel>> GetAddressesAsync()
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
            var addresses = JsonSerializer.Deserialize<List<AddressViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return addresses!;
        }
    }
}
