using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.App.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}
