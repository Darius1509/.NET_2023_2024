using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.App.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; } = string.Empty;
    }
}
