using ECommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Products == null) { Products = new List<Product>(); }
            Products.Add(product);
        }
    }
}
