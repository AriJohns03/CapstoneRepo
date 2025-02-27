using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        HttpContext.Session.Remove("AuthToken"); // Remove JWT Token from session
        return RedirectToPage("/Login"); // Redirect to login page
    }
}
