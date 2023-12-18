using ECommerceApp.Domain.Common;

namespace ECommerceApp.Domain.Entities
{
    public class Category
    {
        private Category(Guid categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Guid CategoryId { get; private set; }
        public string CategoryName { get; private set; }
        public List<Product>? Products { get; private set; }

        public static Result<Category> Create(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return Result<Category>.Failure("Category name cannot be empty");
            }

            return Result<Category>.Success(new Category(Guid.NewGuid(), categoryName));
        }

        public void AttachProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            if (Products == null) { Products = new List<Product>(); }
            Products.Add(product);
        }
    }
}
