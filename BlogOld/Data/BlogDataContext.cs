using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{

    public BlogDataContext(DbContextOptions<BlogDataContext> options):base(options)
    {
        
    }
    
}
