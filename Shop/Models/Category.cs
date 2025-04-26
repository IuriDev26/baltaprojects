using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Nome da categoria não pode ser vazio.")]
    public string Name { get; set; } = string.Empty;
    
    public List<Product> Products { get; set; } = new();
}