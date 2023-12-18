﻿namespace ECommerceApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}