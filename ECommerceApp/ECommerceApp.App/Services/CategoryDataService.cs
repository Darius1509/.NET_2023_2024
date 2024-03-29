﻿using ECommerceApp.App.Contracts;
using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ECommerceApp.App.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private const string RequestUri = "api/v1/Categories";
        private readonly HttpClient httpClient;
        private readonly ITokenService tokenService;

        public CategoryDataService(HttpClient httpClient, ITokenService tokenService)
        {
            this.httpClient = httpClient;
            this.tokenService = tokenService;
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PostAsJsonAsync(RequestUri, categoryViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<CategoryDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
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
            var categories = JsonSerializer.Deserialize<List<CategoryViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return categories!;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(Guid id)
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
            var category = JsonSerializer.Deserialize<CategoryViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return category!;
        }

        public async Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", await tokenService.GetTokenAsync());
            var result = await httpClient.PutAsJsonAsync($"{RequestUri}/{categoryViewModel.Id}", categoryViewModel);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadFromJsonAsync<ApiResponse<CategoryDto>>();
            response!.IsSuccess = result.IsSuccessStatusCode;
            return response!;
        }
    }
}
