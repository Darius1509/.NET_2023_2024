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

        public static Result<Category> Update(Guid categoryId, string categoryName)
        {
            if (categoryId == Guid.Empty)
            {
                return Result<Category>.Failure("Category Id cannot be empty");
            }
            if (string.IsNullOrEmpty(categoryName))
            {
                return Result<Category>.Failure("Category name cannot be empty");
            }

            var category = new Category(categoryId, categoryName);

            return Result<Category>.Success(category);
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
