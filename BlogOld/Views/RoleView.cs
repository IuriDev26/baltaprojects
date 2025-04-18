
using System.Text;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Views;

public class RoleView : View
{
    private readonly RoleRepository _roleRepository;

    public RoleView(SqlConnection connection)
    {
        _roleRepository = new RoleRepository(connection);
    }
    
    public void Menu()
    {
        bool isActive = true;
        while (isActive)
        {
            Console.Clear();
            
            var menu = new StringBuilder();

            menu.AppendLine(new string('-', Console.WindowWidth));
            menu.AppendLine("\nRole Menu\n");
            menu.AppendLine(new string('-', Console.WindowWidth));
            menu.AppendLine("\n1 - Create New Role");
            menu.AppendLine("2 - Delete Role By ID");
            menu.AppendLine("3 - List all Roles");
            menu.AppendLine("4 - Exit\n");
            menu.AppendLine(new string('-', Console.WindowWidth));
            Console.WriteLine(menu.ToString());
            Console.Write("Type your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateNewRole(); break;
                case "2": DeleteRoleById(); break;
                case "3": ListAllRoles(); break;
                case "4": isActive = false; break;
                default: 
                    Console.WriteLine("Invalid choice. Type any key to continue."); 
                    Thread.Sleep(1000);
                    break;
            }
            
        }
        
    }

    private void CreateNewRole()
    {
        string[] requestsForUser = new string[]
        {
            "Role Name",
            "Slug"
        };

        var roleData = new List<string>();

        foreach (var request in requestsForUser)
        {
            Console.Clear();
            Console.WriteLine(WriteHeaderText("Role Registration"));
            Console.WriteLine(request);
            var data = Console.ReadLine();

            if (data is not null)
                roleData.Add(data);
        }

        Role role = new Role()
        {
            Name = roleData[0],
            Slug = roleData[1],
        };
        
        _roleRepository.Create(role);
        
    }

    private void DeleteRoleById()
    {
        
        Console.Clear();
        Console.WriteLine(WriteHeaderText("Role Deletion"));
        Console.Write("Insert the Id from the role that will be deleted:");
        int.TryParse(Console.ReadLine(), out int id);
        
        var user = _roleRepository.GetById(id);
        _roleRepository.Delete(user);

    }

    private void ListAllRoles()
    {
        var roles = _roleRepository.GetAll();
        
        Console.Clear();
        Console.WriteLine(WriteHeaderText("All Users"));

        foreach (var role in roles)
        {
            Console.WriteLine($"{role.Id} - {role.Name}, {role.Slug}");
        }
        
        Console.ReadKey();
        
    }
}