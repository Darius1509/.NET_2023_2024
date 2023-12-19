using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Product
    {
        private Product(string productName, int productQuantity, int productPrice, Guid productCategoryId)
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
        public Guid ProductCategoryId { get; private set; }

        public void AttachDescription(string productDescription)
        {
            if (String.IsNullOrWhiteSpace(productDescription))
            {
                throw new ArgumentNullException(nameof(productDescription), "Product Description cannot be null");
            }
            ProductDescription = productDescription;
        }

        public static Result<Product> Create(string productName, int productQuantity, int productPrice, Guid productCategoryId)
        {
            var validation = ValidateParameters(productName, productQuantity, productPrice, productCategoryId);
            if(validation != null) { return validation; }

            return Result<Product>.Success(new Product(productName, productQuantity, productPrice, productCategoryId));
        }
        public static Result<Product> Update(Guid productId, string productName, int productQuantity, int productPrice, Guid productCategoryId)
        {
            if(productId == Guid.Empty) { return Result<Product>.Failure("Product Id cannot be empty"); }

            var validation = ValidateParameters(productName, productQuantity, productPrice, productCategoryId);
            if (validation != null) { return validation; }

            var product = new Product(productName, productQuantity, productPrice, productCategoryId)
            {
                ProductId = productId
            };

            return Result<Product>.Success(product);
        }

        private static Result<Product>? ValidateParameters(string productName, int productQuantity, int productPrice, Guid productCategoryId)
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
            if (productCategoryId == Guid.Empty)
            {
                return Result<Product>.Failure("Product category cannot be null");
            }
            return null;
        }
    }
}
