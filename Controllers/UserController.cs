namespace Capstone1.Controllers;
using Capstone1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly DatabaseService _databaseService;

    public UsersController(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _databaseService.GetUsersAsync();
        return Ok(users);
    }
}

