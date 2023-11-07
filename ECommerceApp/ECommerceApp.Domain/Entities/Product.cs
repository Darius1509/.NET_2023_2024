using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Product
    {
        private Product(string productName, int productQuantity, int productPrice, int productCategoryId)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            ProductCategoryId = productCategoryId;
        }

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public string? ProductDescription { get; private set; }
        public int ProductQuantity { get; private set; }
        public int ProductPrice {get; private set; }
        public int ProductCategoryId { get; private set; }

        public static Result<Product> Create(string productName, int productQuantity, int productPrice, int productCategoryId)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return Result<Product>.Failure("Product name cannot be empty");
            }
            if (productQuantity <= 0)
            {
                return Result<Product>.Failure("Product quantity cannot be less than or equal to zero");
            }
            if (productPrice <= 0)
            {
                return Result<Product>.Failure("Product price cannot be less than or equal to zero");
            }
            if (productCategoryId == 0)
            {
                return Result<Product>.Failure("Product category cannot be null");
            }
            return Result<Product>.Success(new Product(productName, productQuantity, productPrice, productCategoryId));
        }

        public void AttachDescription (string productDescription)
        {
            ProductDescription = productDescription;
        }
    }
}
