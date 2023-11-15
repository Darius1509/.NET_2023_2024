﻿namespace ECommerceApp.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
    }
}