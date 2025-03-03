using Capstone1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly AppDBContext context;

    public AuthController(AuthService authService, AppDBContext _context)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var result = await _authService.RegisterUser(
            userDto.FirstName,
            userDto.LastName,
            userDto.Email,
            userDto.DateOfBirth,
            userDto.CompanyName,
            userDto.Username,
            userDto.Password
        );

        if (result == null)
        {
            return BadRequest(new { message = "Registration failed." });
        }

        return Ok(new { message = "User registered successfully!" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _authService.AuthenticateUser(loginDto.Username, loginDto.Password);
        if (token == null) return Unauthorized();

        return Ok(new { token });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        Response.Cookies.Delete("AuthToken"); // Deletes the JWT cookie
        HttpContext.Session.Clear();
        return RedirectToPage("/Login");
    }

    //[Authorize]
    //[HttpGet("profile")]
    //public async Task<IActionResult> GetProfile()
    //{
    //    var username = User.Identity?.Name; // Get username from JWT

    //    if (string.IsNullOrEmpty(username))
    //    {
    //        return Unauthorized(new { message = "User is not authenticated" });
    //    }

    //    var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

    //    if (user == null)
    //    {
    //        return NotFound(new { message = "User not found" });
    //    }

    //    var userDto = new UserDto
    //    {
    //        Username = user.Username,
    //        FirstName = user.FirstName,
    //        LastName = user.LastName,
    //        DateOfBirth = user.DateOfBirth,
    //        Email = user.Email,
    //        CompanyName = user.CompanyName
    //    };

    //    return View(userDto); // Return a view with the user's profile data
    //}

}

public class LoginDto
{  
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
}
