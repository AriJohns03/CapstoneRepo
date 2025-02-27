using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System;
using Capstone1.Data;
using Capstone1.Models;

public class AuthService
{
    private readonly AppDBContext _context;
    private readonly JwtService _jwtService;

    public AuthService(AppDBContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<string> RegisterUser(string firstName, string lastName, string email, DateTime dateOfBirth, string companyName, string username, string password)
    {
        if (await _context.Users.AnyAsync(u => u.Username == username))
            return "User already exists";

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            DateOfBirth = dateOfBirth,
            CompanyName = companyName,
            Username = username,
            PasswordHash = hashedPassword,
            Role = "User"
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return "User registered successfully";
    }

    public async Task<string> AuthenticateUser(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return _jwtService.GenerateToken(user.Username, user.Role);
    }
}
