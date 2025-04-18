using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository : Repository<Role>
{
    
    private readonly SqlConnection _connection;
    
    public RoleRepository(SqlConnection sqlConnection) : base(sqlConnection)
    {
        _connection = sqlConnection;
    }
    
}