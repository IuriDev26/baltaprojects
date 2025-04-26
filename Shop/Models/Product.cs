using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Shop.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Descrição não pode ser vazia")]
    public string  Description { get; set; } = string.Empty;
    
    [Range(1, 9999, ErrorMessage = "Preço do produto deve estar entre 1 e 9999")]
    public decimal Price { get; set; }
    public Category Category { get; set; }
    
    [Required(ErrorMessage = "Categoria não pode ser vazia")]
    public int CategoryId { get; set; }
}