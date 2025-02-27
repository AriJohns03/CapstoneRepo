using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

public class AddModel : PageModel
{
    private readonly AuthService _authService;

    public AddModel(AuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public UserDto Input { get; set; }

    public string Message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var result = await _authService.RegisterUser(
            Input.FirstName,
            Input.LastName,
            Input.Email,
            Input.DateOfBirth,
            Input.CompanyName,
            Input.Username,
            Input.Password
            );
        if (result.Contains("already exists"))
        {
            Message = result;
            return Page();
        }

        return RedirectToPage("/Login");
    }
}
