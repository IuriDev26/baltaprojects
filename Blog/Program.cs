

using Blog.Models;
using Blog.Repositories;
using Blog.Views;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string ConnectionString = "Server=localhost;Database=Blog;User Id=sa;Password=Iuricrbtyuio123@#;TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open(); 
            var menu = new UserView(connection);
            menu.Menu();
            connection.Open();
        }
    }
}