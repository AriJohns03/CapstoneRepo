using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        Response.Cookies.Delete("AuthToken"); // Deletes the JWT cookie
        HttpContext.Session.Clear();
        return RedirectToPage("Login");
    }
}
