using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Category Name is required")]
    public string Title { get; set; } = string.Empty;
}