using System.Diagnostics.CodeAnalysis;
using System.Text;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Views;

public class UserView : View
{
    
    private readonly UserRepository _userRepository;
    private readonly RoleRepository _roleRepository;
    
    public UserView(SqlConnection sqlConnection)
    {
        _userRepository = new UserRepository(sqlConnection);
        _roleRepository = new RoleRepository(sqlConnection);
    }
    
    
    public void Menu()
    {
        bool isActive = true;
        while (isActive)
        {
            Console.Clear();
            
            var menu = new StringBuilder();

            menu.AppendLine(new string('-', Console.WindowWidth));
            menu.AppendLine("\nUser Menu\n");
            menu.AppendLine(new string('-', Console.WindowWidth));
            menu.AppendLine("\n1 - Create New User");
            menu.AppendLine("2 - Delete User By ID");
            menu.AppendLine("3 - List all Users");
            menu.AppendLine("4 - Associate User To Role");
            menu.AppendLine("5 - Exit\n");
            menu.AppendLine(new string('-', Console.WindowWidth));
            Console.WriteLine(menu.ToString());
            Console.Write("Type your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateNewUser(); break;
                case "2": DeleteUserById(); break;
                case "3": ListAllUsers(); break;
                case "4": AssociateUserToRole(); break;
                case "5": isActive = false; break;
                default: 
                    Console.WriteLine("Invalid choice. Type any key to continue."); 
                    Thread.Sleep(1000);
                    break;
            }
            
        }
        
    }

    private void CreateNewUser()
    {
        string[] requestsForUser = new string[]
        {
            "Full Name",
            "Email Address",
            "Password",
            "Bio",
            "Username",
        };

        var userData = new List<string>();

        foreach (var request in requestsForUser)
        {
            Console.Clear();
            Console.WriteLine(WriteHeaderText("User Registration"));
            Console.WriteLine(request);
            var data = Console.ReadLine();

            if (data is not null)
                userData.Add(data);
        }

        User user = new User()
        {
            Name = userData[0],
            Email = userData[1],
            PasswordHash = userData[2],
            Bio = userData[3],
            Slug = userData[4],
            Image = ""
        };
        
        _userRepository.Create(user);
        
    }

    private void DeleteUserById()
    {
        
        Console.Clear();
        Console.WriteLine(WriteHeaderText("User Deletion"));
        Console.Write("Insert the Id from the user that will be deleted:");
        int.TryParse(Console.ReadLine(), out int id);
        
        var user = _userRepository.GetById(id);
        _userRepository.Delete(user);

    }

    private void ListAllUsers()
    {
        var users = _userRepository.GetAll();
        
        Console.Clear();
        Console.WriteLine(WriteHeaderText("All Users"));

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name}, {user.Email}, {user.PasswordHash}, {user.Bio}");
        }
        
        Console.ReadKey();
        
    }

    private void AssociateUserToRole()
    {
        Console.Clear();
        Console.WriteLine(WriteHeaderText("User Association To Role"));
        Console.Write("Insert the user you would like to associate to a role: ");
        int.TryParse(Console.ReadLine(), out int userId);
        Console.Write("Insert the role you would like to associate to a user: ");
        int.TryParse(Console.ReadLine(), out int roleId);

        var user = _userRepository.GetById(userId);
        var role = _roleRepository.GetById(roleId);
        user.Roles.Add(role);
        _userRepository.Update(user);
    }
    
}