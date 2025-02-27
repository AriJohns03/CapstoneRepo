using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
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
