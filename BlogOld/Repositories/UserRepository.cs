using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository : Repository<User>
{

    private readonly SqlConnection _connection;
    
    public UserRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

    public List<User> GetUsersWithRoles()
    {
        string sql = @"
            SELECT
                [User].*,
                [Role].*
            FROM [User]
            LEFT JOIN [UserRole]
                ON [UserRole].[UserId] = [User].[Id]
            LEFT JOIN [Role]
                ON [UserRole].[RoleId] = [Role].[Id]";

        List<User> users = new();
        _connection.Query<User, Role, User>
        (
            sql,
            (user, role) =>
            {
                var userCurrent = users.FirstOrDefault( x => x.Id == user.Id );
                if (userCurrent == null)
                {
                    users.Add( user );
                    user.Roles.Add( role );
                    
                }
                else
                {
                    userCurrent.Roles.Add( role );
                }
                return user;
            }, splitOn: "Id"
            );

        return users;


    }
}