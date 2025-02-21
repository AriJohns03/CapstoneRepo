namespace Capstone1.Data;
using Capstone1.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        var users = new List<UserModel>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var query = "SELECT Id, Name, Email FROM Users";
        using var command = new SqlCommand(query, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            users.Add(new UserModel
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return users;
    }
}
