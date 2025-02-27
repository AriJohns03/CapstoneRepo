using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/protected")]
public class ProtectedController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetProtectedData()
    {
        return Ok(new { message = "This is a protected endpoint!" });
    }
}