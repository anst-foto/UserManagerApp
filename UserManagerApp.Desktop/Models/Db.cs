using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace UserManagerApp.Desktop.Models;

public class Db
{
    private readonly NpgsqlConnection _connection;

    public Db()
    {
        var connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection");
        _connection = new NpgsqlConnection(connectionString);
    }

    public IEnumerable<User>? GetAll()
    {
        _connection.Open();

        var sql = "SELECT * FROM table_users";
        var command = new NpgsqlCommand(sql, _connection);
        var reader = command.ExecuteReader();
        if (!reader.HasRows) return null;

        var users = new List<User>();
        while (reader.Read())
        {
            var id = reader.GetGuid("id");
            var lastName = reader.GetString("last_name");
            var firstName = reader.GetString("first_name");
            
            users.Add(new User(id, lastName, firstName));
        }
        
        _connection.Close();
        
        return users;
    }

    public void Add(User user)
    {
        _connection.Open();

        var sql = $"""
                   INSERT INTO table_users (id, last_name, first_name)
                   VALUES ('{user.Id}', '{user.LastName}', '{user.FirstName}');
                   """;
        var command = new NpgsqlCommand(sql, _connection);
        command.ExecuteNonQuery();
        
        _connection.Close();
    }

    public void Remove(User user)
    {
        _connection.Open();

        var sql = $"DELETE FROM table_users WHERE id = '{user.Id}';";
        var command = new NpgsqlCommand(sql, _connection);
        command.ExecuteNonQuery();
        
        _connection.Close();
    }

    public void Update(User user)
    {
        _connection.Open();

        var sql = $"""
                   UPDATE table_users 
                   SET last_name = '{user.LastName}', 
                       first_name = '{user.FirstName}' 
                   WHERE id = '{user.Id}';
                   """;
        var command = new NpgsqlCommand(sql, _connection);
        command.ExecuteNonQuery();
        
        _connection.Close();
    }
}