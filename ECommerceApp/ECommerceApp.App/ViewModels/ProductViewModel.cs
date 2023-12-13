using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.App.ViewModels
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int ProductPrice { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}
