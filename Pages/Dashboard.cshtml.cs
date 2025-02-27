using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class DashboardModel : PageModel
{
    public string Username { get; private set; }

    public IActionResult OnGet()
    {
        var token = HttpContext.Session.GetString("AuthToken");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToPage("/Account/Login");
        }

        Username = "User"; // Ideally, extract username from JWT token.
        return Page();
    }
}
