namespace ECommerceApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}