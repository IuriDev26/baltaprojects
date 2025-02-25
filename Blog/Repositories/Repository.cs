using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<T> where T : class
{

    private readonly SqlConnection _connection;
    
    public Repository(SqlConnection sqlConnection)
    {
        _connection = sqlConnection;
    }
    
    public IEnumerable<T> GetAll()
        => _connection.GetAll<T>();
    
    public T GetById(int id)
        => _connection.Get<T>(id);
    
    public bool Update(T entity)
        => _connection.Update(entity);
    
    public bool Delete(T entity)
        => _connection.Delete(entity);

    public long Create(T entity)
        => _connection.Insert(entity);

}