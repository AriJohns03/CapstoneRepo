//namespace Capstone1.Controllers;
//using Capstone1.Data;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("/users")]
//public class UsersController : ControllerBase
//{
//    private readonly DatabaseService _databaseService;

//    public UsersController()
//    {
//        _databaseService = databaseService;
//        GetUsers();
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetUsers()
//    {
//        var users = await _databaseService.GetUsersAsync();
//        return Ok(users);
//    }
//}
