using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{

    [HttpGet("getxx")]
    public List<TodoModel> Get([FromServices] AppDbContext context)
    {
        return context.Todos.ToList();
    }

    [HttpPost("post")]
    public TodoModel Post([FromServices] AppDbContext context, [FromBody] TodoModel todo)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
        return todo;
    }

}