using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPages.Pages;

public class Index : PageModel
{
    public List<Category> Categories { get; set; } = new();
    public void OnGet()
    {
        for(int i = 1; i <= 20; i++)
        {
            Categories.Add( new Category(i, $"Category {i}", i*17));
        }
    }
}

public record Category(int Id, string Name, decimal Price);